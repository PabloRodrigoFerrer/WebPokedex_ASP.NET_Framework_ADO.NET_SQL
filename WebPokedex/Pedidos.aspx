<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="WebPokedex.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Pedidos</h1>
    <h3>Detalle</h3>
    <hr />

   <%if(!WebPokedex.UserManager.isAdmin)
     {%>

        <asp:GridView ID="dgvPedidos" CssClass="table" AutoGenerateColumns="false" runat="server" DataKeyNames="IdPedido" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="IdCliente" HeaderText="Id Cliente"  />
                <asp:BoundField DataField="FechaPedido" HeaderText="Fecha Pedido" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                <asp:BoundField DataField="TotalPedido" HeaderText="Total" DataFormatString="{0:C}" />
                <asp:BoundField DataField="CantidadTotal" HeaderText="Cantidad Total"/>
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Ver detalle" />
                
            </Columns>


        </asp:GridView>


   <%}
    else
    {%>
         <asp:GridView ID="dgvPedidosAdmin" CssClass="table" AutoGenerateColumns="false" runat="server" DataKeyNames="IdPedido"
             OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged"
             OnRowCommand="dgvPedidosAdmin_RowCommand">
             <Columns>
                 <asp:BoundField DataField="IdCliente" HeaderText="Id Cliente"  />
                 <asp:BoundField DataField="FechaPedido" HeaderText="Fecha Pedido" />
                 <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                 <asp:BoundField DataField="TotalPedido" HeaderText="Total" DataFormatString="{0:C}" />
                 <asp:BoundField DataField="CantidadTotal" HeaderText="Cantidad Total"/>
                 <asp:BoundField DataField="Estado" HeaderText="Estado" />
               
                <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Ver detalle" />
                
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:LinkButton id="btnGenerarRemito" CommandName="GenerarRemito" CommandArgument=<%# Eval("IdPedido")%> Text="Gererar remito" runat="server" />
                         <asp:LinkButton id="btnVerDetalleRemito" CommandName="VerDetalleRemito" CommandArgument="<%# Eval("IdPedido") %>" Text="Detalle remito" runat="server" />
                     </ItemTemplate>
                 </asp:TemplateField>

              
             </Columns>


         </asp:GridView>


  <%}%>

</asp:Content>
