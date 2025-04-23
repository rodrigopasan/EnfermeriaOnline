using System;
using System.Linq;
using System.Web.UI.WebControls;
using Farmacia.BLL.Services;
using Farmacia.DAL.Entities;
using System.Collections.Generic;

namespace Farmacia.UI.Pages
{
    public partial class ListadoInteractivoArticulos : System.Web.UI.Page
    {
        private ArticuloService articuloService;
        private CategoriaService categoriaService;

        protected void Page_Load(object sender, EventArgs e)
        {
            articuloService = new ArticuloService();
            categoriaService = new CategoriaService();
            if (!IsPostBack)
            {
                CargarArticulos();
                CargarCategorias();
            }
            if (Session["Usuario"] == null)
            {
                // Redirigir al login si la sesión no está iniciada.
                Response.Redirect("~/Pages/Default.aspx");
            }
        }

        private void CargarArticulos(string sortExpression = null)
        {
            var articulos = articuloService.ObtenerArticulos();
            if (sortExpression != null)
            {
                articulos = OrdenarArticulos(articulos, sortExpression);
                ViewState["SortExpression"] = sortExpression;
            }
            else if (ViewState["SortExpression"] != null)
            {
                articulos = OrdenarArticulos(articulos, ViewState["SortExpression"].ToString());
            }
            gvArticulos.DataSource = articulos;
            gvArticulos.DataBind();
        }

        private List<Articulo> OrdenarArticulos(List<Articulo> articulos, string sortExpression)
        {
            string[] sortParts = sortExpression.Split(' ');
            string sortField = sortParts[0];
            string sortDirection = sortParts[1];

            switch (sortField)
            {
                case "CódigoA":
                    articulos = sortDirection == "ASC" ?
                        articulos.OrderBy(a => a.CódigoA).ToList() :
                        articulos.OrderByDescending(a => a.CódigoA).ToList();
                    break;
                case "Nombre":
                    articulos = sortDirection == "ASC" ?
                        articulos.OrderBy(a => a.Nombre).ToList() :
                        articulos.OrderByDescending(a => a.Nombre).ToList();
                    break;
                case "Precio":
                    articulos = sortDirection == "ASC" ?
                        articulos.OrderBy(a => a.Precio).ToList() :
                        articulos.OrderByDescending(a => a.Precio).ToList();
                    break;
                case "Presentación":
                    articulos = sortDirection == "ASC" ?
                        articulos.OrderBy(a => a.Presentación).ToList() :
                        articulos.OrderByDescending(a => a.Presentación).ToList();
                    break;
                case "Tamaño":
                    articulos = sortDirection == "ASC" ?
                        articulos.OrderBy(a => a.Tamaño).ToList() :
                        articulos.OrderByDescending(a => a.Tamaño).ToList();
                    break;
                case "NombreCategoría":
                    articulos = sortDirection == "ASC" ?
                        articulos.OrderBy(a => a.NombreCategoría).ToList() :
                        articulos.OrderByDescending(a => a.NombreCategoría).ToList();
                    break;
            }

            return articulos;
        }

        private void CargarCategorias()
        {
            var categorias = categoriaService.ObtenerCategorias();
            ddlCategoría.DataSource = categorias;
            ddlCategoría.DataTextField = "Nombre";
            ddlCategoría.DataValueField = "CódigoC";
            ddlCategoría.DataBind();

            foreach (GridViewRow row in gvArticulos.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow && (row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                {
                    var ddlCategoria = (DropDownList)row.FindControl("ddlCategoria");
                    if (ddlCategoria != null)
                    {
                        ddlCategoria.DataSource = categorias;
                        ddlCategoria.DataTextField = "Nombre";
                        ddlCategoria.DataValueField = "CódigoC";
                        ddlCategoria.DataBind();

                        var hfCodigoC = (HiddenField)row.FindControl("hfCodigoC");
                        if (hfCodigoC != null)
                        {
                            ddlCategoria.SelectedValue = hfCodigoC.Value;
                        }
                    }
                }
            }
        }

        protected void btnEditarGeneral_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvArticulos.Rows)
            {
                PlaceHolder phAcciones = (PlaceHolder)row.FindControl("phAcciones");
                if (phAcciones != null)
                {
                    phAcciones.Visible = true;
                }
            }
        }

