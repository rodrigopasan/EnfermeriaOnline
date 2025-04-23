using System;
using System.Web.UI;

namespace Farmacia.UI.Pages
{
    public partial class HomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    LblBienvenida.Text = "Bienvenido, " + Session["Usuario"].ToString() + " al Sistema de Gestión de Ventas de la Farmacia.";
                }
                else
                {
                    Response.Redirect("~/Pages/Default.aspx");
                }
            }
        }
    }
}
