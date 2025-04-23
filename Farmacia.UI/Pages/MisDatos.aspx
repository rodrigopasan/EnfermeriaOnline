<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisDatos.aspx.cs" Inherits="Farmacia.UI.Pages.MisDatos" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .panel-datos {
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
    </style>

    <h2 class="welcome-message">Mis Datos</h2>
    
    <asp:Panel ID="PanelDatos" runat="server" CssClass="panel-datos">
        <fieldset>
            <legend>Actualizar Mis Datos</legend>
            <table>
                <tr>
                    <td><asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label></td>
                    <td><asp:Label ID="lblUsuarioValor" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
                    <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblContraseñaAnterior" runat="server" Text="Contraseña Anterior:"></asp:Label></td>
                    <td><asp:TextBox ID="txtContraseñaAnterior" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNuevaContraseña" runat="server" Text="Nueva Contraseña:"></asp:Label></td>
                    <td><asp:TextBox ID="txtNuevaContraseña" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn" OnClick="btnActualizar_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
    </asp:Panel>
</asp:Content>