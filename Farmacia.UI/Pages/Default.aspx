<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Farmacia.UI.Pages.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Página de Inicio</title>
<style type="text/css">
    /* Estilos personalizados */
    body {
        font-family: Arial, sans-serif;
        background-color: #f4f4f9;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
    }
    .login-container {
        background-color: #fff;
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        text-align: center;
    }
    .login-title {
        font-size: 24px;
        color: #0066CC;
        margin-bottom: 20px;
        text-decoration: underline;
    }
    .login-table {
        margin: 0 auto;
    }
    .login-table td {
        padding: 10px;
    }
    .login-table input[type="text"], .login-table input[type="password"] {
        width: 100%;
        padding: 8px;
        border: 1px solid #ddd;
        border-radius: 5px;
    }
    .login-button {
        background-color: #2ECC71;
        color: white;
        border: none;
        padding: 10px 20px;
        border-radius: 5px;
        cursor: pointer;
        font-size: 16px;
    }
    .login-button:hover {
        background-color: #27AE60;
    }
    .error-message {
        color: red;
        margin-top: 10px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-title"><strong>Farmacia Login</strong></div>
            <table class="login-table">
                <tr>
                    <td style="text-align: left;">Usuario:</td>
                    <td><asp:TextBox ID="TxtNomUsu" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: left;">Contraseña:</td>
                    <td><asp:TextBox ID="TxtPassUsu" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td colspan="2" style="text-align: right;">
                        <asp:Button ID="BtnLogueo" runat="server" Text="Login" CssClass="login-button" OnClick="BtnLogueo_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="LblError" runat="server" CssClass="error-message"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
