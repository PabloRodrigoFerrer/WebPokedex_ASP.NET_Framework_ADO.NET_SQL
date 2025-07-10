<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="GenerarRemito.aspx.cs" Inherits="WebPokedex.GenerarRemito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Remito</h1>
    <h3>Entrega</h3>
    <hr />

    <asp:Label id="lblCarritoRemito" Text="text" runat="server" style="font-size: 1.5em; font-weight:bold ; color:black;"/>

    <asp:GridView id="dgvGenerarRemito" AutoGenerateColumns="false" CssClass="table table-striped" DataKeyNames="PokeId"  runat="server" 
        OnRowDataBound="dgvGenerarRemito_RowDataBound"
        OnRowDeleting="dgvGenerarRemito_RowDeleting">

        <Columns>
            <asp:BoundField DataField="PokeId" HeaderText="Id" />
            <asp:BoundField DataField="PokeName" HeaderText="Producto" />
            <asp:BoundField DataField="PokeTipo.Descripcion" HeaderText="Tipo" />
            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <asp:TextBox ID="txtCantidad" CssClass="form-control" AutoPostBack="true" runat="server" OnTextChanged="txtCantidad_TextChanged">
                        
                    </asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Quitar"/>
        </Columns>
    </asp:GridView>

    <asp:Button cssclass="btn btn-success" ID="btnEnviarRemito" onclick="btnEnviarRemito_Click" Text="Generar remito" runat="server" />


</asp:Content>
