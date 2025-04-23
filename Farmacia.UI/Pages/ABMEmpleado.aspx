<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMEmpleado.aspx.cs" Inherits="Farmacia.UI.Pages.ABMEmpleado" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .panel-empleados {
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

    <h2 class="welcome-message">Administración de Empleados</h2>
    
    <asp:Panel ID="PanelEmpleados" runat="server" CssClass="panel-empleados">
        <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="false" DataKeyNames="Usuario" OnRowEditing="gvEmpleados_RowEditing" OnRowDeleting="gvEmpleados_RowDeleting" OnRowCancelingEdit="gvEmpleados_RowCancelingEdit" OnRowUpdating="gvEmpleados_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" ReadOnly="True" />
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <%# Eval("Nombre") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contraseña">
                    <ItemTemplate>
                        *****
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" Text='<%# Bind("Contraseña") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Edit" Text="Editar" CssClass="btn" />
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Delete" Text="Eliminar" CssClass="btn" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkActualizar" runat="server" CommandName="Update" Text="Actualizar" CssClass="btn" />
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="lnkCancelar" runat="server" CommandName="Cancel" Text="Cancelar" CssClass="btn" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCrearNuevoEmpleado" runat="server" Text="Crear Nuevo Empleado" CssClass="btn" OnClick="btnCrearNuevoEmpleado_Click" />
    </asp:Panel>
    <asp:Panel ID="PanelCrearEmpleado" runat="server" CssClass="panel-empleados" Visible="false">
        <fieldset>
            <legend>Datos del Empleado</legend>
            <table>
                <tr>
                    <td><asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label></td>
                    <td><asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label></td>
                    <td><asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
                    <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelarCreacion" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelarCreacion_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</asp:Content>