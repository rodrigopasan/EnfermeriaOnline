<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Farmacia.UI.Pages.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        /* Estilos personalizados */
        .welcome-message {
            text-align: center;
            margin-top: 30px;
            font-size: 24px;
            color: #2C3E50;
        }
        .description {
            text-align: center;
            margin-top: 20px;
            font-size: 18px;
            color: #34495E;
        }
        .navigation-guide {
            text-align: left;
            margin: 20px 100px;
            font-size: 16px;
            color: #34495E;
        }
        .navigation-guide ul {
            list-style-type: none;
            padding: 0;
        }
        .navigation-guide li {
            margin-bottom: 10px;
        }
        .navigation-guide li a {
            color: #2ECC71;
            text-decoration: none;
        }
        .navigation-guide li a:hover {
            text-decoration: underline;
        }
        .image-container {
            text-align: center;
            margin-top: 30px;
        }
    </style>
    <div class="welcome-message">
        <asp:Label ID="LblBienvenida" runat="server" Text=""></asp:Label>
    </div>
    <div class="description">
        <p>Este sistema te permitirá gestionar de forma interactica artículos, clientes, ventas y consultas.</p>
    </div>
    
    <div class="image-container">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Farmacia.png" AlternateText="Farmacia" Width="500px" Height="400px" />
    </div>
        <div class="navigation-guide">
        <h2>Guía de Navegación</h2>
        <ul>
            <li><a href="AltaVenta.aspx">Alta de Venta</a>: Realiza la venta de un artículo seleccionando el cliente y la dirección de envío.</li>
            <li><a href="SeguimientoVenta.aspx">Seguimiento de Ventas</a>: Cambia el estado de las ventas y sigue el proceso desde "Armado" hasta "Entregado".</li>
            <li><a href="ListadoInteractivoArticulos.aspx">Artículos Interactivos</a>: Consulta y gestiona los artículos disponibles y sus ventas asociadas.</li>
            <li><a href="ListadoInteractivoClientes.aspx">Clientes Interactivos</a>: Consulta y gestiona la información de los clientes y sus compras.</li>
            <li><a href="ABMCategorias.aspx">Alta de Categorías</a>: Gestiona las categorías de los artículos.</li>
            <li><a href="MisDatos.aspx">Modificar Datos</a>: Cambia datos del usuario.</li>
        </ul>
    </div>
</asp:Content>
