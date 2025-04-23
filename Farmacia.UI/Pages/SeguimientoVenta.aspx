<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeguimientoVenta.aspx.cs" Inherits="Farmacia.UI.Pages.SeguimientoVenta" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        /* Estilos personalizados */
        .panel-ventas {
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

    <h2 class="welcome-message">Seguimiento de Ventas</h2>
    
    <div class="panel-ventas">
        <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowDataBound="gvVentas_RowDataBound">
            <Columns>
                <asp:BoundField DataField="NúmeroVenta" HeaderText="Número de Venta" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="CI" HeaderText="CI del Cliente" />
                <asp:BoundField DataField="CodigoA" HeaderText="Código del Artículo" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnModificarEstado" runat="server" Text="Modificar Estado" CssClass="btn" CommandArgument='<%# Eval("NúmeroVenta") %>' OnClick="btnModificarEstado_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</asp:Content>

