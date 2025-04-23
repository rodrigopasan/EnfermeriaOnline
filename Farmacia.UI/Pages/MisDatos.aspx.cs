using System;
using System.Web.UI;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;

namespace Farmacia.UI.Pages
{
    public partial class MisDatos : System.Web.UI.Page
    {
        private EmpleadoService _empleadoService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Pages/Default.aspx");
            }

            _empleadoService = new EmpleadoService();

            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            string usuario = Session["Usuario"].ToString();
            Empleado empleado = _empleadoService.ObtenerEmpleadoPorUsuario(usuario);

            if (empleado != null)
            {
                lblUsuarioValor.Text = usuario;
                txtNombre.Text = empleado.Nombre;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string usuario = Session["Usuario"].ToString();
            string nombre = txtNombre.Text;
            string contraseñaAnterior = txtContraseñaAnterior.Text;
            string nuevaContraseña = txtNuevaContraseña.Text;

            try
            {
                Empleado empleado = _empleadoService.ObtenerEmpleadoPorUsuario(usuario);

                if (empleado != null && empleado.Contraseña == contraseñaAnterior)
                {
                    empleado.Nombre = nombre;
                    empleado.Contraseña = nuevaContraseña;

                    _empleadoService.ModificarEmpleado(empleado);
                    lblSuccess.Text = "Datos actualizados correctamente.";
                    lblSuccess.Visible = true;
                    lblError.Visible = false;
                }
                else
                {
                    lblError.Text = "La contraseña anterior es incorrecta.";
                    lblError.Visible = true;
                    lblSuccess.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al actualizar los datos: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }
    }
}