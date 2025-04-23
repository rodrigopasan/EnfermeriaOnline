using System;
using System.Web.UI.WebControls;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;

namespace Farmacia.UI.Pages
{
    public partial class AltaVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtEstado.Text = "Armado";
            }
            if (Session["Usuario"] == null)
            {
                // Redirigir al login si la sesión no está iniciada
                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }

        protected void btnBuscarCI_Click(object sender, EventArgs e)
        {
            int clienteCI;
            if (!int.TryParse(txtCI.Text, out clienteCI))
            {
                lblError.Text = "El CI debe ser un número válido.";
                lblError.Visible = true;
                return;
            }

            ClienteService clienteService = new ClienteService();

            try
            {
                Cliente cliente = clienteService.ObtenerClientePorCI(clienteCI);
                if (cliente != null)
                {
                    txtCI.ReadOnly = true;
                    txtCI.BackColor = System.Drawing.Color.LightGray;
                    lblError.Visible = false;
                    ValidarEntradas();
                }
                else
                {
                    lblError.Text = "Cliente no encontrado.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al buscar el cliente: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnBuscarCodigoA_Click(object sender, EventArgs e)
        {
            string articuloCodigoA = txtCodigoA.Text;
            ArticuloService articuloService = new ArticuloService();

            try
            {
                Articulo articulo = articuloService.ObtenerArticuloPorCodigo(articuloCodigoA);
                if (articulo != null)
                {
                    txtCodigoA.ReadOnly = true;
                    txtCodigoA.BackColor = System.Drawing.Color.LightGray;
                    lblError.Visible = false;
                    ValidarEntradas();
                }
                else
                {
                    lblError.Text = "Artículo no encontrado.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al buscar el artículo: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void ValidarEntradas()
        {
            if (!string.IsNullOrEmpty(txtCI.Text) && !string.IsNullOrEmpty(txtCodigoA.Text))
            {
                btnGuardar.Enabled = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int ci;
            int cantidad;
            if (!int.TryParse(txtCI.Text, out ci))
            {
                lblError.Text = "El CI debe ser un número válido.";
                lblError.Visible = true;
                lblSuccess.Visible = false;
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                lblError.Text = "La cantidad debe ser un número válido.";
                lblError.Visible = true;
                lblSuccess.Visible = false;
                return;
            }

            Venta venta = new Venta(
                DateTime.Now,
                txtEstado.Text,
                ci,
                txtCodigoA.Text,
                cantidad,
                txtDireccion.Text
            );

            VentaService ventaService = new VentaService();
            try
            {
                ventaService.AltaVenta(venta);
                lblSuccess.Text = "Venta agregada correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar la venta: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            lblSuccess.Visible = false;
            lblError.Visible = false;
        }

        private void LimpiarCampos()
        {
            txtCI.Text = "";
            txtCI.ReadOnly = false;
            txtCI.BackColor = System.Drawing.Color.White;
            txtCodigoA.Text = "";
            txtCodigoA.ReadOnly = false;
            txtCodigoA.BackColor = System.Drawing.Color.White;
            txtCantidad.Text = "";
            txtDireccion.Text = "";
            btnGuardar.Enabled = false;
        }
    }
}
