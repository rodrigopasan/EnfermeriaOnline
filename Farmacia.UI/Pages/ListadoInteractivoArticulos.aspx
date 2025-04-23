<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoInteractivoArticulos.aspx.cs" Inherits="Farmacia.UI.Pages.ListadoInteractivoArticulos" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        /* Estilos personalizados */
        .panel-articulos {
            padding: 20px;
            margin: 20px;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        fieldset {
            margin-bottom: 20px;
            border: 1px solid #ddd;
            padding: 10px;
            border-radius: 5px;
        }
        legend {
            font-size: 18px;
            font-weight: bold;
            color: #2C3E50;
        }
        label {
            display: inline-block;
            width: 150px;
            font-weight: bold;
        }
        .btn {
            background-color: #2ECC71;
            color: #fff;
            border: none;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            margin: 10px 0;
            cursor: pointer;
            border-radius: 5px;
        }
        .btn:hover {
            background-color: #27AE60;
        }
        .gridview-pager {
            text-align: center;
            margin-top: 20px;
        }
        .welcome-message {
            text-align: center;
            margin-bottom: 20px;
            font-size: 24px;
            color: #2C3E50;
        }
    </style>

    <h2 class="welcome-message">Listado Interactivo de Artículos</h2>
    
    <div class="panel-articulos">
        <fieldset>
            <legend>Buscar Artículos</legend>
            <asp:Label ID="lblBuscar" runat="server" Text="Buscar por Código o Nombre:"></asp:Label>
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" />
        </fieldset>
        <fieldset>
            <legend>Ordenar Artículos</legend>
            <asp:Label ID="lblOrdenarPor" runat="server" Text="Ordenar por:"></asp:Label>
            <asp:DropDownList ID="ddlOrdenarPor" runat="server">
                <asp:ListItem Text="Código" Value="CódigoA" />
                <asp:ListItem Text="Nombre" Value="Nombre" />
                <asp:ListItem Text="Precio" Value="Precio" />
                <asp:ListItem Text="Presentación" Value="Presentación" />
                <asp:ListItem Text="Tamaño" Value="Tamaño" />
                <asp:ListItem Text="Categoría" Value="NombreCategoría" />
            </asp:DropDownList>
            <asp:Label ID="lblOrden" runat="server" Text="Orden:"></asp:Label>
            <asp:DropDownList ID="ddlOrden" runat="server">
                <asp:ListItem Text="Ascendente" Value="ASC" />
                <asp:ListItem Text="Descendente" Value="DESC" />
            </asp:DropDownList>
            <asp:Button ID="btnOrdenar" runat="server" Text="Ordenar" CssClass="btn" OnClick="btnOrdenar_Click" />
        </fieldset>
        <asp:Button ID="btnNuevoArticulo" runat="server" Text="Nuevo Artículo" CssClass="btn" OnClick="btnNuevoArticulo_Click" />
        <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="False" DataKeyNames="CódigoA" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvArticulos_PageIndexChanging" OnRowEditing="gvArticulos_RowEditing" OnRowDeleting="gvArticulos_RowDeleting" OnRowCancelingEdit="gvArticulos_RowCancelingEdit" OnRowUpdating="gvArticulos_RowUpdating">
            <Columns>
                <asp:BoundField DataField="CódigoA" HeaderText="Código" ReadOnly="True" />
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <%# Eval("Nombre") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Precio">
                    <ItemTemplate>
                        <%# Eval("Precio") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("Precio") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Presentación">
                    <ItemTemplate>
                        <%# Eval("Presentación") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPresentación" runat="server" Text='<%# Bind("Presentación") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tamaño">
                    <ItemTemplate>
                        <%# Eval("Tamaño") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTamaño" runat="server" Text='<%# Bind("Tamaño") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Categoría">
                    <ItemTemplate>
                        <%# Eval("NombreCategoría") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Acciones">
                    <HeaderTemplate>
                        <asp:Button ID="btnEditarGeneral" runat="server" Text="Editar" CssClass="btn" OnClick="btnEditarGeneral_Click" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:PlaceHolder ID="phAcciones" runat="server" Visible="False">
                            <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Edit" Text="Editar" CssClass="btn" />
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Delete" Text="Eliminar" CssClass="btn" />
                        </asp:PlaceHolder>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkActualizar" runat="server" CommandName="Update" Text="Actualizar" CssClass="btn" />
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="lnkCancelar" runat="server" CommandName="Cancel" Text="Cancelar" CssClass="btn" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="gridview-pager" />
        </asp:GridView>
    </div>
    <asp:Panel ID="PanelNuevoArticulo" runat="server" Visible="false">
        <fieldset>
            <legend>Nuevo Artículo</legend>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:Label ID="lblPrecio" runat="server" Text="Precio:"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <asp:Label ID="lblPresentación" runat="server" Text="Presentación:"></asp:Label>
            <asp:TextBox ID="txtPresentación" runat="server"></asp:TextBox>
            <asp:Label ID="lblTamaño" runat="server" Text="Tamaño:"></asp:Label>
            <asp:TextBox ID="txtTamaño" runat="server"></asp:TextBox>
            <asp:Label ID="lblCategoría" runat="server" Text="Categoría:"></asp:Label>
            <asp:DropDownList ID="ddlCategoría" runat="server"></asp:DropDownList>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" />
        </fieldset>
    </asp:Panel>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</asp:Content>
