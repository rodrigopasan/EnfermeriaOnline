using System;
using System.Web.UI.WebControls;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;

namespace Farmacia.UI.Pages
{
    public partial class ABMArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulos();
                CargarCategorías();
                PanelArticulo.Visible = false;
            }
            if (Session["Usuario"] == null)
            {
                // Redirigir al login si la sesión no está iniciada
                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        private void CargarArticulos()
        {
            ArticuloService articuloService = new ArticuloService();
            var articulos = articuloService.ObtenerArticulos();
            gvArticulos.DataSource = articulos;
            gvArticulos.DataBind();
        }

        private void CargarCategorías()
        {
            CategoriaService categoríaService = new CategoriaService();
            var categorías = categoríaService.ObtenerCategorias();
            ddlCategoría.DataSource = categorías;
            ddlCategoría.DataTextField = "Nombre";
            ddlCategoría.DataValueField = "CódigoC";
            ddlCategoría.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            PanelArticulo.Visible = true;
            LimpiarCampos();
            gvArticulos.SelectedIndex = -1;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Button btnModificar = (Button)sender;
            string códigoA = btnModificar.CommandArgument;

            ArticuloService articuloService = new ArticuloService();
            Articulo articulo = articuloService.ObtenerArticuloPorCodigo(códigoA);

            if (articulo != null)
            {
                txtNombre.Text = articulo.Nombre;
                txtPrecio.Text = articulo.Precio.ToString("F2");
                txtPresentación.Text = articulo.Presentación;
                txtTamaño.Text = articulo.Tamaño;
                ddlCategoría.SelectedValue = articulo.CódigoC;

                ViewState["CódigoA"] = códigoA;
                ViewState["NombreCategoría"] = articulo.NombreCategoría;
                PanelArticulo.Visible = true;
                lblSuccess.Visible = false;
                lblError.Visible = false;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string códigoA = btnEliminar.CommandArgument;

            ArticuloService articuloService = new ArticuloService();
            try
            {
                articuloService.EliminarArticulo(códigoA);
                lblSuccess.Text = "Artículo eliminado correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;
                CargarArticulos();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al eliminar el artículo: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                lblError.Text = "El precio debe ser un número válido.";
                lblError.Visible = true;
                lblSuccess.Visible = false;
                return;
            }

            string nombreCategoría = ViewState["NombreCategoría"] != null ? ViewState["NombreCategoría"].ToString() : ddlCategoría.SelectedItem.Text;

            ArticuloService articuloService = new ArticuloService();
            try
            {
                if (ViewState["CódigoA"] == null)  // Agregar
                {
                    Articulo articulo = new Articulo(
                        txtNombre.Text,
                        precio,
                        txtPresentación.Text,
                        txtTamaño.Text,
                        ddlCategoría.SelectedValue,
                        nombreCategoría
                    );
                    articuloService.AltaArticulo(articulo);
                    lblSuccess.Text = "Artículo agregado correctamente.";
                    lblSuccess.Visible = true;
                    lblError.Visible = false;
                }
                else  // Modificar
                {
                    Articulo articulo = new Articulo(
                        ViewState["CódigoA"].ToString(),
                        txtNombre.Text,
                        precio,
                        txtPresentación.Text,
                        txtTamaño.Text,
                        ddlCategoría.SelectedValue,
                        nombreCategoría
                    );
                    articuloService.ModificarArticulo(articulo);
                    lblSuccess.Text = "Artículo modificado correctamente.";
                    lblSuccess.Visible = true;
                    lblError.Visible = false;
                }
                PanelArticulo.Visible = false;
                CargarArticulos();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar el artículo: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelArticulo.Visible = false;
            lblSuccess.Visible = false;
            lblError.Visible = false;
            ViewState["CódigoA"] = null;
        }

        protected void gvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No es necesario por el momento
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtPresentación.Text = "";
            txtTamaño.Text = "";
            ddlCategoría.SelectedIndex = -1;
            ViewState["CódigoA"] = null;
        }
    }
}
