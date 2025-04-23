using System;
using System.Web.UI.WebControls;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;

namespace Farmacia.UI.Pages
{
    public partial class ABMCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                PanelCategoria.Visible = false;
            }
            if (Session["Usuario"] == null)
            {
                // Redirigir al login si la sesión no está iniciada
                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        private void CargarCategorias()
        {
            CategoriaService categoriaService = new CategoriaService();
            var categorias = categoriaService.ObtenerCategorias();
            gvCategorias.DataSource = categorias;
            gvCategorias.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            PanelCategoria.Visible = true;
            LimpiarCampos();
            gvCategorias.SelectedIndex = -1;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Button btnModificar = (Button)sender;
            string codigoC = btnModificar.CommandArgument;

            CategoriaService categoriaService = new CategoriaService();
            Categoria categoria = categoriaService.ObtenerCategoriaPorCodigo(codigoC);

            if (categoria != null)
            {
                txtCodigo.Text = categoria.CódigoC;
                txtNombre.Text = categoria.Nombre;
                ViewState["CódigoC"] = codigoC;
                PanelCategoria.Visible = true;
                lblSuccess.Visible = false;
                lblError.Visible = false;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string codigoC = btnEliminar.CommandArgument;

            CategoriaService categoriaService = new CategoriaService();
            try
            {
                categoriaService.EliminarCategoria(codigoC);
                lblSuccess.Text = "Categoría eliminada correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;
                CargarCategorias();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al eliminar la categoría: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CategoriaService categoriaService = new CategoriaService();
            try
            {
                if (ViewState["CódigoC"] == null)  // Agregar
                {
                    Categoria categoria = new Categoria(
                        txtCodigo.Text,
                        txtNombre.Text
                    );
                    categoriaService.AltaCategoria(categoria);
                    lblSuccess.Text = "Categoría agregada correctamente.";
                    lblSuccess.Visible = true;
                    lblError.Visible = false;
                }
                else  // Modificar
                {
                    Categoria categoria = new Categoria(
                        ViewState["CódigoC"].ToString(),
                        txtNombre.Text
                    );
                    categoriaService.ModificarCategoria(categoria);
                    lblSuccess.Text = "Categoría modificada correctamente.";
                    lblSuccess.Visible = true;
                    lblError.Visible = false;
                }
                PanelCategoria.Visible = false;
                CargarCategorias();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar la categoría: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelCategoria.Visible = false;
            lblSuccess.Visible = false;
            lblError.Visible = false;
            ViewState["CódigoC"] = null;
        }

        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No es necesario por el momento
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            ViewState["CódigoC"] = null;
        }
    }
}
