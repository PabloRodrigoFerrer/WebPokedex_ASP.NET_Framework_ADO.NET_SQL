<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebPokedex.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between mb-3">
        <h3>Mi Carrito</h3>
        <div style="text-align: right;">
            <h5>Total compra</h5>
            <asp:Label Style="font-size: 1.5em; font-weight: bold; color:black;" ID="lblTotal" Text="text" runat="server" />
        </div>
    </div>

    <asp:GridView CssClass="table table-striped mb-3" ID="dgvCarrito" runat="server" AutoGenerateColumns="False" DataKeyNames="PokeId"
        OnRowDeleting="dgvCarrito_RowDeleting"
        OnRowDataBound="dgvCarrito_RowDataBound">
    <Columns>
        <asp:BoundField DataField="PokeId" HeaderText="Id" />
        <asp:BoundField DataField="PokeName" HeaderText="Producto" />
        <asp:BoundField DataField="PokeTipo.Descripcion" HeaderText="Tipo" />
        <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" DataFormatString="{0:C}" />
        <asp:TemplateField HeaderText="Cantidad">
            <ItemTemplate>
                <asp:DropDownList ID="ddlTipo" CssClass="col-2 form-select" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                </asp:DropDownList>
            </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField HeaderText="Cantidad">
            <ItemTemplate>
                <asp:DropDownList ID="ddlCantidad" CssClass="col-2 form-select" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged">
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
        <asp:CommandField ShowDeleteButton="True" DeleteText="Quitar" />
    </Columns>
    </asp:GridView>
    <div class="aling items-center" >
        <asp:Button CssClass="btn btn-success me-3" ID="btnPedir" runat="server" Text="Enviar pedido" OnClick="btnPedir_Click" />
        <a href="Default.aspx">Ir a productos</a>
    </div>
     <asp:LinkButton CssClass="btn btn-outline-danger my-3" ID="btnBorrarCarrito" OnClick="btnBorrarCarrito_Click" runat="server" ToolTip="Eliminar del carrito">
        <i class="bi bi-trash"></i>
    </asp:LinkButton>


    
</asp:Content>
