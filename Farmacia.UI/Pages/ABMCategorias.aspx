<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCategorias.aspx.cs" Inherits="Farmacia.UI.Pages.ABMCategorias" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .panel-categorias {
            padding: 20px;
            margin: 20px;
            background-color: #f9f9f9;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            text-align: center;
            font-size: 24px;
            color: #2C3E50;
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

    <h2 class="welcome-message">Gestión de Categorías</h2>
    
    <div class="panel-categorias">
        <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="false" CssClass="table" OnSelectedIndexChanged="gvCategorias_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="CódigoC" HeaderText="Código" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn" CommandArgument='<%# Eval("CódigoC") %>' OnClick="btnModificar_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn" CommandArgument='<%# Eval("CódigoC") %>' OnClick="btnEliminar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Categoría" CssClass="btn" OnClick="btnAgregar_Click" />
    </div>
    <asp:Panel ID="PanelCategoria" runat="server" Visible="false">
        <fieldset>
            <legend>Nueva Categoría</legend>
            <asp:Label ID="lblCodigo" runat="server" Text="Código:"></asp:Label>
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" />
        </fieldset>
    </asp:Panel>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</asp:Content>

