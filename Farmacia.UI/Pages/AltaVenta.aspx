<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaVenta.aspx.cs" Inherits="Farmacia.UI.Pages.AltaVenta" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .panel-venta {
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
        table {
            width: 100%;
            margin: 0 auto;
            border-collapse: collapse;
        }
        td {
            padding: 10px;
            vertical-align: top;
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
        .fecha-textbox {
            display: block;
            margin-bottom: 10px;
        }
        .calendar-container {
            text-align: left;
            display: inline-block;
        }



        .auto-style1 {
            width: 361px;
        }



    </style>

    <h2 class="welcome-message">Alta de Venta</h2>
    
    <asp:Panel ID="PanelVenta" runat="server" CssClass="panel-venta">
        <fieldset>
            <legend>Nueva Venta</legend>
            <table>
                <tr>
                    <td class="auto-style1"><asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtFecha" runat="server" ReadOnly="true" CssClass="fecha-textbox"></asp:TextBox>
                        <div class="calendar-container">
                            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Width="250px" Height="200px"></asp:Calendar>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:Label ID="lblEstado" runat="server" Text="Estado:"></asp:Label></td>
                    <td><asp:TextBox ID="txtEstado" runat="server" Text="Armado" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:Label ID="lblCI" runat="server" Text="CI del Cliente:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtCI" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnBuscarCI" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscarCI_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:Label ID="lblCodigoA" runat="server" Text="Código del Artículo:"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtCodigoA" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnBuscarCodigoA" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscarCodigoA_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:Label ID="lblCantidad" runat="server" Text="Cantidad:"></asp:Label></td>
                    <td><asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style1"><asp:Label ID="lblDireccion" runat="server" Text="Dirección:"></asp:Label></td>
                    <td><asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardar_Click" Enabled="false" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</asp:Content>
