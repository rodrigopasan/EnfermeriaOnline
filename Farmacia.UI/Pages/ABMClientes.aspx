<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="Farmacia.UI.Pages.ABMClientes" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Clientes</h2>
    <asp:Panel ID="PanelCliente" runat="server" Visible="false">
        <fieldset>
            <legend>Cliente</legend>
            <asp:Label ID="lblCI" runat="server" Text="CI:"></asp:Label>
            <asp:TextBox ID="txtCI" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNúmero" runat="server" Text="Número:"></asp:Label>
            <asp:TextBox ID="txtNúmero" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblNumTarjeta" runat="server" Text="Número de Tarjeta:"></asp:Label>
            <asp:TextBox ID="txtNumTarjeta" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblTeléfono" runat="server" Text="Teléfono:"></asp:Label>
            <asp:TextBox ID="txtTeléfono" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </fieldset>
    </asp:Panel>
    <br />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Cliente" OnClick="btnAgregar_Click" />
    <br />
    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="CI" HeaderText="CI" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Número" HeaderText="Número" />
            <asp:BoundField DataField="NumTarjeta" HeaderText="Número de Tarjeta" />
            <asp:BoundField DataField="Teléfono" HeaderText="Teléfono" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CommandArgument='<%# Eval("CI") %>' OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("CI") %>' OnClick="btnEliminar_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green" Visible="false"></asp:Label>
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
</asp:Content>
