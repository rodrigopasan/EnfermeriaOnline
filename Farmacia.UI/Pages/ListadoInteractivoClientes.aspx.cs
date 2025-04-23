using System;
using System.Linq;
using System.Web.UI.WebControls;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;
using System.Collections.Generic;

namespace Farmacia.UI.Pages
{
    public partial class ListadoInteractivoClientes : System.Web.UI.Page
    {
        private ClienteService clienteService;

        protected void Page_Load(object sender, EventArgs e)
        {
            clienteService = new ClienteService();
            if (!IsPostBack)
            {
                CargarClientes();
            }
            if (Session["Usuario"] == null)
            {
                // Redirigir al login si la sesión no está iniciada
                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        private void CargarClientes(string sortExpression = null)
        {
            var clientes = clienteService.ObtenerClientes();
            if (sortExpression != null)
            {
                clientes = OrdenarClientes(clientes, sortExpression);
                ViewState["SortExpression"] = sortExpression;
            }
            else if (ViewState["SortExpression"] != null)
            {
                clientes = OrdenarClientes(clientes, ViewState["SortExpression"].ToString());
            }
            gvClientes.DataSource = clientes;
            gvClientes.DataBind();
        }

        private List<Cliente> OrdenarClientes(List<Cliente> clientes, string sortExpression)
        {
            string[] sortParts = sortExpression.Split(' ');
            string sortField = sortParts[0];
            string sortDirection = sortParts[1];

            switch (sortField)
            {
                case "CI":
                    clientes = sortDirection == "ASC" ?
                        clientes.OrderBy(c => c.CI).ToList() :
                        clientes.OrderByDescending(c => c.CI).ToList();
                    break;
                case "Nombre":
                    clientes = sortDirection == "ASC" ?
                        clientes.OrderBy(c => c.Nombre).ToList() :
                        clientes.OrderByDescending(c => c.Nombre).ToList();
                    break;
                case "Número":
                    clientes = sortDirection == "ASC" ?
                        clientes.OrderBy(c => c.Número).ToList() :
                        clientes.OrderByDescending(c => c.Número).ToList();
                    break;
                case "NumTarjeta":
                    clientes = sortDirection == "ASC" ?
                        clientes.OrderBy(c => c.NumTarjeta).ToList() :
                        clientes.OrderByDescending(c => c.NumTarjeta).ToList();
                    break;
                case "Teléfono":
                    clientes = sortDirection == "ASC" ?
                        clientes.OrderBy(c => c.Teléfono).ToList() :
                        clientes.OrderByDescending(c => c.Teléfono).ToList();
                    break;
            }

            return clientes;
        }

        protected void btnEditarGeneral_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvClientes.Rows)
            {
                PlaceHolder phAcciones = (PlaceHolder)row.FindControl("phAcciones");
                if (phAcciones != null)
                {
                    phAcciones.Visible = true;
                }
            }
        }

        protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClientes.PageIndex = e.NewPageIndex;
            CargarClientes();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(criterio))
            {
                gvClientes.DataSource = clienteService.BuscarClientes(criterio);
                gvClientes.DataBind();
            }
            else
            {
                CargarClientes();
            }
        }

        protected void btnOrdenar_Click(object sender, EventArgs e)
        {
            string campo = ddlOrdenarPor.SelectedValue;
            string orden = ddlOrden.SelectedValue;
            string sortExpression = campo + " " + orden;
            CargarClientes(sortExpression);
        }

        protected void gvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvClientes.EditIndex = e.NewEditIndex;
            CargarClientes();
        }

        protected void gvClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvClientes.EditIndex = -1;
            CargarClientes();
        }

        protected void gvClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ci = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
            string nombre = ((TextBox)gvClientes.Rows[e.RowIndex].FindControl("txtNombre")).Text;
            string numero = ((TextBox)gvClientes.Rows[e.RowIndex].FindControl("txtNumero")).Text;
            string numTarjeta = ((TextBox)gvClientes.Rows[e.RowIndex].FindControl("txtNumTarjeta")).Text;
            string telefono = ((TextBox)gvClientes.Rows[e.RowIndex].FindControl("txtTelefono")).Text;

            Cliente cliente = new Cliente(ci, nombre, numero, numTarjeta, telefono);

            try
            {
                clienteService.ModificarCliente(cliente);
                lblSuccess.Text = "Cliente actualizado correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = "Actualizar: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }

            gvClientes.EditIndex = -1;
            CargarClientes();
        }

        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ci = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);
            try
            {
                clienteService.EliminarCliente(ci);
                lblSuccess.Text = "Cliente eliminado correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = "Eliminar: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }

            CargarClientes();
        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            PanelNuevoCliente.Visible = true;
            LimpiarFormulario();
        }

        protected void btnGuardarNuevo_Click(object sender, EventArgs e)
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
                txtNombreNuevo.Text,
                txtNumeroNuevo.Text,
                txtNumTarjetaNuevo.Text,
                txtTelefonoNuevo.Text
            );

            try
            {
                clienteService.AltaCliente(cliente);
                lblSuccess.Text = "Cliente agregado correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;

                PanelNuevoCliente.Visible = false;
                CargarClientes();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar el cliente: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void btnCancelarNuevo_Click(object sender, EventArgs e)
        {
            PanelNuevoCliente.Visible = false;
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtCI.Text = "";
            txtNombreNuevo.Text = "";
            txtNumeroNuevo.Text = "";
            txtNumTarjetaNuevo.Text = "";
            txtTelefonoNuevo.Text = "";
            lblError.Visible = false;
            lblSuccess.Visible = false;
        }
    }
}
