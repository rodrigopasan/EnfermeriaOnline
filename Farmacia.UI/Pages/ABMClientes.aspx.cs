using System;
using System.Web.UI.WebControls;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;

namespace Farmacia.UI.Pages
{
    public partial class ABMClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                PanelCliente.Visible = false;
            }
            if (Session["Usuario"] == null)
            {
                // Redirigir al login si la sesión no está iniciada
                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        private void CargarClientes()
        {
            ClienteService clienteService = new ClienteService();
            var clientes = clienteService.ObtenerClientes();
            gvClientes.DataSource = clientes;
            gvClientes.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            PanelCliente.Visible = true;
            LimpiarCampos();
            gvClientes.SelectedIndex = -1;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Button btnModificar = (Button)sender;
            int ci = Convert.ToInt32(btnModificar.CommandArgument);

            ClienteService clienteService = new ClienteService();
            Cliente cliente = clienteService.ObtenerClientePorCI(ci);

            if (cliente != null)
            {
                txtCI.Text = cliente.CI.ToString();
                txtNombre.Text = cliente.Nombre;
                txtNúmero.Text = cliente.Número;
                txtNumTarjeta.Text = cliente.NumTarjeta;
                txtTeléfono.Text = cliente.Teléfono;

                ViewState["CI"] = ci;
                PanelCliente.Visible = true;
                lblSuccess.Visible = false;
                lblError.Visible = false;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            int ci = Convert.ToInt32(btnEliminar.CommandArgument);

            ClienteService clienteService = new ClienteService();
            try
            {
                clienteService.EliminarCliente(ci);
                lblSuccess.Text = "Cliente eliminado correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;
                CargarClientes();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al eliminar el cliente: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int ci;
            if (!int.TryParse(txtCI.Text, out ci))
            {
                lblError.Text = "El CI debe ser un número válido.";
                lblError.Visible = true;
                lblSuccess.Visible = false;
                return;
            }

            Cliente cliente = new Cliente(
                ci,
                txtNombre.Text,
                txtNúmero.Text,
                txtNumTarjeta.Text,
                txtTeléfono.Text
            );

            ClienteService clienteService = new ClienteService();
            try
            {
                if (ViewState["CI"] == null)  // Agregar
                {
                    clienteService.AltaCliente(cliente);
                    lblSuccess.Text = "Cliente agregado correctamente.";
                    lblSuccess.Visible = true;
                    lblError.Visible = false;
                }
                else  // Modificar
                {
                    cliente.CI = (int)ViewState["CI"];
                    clienteService.ModificarCliente(cliente);
                    lblSuccess.Text = "Cliente modificado correctamente.";
                    lblSuccess.Visible = true;
                    lblError.Visible = false;
                }
                PanelCliente.Visible = false;
                CargarClientes();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar el cliente: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelCliente.Visible = false;
            lblSuccess.Visible = false;
            lblError.Visible = false;
            ViewState["CI"] = null;
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No borrar este metodo
        }

        private void LimpiarCampos()
        {
            txtCI.Text = "";
            txtNombre.Text = "";
            txtNúmero.Text = "";
            txtNumTarjeta.Text = "";
            txtTeléfono.Text = "";
            ViewState["CI"] = null;
        }
    }
}