        protected void gvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvArticulos.PageIndex = e.NewPageIndex;
            CargarArticulos();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(criterio))
            {
                gvArticulos.DataSource = articuloService.BuscarArticulos(criterio);
                gvArticulos.DataBind();
            }
            else
            {
                CargarArticulos();
            }
        }

        protected void btnOrdenar_Click(object sender, EventArgs e)
        {
            string campo = ddlOrdenarPor.SelectedValue;
            string orden = ddlOrden.SelectedValue;
            string sortExpression = campo + " " + orden;
            CargarArticulos(sortExpression);
        }

        protected void gvArticulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvArticulos.EditIndex = e.NewEditIndex;
            CargarArticulos();
            CargarCategorias();
        }

        protected void gvArticulos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvArticulos.EditIndex = -1;
            CargarArticulos();
        }

        protected void gvArticulos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string codigoA = gvArticulos.DataKeys[e.RowIndex].Value.ToString();
            string nombre = ((TextBox)gvArticulos.Rows[e.RowIndex].FindControl("txtNombre")).Text;
            decimal precio = Convert.ToDecimal(((TextBox)gvArticulos.Rows[e.RowIndex].FindControl("txtPrecio")).Text);
            string presentacion = ((TextBox)gvArticulos.Rows[e.RowIndex].FindControl("txtPresentación")).Text;
            string tamaño = ((TextBox)gvArticulos.Rows[e.RowIndex].FindControl("txtTamaño")).Text;
            string codigoC = ((DropDownList)gvArticulos.Rows[e.RowIndex].FindControl("ddlCategoria")).SelectedValue;
            string nombreCategoría = ((DropDownList)gvArticulos.Rows[e.RowIndex].FindControl("ddlCategoria")).SelectedItem.Text;

            Articulo articulo = new Articulo(codigoA, nombre, precio, presentacion, tamaño, codigoC, nombreCategoría);

            try
            {
                articuloService.ModificarArticulo(articulo);
                lblSuccess.Text = "Artículo actualizado correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = "Actualizar: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }

            gvArticulos.EditIndex = -1;
            CargarArticulos();
        }

        protected void gvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string codigoA = gvArticulos.DataKeys[e.RowIndex].Value.ToString();
            try
            {
                articuloService.EliminarArticulo(codigoA);
                lblSuccess.Text = "Artículo eliminado correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = "Eliminar: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }

            CargarArticulos();
        }

        protected void btnNuevoArticulo_Click(object sender, EventArgs e)
        {
            CargarCategorias(); // Cargar categorías antes de mostrar el panel
            PanelNuevoArticulo.Visible = true;
            LimpiarFormulario();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                decimal precio = Convert.ToDecimal(txtPrecio.Text.Trim());
                string presentacion = txtPresentación.Text.Trim();
                string tamaño = txtTamaño.Text.Trim();
                string codigoC = ddlCategoría.SelectedValue;
                string nombreCategoría = ddlCategoría.SelectedItem.Text;

                Articulo articulo = new Articulo(nombre, precio, presentacion, tamaño, codigoC, nombreCategoría);
                articuloService.AltaArticulo(articulo);

                lblSuccess.Text = "Artículo guardado correctamente.";
                lblSuccess.Visible = true;
                lblError.Visible = false;

                CargarArticulos();
                PanelNuevoArticulo.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = "Guardar: " + ex.Message;
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelNuevoArticulo.Visible = false;
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtPresentación.Text = "";
            txtTamaño.Text = "";
            ddlCategoría.SelectedIndex = 0;
        }
    }
}
