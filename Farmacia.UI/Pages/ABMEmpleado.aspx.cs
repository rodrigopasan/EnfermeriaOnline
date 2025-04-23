using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;

namespace Farmacia.UI.Pages
{
    public partial class ABMEmpleado : Page
    {
        private EmpleadoService _empleadoService;

        protected void Page_Load(object sender, EventArgs e)
        {
            _empleadoService = new EmpleadoService();

            if (!IsPostBack)
            {
                if (Session["Usuario"] == null || Session["Usuario"].ToString() != "admin")
                {
                    Response.Redirect("~/Pages/Default.aspx");
                }

                CargarEmpleados();
            }
        }

        private void CargarEmpleados()
        {
            var empleados = _empleadoService.ObtenerTodosLosEmpleados();
            gvEmpleados.DataSource = empleados;
            gvEmpleados.DataBind();
        }

        protected void gvEmpleados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmpleados.EditIndex = e.NewEditIndex;
            CargarEmpleados();
        }

        protected void gvEmpleados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmpleados.EditIndex = -1;
            CargarEmpleados();
        }

        protected void gvEmpleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvEmpleados.Rows[e.RowIndex];
            string usuario = gvEmpleados.DataKeys[e.RowIndex].Value.ToString();

            TextBox txtNombre = (TextBox)row.FindControl("txtNombre");
            TextBox txtContraseña = (TextBox)row.FindControl("txtContraseña");

            if (txtNombre != null && txtContraseña != null)
            {
                string nombre = txtNombre.Text;
                string contraseña = txtContraseña.Text;

                Empleado empleado = new Empleado(usuario, nombre, contraseña);

                try
                {
                    _empleadoService.ModificarEmpleado(empleado);
                    lblSuccess.Text = "Empleado actualizado correctamente.";
                    lblSuccess.Visible = true;
                    lblError.Visible = false;
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error al actualizar el empleado: " + ex.Message;
                    lblError.Visible = true;
                    lblSuccess.Visible = false;
                }

                gvEmpleados.EditIndex = -1;
                CargarEmpleados();
            }
            else
            {
                lblError.Text = "Error: No se encontraron los controles para la edición.";
                lblError.Visible = true;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string nombre = txtNombre.Text;
            string contraseña = txtContraseña.Text;

            Empleado empleado = new Empleado(usuario, nombre, contraseña); // Asegúrate de pasar todos los parámetros

            _empleadoService.AltaEmpleado(empleado);

            lblSuccess.Text = "Empleado creado exitosamente.";
            lblSuccess.Visible = true;
            lblError.Visible = false;
            PanelCrearEmpleado.Visible = false;
            CargarEmpleados();
        }

        protected void gvEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gvEmpleados.DataKeys.Count)
            {
                string usuario = gvEmpleados.DataKeys[e.RowIndex].Value.ToString();
                try
                {
                    _empleadoService.EliminarEmpleado(usuario);
                    lblSuccess.Text = "Empleado eliminado correctamente.";
                    lblSuccess.Visible = true;
                    lblError.Visible = false;
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error al eliminar el empleado: " + ex.Message;
                    lblError.Visible = true;
                    lblSuccess.Visible = false;
                }
                CargarEmpleados();
            }
            else
            {
                lblError.Text = "El índice especificado está fuera del rango.";
                lblError.Visible = true;
            }
        }

        protected void btnCrearNuevoEmpleado_Click(object sender, EventArgs e)
        {
            PanelCrearEmpleado.Visible = true;
            LimpiarFormulario();
        }
        protected void btnCancelarCreacion_Click(object sender, EventArgs e)
        {
            PanelCrearEmpleado.Visible = false;
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtContraseña.Text = "";
            lblError.Visible = false;
            lblSuccess.Visible = false;
        }
    }
}