using System;
using System.Web.UI.WebControls;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;

namespace Farmacia.UI.Pages
{
    public partial class SeguimientoVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarVentas();
            }
            if (Session["Usuario"] == null)
            {
                // Redirigir al login si la sesión no está iniciada
                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        private void CargarVentas()
        {
            VentaService ventaService = new VentaService();
            var ventas = ventaService.ObtenerVentas();
            gvVentas.DataSource = ventas;
            gvVentas.DataBind();
        }

        protected void gvVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Venta venta = (Venta)e.Row.DataItem;
                Button btnModificarEstado = (Button)e.Row.FindControl("btnModificarEstado");

                // Definir el texto del botón según el estado actual de la venta
                switch (venta.Estado)
                {
                    case "Armado":
                        btnModificarEstado.Text = "Avanzar a Envío";
                        break;
                    case "Envío":
                        btnModificarEstado.Text = "Avanzar a Entregado";
                        break;
                    case "Entregado":
                        btnModificarEstado.Text = "Avanzar a Devuelto";
                        break;
                    case "Devuelto":
                        btnModificarEstado.Visible = false; // Ocultar botón en el estado final
                        break;
                    default:
                        btnModificarEstado.Text = "Estado Desconocido";
                        btnModificarEstado.Enabled = false; // Deshabilitar botón si el estado es desconocido
                        break;
                }
            }
        }

        protected void btnModificarEstado_Click(object sender, EventArgs e)
        {
            Button btnModificarEstado = (Button)sender;
            int numeroVenta = Convert.ToInt32(btnModificarEstado.CommandArgument);

            VentaService ventaService = new VentaService();
            try
            {
                ventaService.ModificarEstadoVenta(numeroVenta);

                lblSuccess.Text = "Estado de la venta modificado correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;
                CargarVentas();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al modificar el estado de la venta: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void gvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No borrar
        }
    }
}
