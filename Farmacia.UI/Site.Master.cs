using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia.UI
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Verificar que el usuario tenga permiso de ingreso
                    if (Session["Usuario"] == null)
                    {
                        LblUsuario.Text = "Usuario anónimo";
                    }
                    else
                    {
                        LblUsuario.Text = "Bienvenido, " + Session["Usuario"].ToString();

                        // Mostrar el menú "Empleado" solo si el usuario es admin
                        if (Session["Usuario"].ToString() == "admin")
                        {
                            foreach (MenuItem item in Menu1.Items)
                            {
                                if (item.Text == "Empleado")
                                {
                                    item.Enabled = true;
                                    item.Selectable = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // Eliminar el menú "Empleado" si el usuario no es admin
                            MenuItem empleadoItem = null;
                            foreach (MenuItem item in Menu1.Items)
                            {
                                if (item.Text == "Empleado")
                                {
                                    empleadoItem = item;
                                    break;
                                }
                            }

                            if (empleadoItem != null)
                            {
                                Menu1.Items.Remove(empleadoItem);
                            }
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/Pages/Default.aspx");
                }
            }
        }

        protected void LnkLogout_Click(object sender, EventArgs e)
        {
            // Cerrar sesión y redirigir al login
            Session["Usuario"] = null;
            Response.Redirect("~/Pages/Default.aspx");
        }
    }
}