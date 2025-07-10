<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="PedidosDetalle.aspx.cs" Inherits="WebPokedex.PedidosDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Detalle</h1>
    <h3>Compra</h3>
    <hr />

    <asp:GridView ID="dgvPedidosDetalle" CssClass="table table-striped" AutoGenerateColumns="false" runat="server" >
        <Columns>
            <asp:BoundField DataField="IdPedido" HeaderText="Id Pedido"  />
            <asp:BoundField DataField="PokeId" HeaderText="Id Producto" />
            <asp:BoundField DataField="PokeName" HeaderText="Nombre Prodcuto" />
            <asp:BoundField DataField="PokeTipo.Descripcion" HeaderText="Color" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"/>
            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
            <asp:BoundField DataField="SubTotal" HeaderText="Sub Total" DataFormatString ="{0:C}" />
        </Columns>


    </asp:GridView>

    <a class="mt-3" href="Pedidos.aspx">Volver a mis pedidos</a>
    

</asp:Content>
