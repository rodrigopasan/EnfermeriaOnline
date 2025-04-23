using System;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;
using System.Web.UI;

namespace Farmacia.UI.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        private EmpleadoService _empleadoService;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Por defecto, cada vez que se carga la página de inicio, se desloguea el usuario
            Session["Usuario"] = null;
            _empleadoService = new EmpleadoService(); // No pasar la cadena de conexión

            // Eliminar el código que intenta obtener y pasar la cadena de conexión
            // string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FARMACIAConnectionString"].ConnectionString;
            // _empleadoService = new EmpleadoService(connectionString);
        }

        protected void BtnLogueo_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar usuario en la base de datos
                Empleado empleado = _empleadoService.ObtenerEmpleadoPorUsuario(TxtNomUsu.Text.Trim());

                if (empleado != null && empleado.Contraseña == TxtPassUsu.Text.Trim())
                {
                    // Usuario válido, guardar en sesión y redirigir a HomePage.aspx
                    Session["Usuario"] = empleado.Usuario;
                    Response.Redirect("~/Pages/HomePage.aspx");
                }
                else
                {
                    LblError.Text = "Datos Incorrectos";
                }
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }
}
