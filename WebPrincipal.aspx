<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="WebPrincipal.aspx.cs" Inherits="Restaurante_Web.WebPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_cabecera" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_mensaje" runat="server">
    <asp:ScriptManager ID="scm" runat="server"></asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenido" runat="server">
    <asp:UpdatePanel ID="udp" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:HiddenField ID="hdf" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="80%">
                            <tr>
                                <td align="center" colspan="2">
                                    <h3><strong>Registro de Usuarios</strong></h3>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 60px">
                                    <asp:Label ID="lblUsu" runat="server" Text="Usuario"></asp:Label>
                                </td>
                                <td style="height: 60px" colspan="2">
                                    <asp:TextBox ID="txtUsu" runat="server" ToolTip="Ingrese el Usuario"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 60px">
                                    <asp:Label ID="lblPass" runat="server" Text="Contraseña"></asp:Label>
                                </td>
                                <td style="height: 60px" colspan="2">
                                    <asp:TextBox ID="txtPass" runat="server" ToolTip="Ingrese una Contraseña"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 60px">
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
                                </td>
                                <td style="height: 60px" colspan="2">
                                    <asp:TextBox ID="txtTipo" runat="server" ToolTip="Ingrese el tipo de Usuario"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="height: 60px">
                                    <asp:Label ID="lblFecha" runat="server" Text="Fecha Registro"></asp:Label>
                                </td>
                                <td style="height: 60px" colspan="2">
                                    <asp:TextBox ID="txtFecha" runat="server" Enabled="false" ToolTip="Ingrese la Fecha"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" runat="server" Text="Guardar" />
                                    &nbsp;<asp:Button ID="btnEliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('Está seguro que desea eliminar este registro?')" Enabled="false" CssClass="btn btn-danger" runat="server" Text="Eliminar" />
                                    &nbsp;<asp:Button ID="btnLimpiar" OnClick="btnLimpiar_Click" CssClass="btn btn-warning" runat="server" Text="Limpiar" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="height: 50px">
                                    <asp:Label ID="lblMensaje" ForeColor="Green" CssClass="label animated shake auto-style1" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="height: 50px">
                                    <asp:Label ID="lblError" ForeColor="Red" CssClass="label animated shake auto-style1" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grvUsuarios" runat="server" OnRowCommand="grvUsuarios_RowCommand" CssClass="table table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="IdUsuario" HeaderText="#" />
                                <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre" />
                                <asp:BoundField DataField="PasswUsuario" HeaderText="Contraseña" />
                                <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo de Usuario" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnSeleccionar" CommandName="Seleccionar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-info btn-sm" runat="server" Text="Seleccione" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>

            <br />

            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:HiddenField ID="hdf1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="80%">
                            <tr>
                                <td align="center" colspan="2">
                                    <h3><strong>Registro de Platos</strong></h3>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 60px">
                                    <asp:Label ID="lblNomPlato" runat="server" Text="Plato"></asp:Label>
                                </td>
                                <td style="height: 60px" colspan="2">
                                    <asp:TextBox ID="txtNomPlato" runat="server" ToolTip="Ingrese el Nombre del Plato"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 60px">
                                    <asp:Label ID="lblPrecPlato" runat="server" Text="Precio"></asp:Label>
                                </td>
                                <td style="height: 60px" colspan="2">
                                    <asp:TextBox ID="txtPrecPlato" runat="server" ToolTip="Ingrese el Precio del Plato"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 60px">
                                    <asp:Label ID="lblTipoPlato" runat="server" Text="Categoría"></asp:Label>
                                </td>
                                <td style="height: 60px" colspan="2">
                                    <asp:TextBox ID="txtTipoPlato" runat="server" ToolTip="Ingrese el tipo de Plato"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnGuardarPlato" OnClick="btnGuardarPlato_Click" CssClass="btn btn-success" runat="server" Text="Guardar" />
                                    &nbsp;<asp:Button ID="btnEliminarPlato" OnClick="btnEliminarPlato_Click" OnClientClick="return confirm('Está seguro que desea eliminar este registro?')" Enabled="false" CssClass="btn btn-danger" runat="server" Text="Eliminar" />
                                    &nbsp;<asp:Button ID="btnLimpiarPlato" OnClick="btnLimpiarPlato_Click" CssClass="btn btn-warning" runat="server" Text="Limpiar" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="height: 50px">
                                    <asp:Label ID="lblMensaje1" ForeColor="Green" CssClass="label animated shake auto-style1" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="height: 50px">
                                    <asp:Label ID="lblError1" ForeColor="Red" CssClass="label animated shake auto-style1" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grvPlatos" runat="server" OnRowCommand="grvPlatos_RowCommand" CssClass="table table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="IdPlato" HeaderText="#" />
                                <asp:BoundField DataField="NombrePlato" HeaderText="Plato" />
                                <asp:BoundField DataField="PrecioPlato" HeaderText="Precio" />
                                <asp:BoundField DataField="TipoPlato" HeaderText="Categoría" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnSeleccionar" CommandName="Seleccionar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-info btn-sm" runat="server" Text="Seleccione" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

