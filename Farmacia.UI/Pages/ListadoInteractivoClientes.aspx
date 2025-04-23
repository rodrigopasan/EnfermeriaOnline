<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoInteractivoClientes.aspx.cs" Inherits="Farmacia.UI.Pages.ListadoInteractivoClientes" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        /* Estilos personalizados */
        .panel-clientes {
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

    <h2 class="welcome-message">Listado Interactivo de Clientes</h2>
    
    <asp:Panel ID="PanelClientes" runat="server" CssClass="panel-clientes">
        <fieldset>
            <legend>Buscar Clientes</legend>
            <asp:Label ID="lblBuscar" runat="server" Text="Buscar por CI o Nombre:"></asp:Label>
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" />
        </fieldset>
        <fieldset>
            <legend>Ordenar Clientes</legend>
            <asp:Label ID="lblOrdenarPor" runat="server" Text="Ordenar por:"></asp:Label>
            <asp:DropDownList ID="ddlOrdenarPor" runat="server">
                <asp:ListItem Text="CI" Value="CI" />
                <asp:ListItem Text="Nombre" Value="Nombre" />
                <asp:ListItem Text="Número" Value="Número" />
                <asp:ListItem Text="NumTarjeta" Value="NumTarjeta" />
                <asp:ListItem Text="Teléfono" Value="Teléfono" />
            </asp:DropDownList>
            <asp:Label ID="lblOrden" runat="server" Text="Orden:"></asp:Label>
            <asp:DropDownList ID="ddlOrden" runat="server">
                <asp:ListItem Text="Ascendente" Value="ASC" />
                <asp:ListItem Text="Descendente" Value="DESC" />
            </asp:DropDownList>
            <asp:Button ID="btnOrdenar" runat="server" Text="Ordenar" CssClass="btn" OnClick="btnOrdenar_Click" />
        </fieldset>
        <asp:Button ID="btnNuevoCliente" runat="server" Text="Nuevo Cliente" CssClass="btn" OnClick="btnNuevoCliente_Click" />
        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" DataKeyNames="CI" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvClientes_PageIndexChanging" OnRowEditing="gvClientes_RowEditing" OnRowDeleting="gvClientes_RowDeleting" OnRowCancelingEdit="gvClientes_RowCancelingEdit" OnRowUpdating="gvClientes_RowUpdating">
            <Columns>
                <asp:BoundField DataField="CI" HeaderText="CI" ReadOnly="True" />
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <%# Eval("Nombre") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Número">
                    <ItemTemplate>
                        <%# Eval("Número") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNumero" runat="server" Text='<%# Bind("Número") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NumTarjeta">
                    <ItemTemplate>
                        <%# Eval("NumTarjeta") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNumTarjeta" runat="server" Text='<%# Bind("NumTarjeta") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Teléfono">
                    <ItemTemplate>
                        <%# Eval("Teléfono") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTelefono" runat="server" Text='<%# Bind("Teléfono") %>' />
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
    </asp:Panel>
    <asp:Panel ID="PanelNuevoCliente" runat="server" Visible="false">
        <fieldset>
            <legend>Nuevo Cliente</legend>
            <asp:Label ID="lblCI" runat="server" Text="CI:"></asp:Label>
            <asp:TextBox ID="txtCI" runat="server"></asp:TextBox>
            <asp:Label ID="lblNombreNuevo" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombreNuevo" runat="server"></asp:TextBox>
            <asp:Label ID="lblNumero" runat="server" Text="Número:"></asp:Label>
            <asp:TextBox ID="txtNumeroNuevo" runat="server"></asp:TextBox>
            <asp:Label ID="lblNumTarjeta" runat="server" Text="NumTarjeta:"></asp:Label>
            <asp:TextBox ID="txtNumTarjetaNuevo" runat="server"></asp:TextBox>
            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
            <asp:TextBox ID="txtTelefonoNuevo" runat="server"></asp:TextBox>
            <asp:Button ID="btnGuardarNuevo" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardarNuevo_Click" />
            <asp:Button ID="btnCancelarNuevo" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelarNuevo_Click" />
        </fieldset>
    </asp:Panel>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</asp:Content>
