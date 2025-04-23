<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMArticulos.aspx.cs" Inherits="Farmacia.UI.Pages.ABMArticulos" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Artículos</h2>
    <div>
        <asp:GridView ID="gvArticulos" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="CódigoA" HeaderText="Código" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Presentación" HeaderText="Presentación" />
                <asp:BoundField DataField="Tamaño" HeaderText="Tamaño" />
                <asp:BoundField DataField="NombreCategoría" HeaderText="Categoría" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandArgument='<%# Eval("CódigoA") %>' OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("CódigoA") %>' OnClick="btnEliminar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Artículo" OnClick="btnAgregar_Click" />
    </div>
    <asp:Panel ID="PanelArticulo" runat="server" Visible="false">
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
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    </asp:Panel>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</asp:Content>
