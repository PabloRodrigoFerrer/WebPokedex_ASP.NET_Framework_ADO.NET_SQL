<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPokedex.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Pokemon tengo que atraparlo🪝..</h2>
    <br />
    <div class="d-flex flex-wrap gap-4 justify-content-center my-5">
        <asp:button id="btnFiltrarAgua" Text="Agua" runat="server" class="btn btn-outline-secondary py-3 px-5" onclick="btnFiltrarAgua_Click"/>
        <asp:button id="btnFiltrarFuego" Text="Fuego" runat="server" class="btn btn-outline-secondary py-3 px-5" onclick="btnFiltrarFuego_Click"/>
        <asp:button id="btnFiltrarPlanta" Text="Planta" runat="server" class="btn btn-outline-secondary py-3 px-5" onclick="btnFiltrarPlanta_Click"/>
        <asp:button id="btnFiltrarTodos" Text="Todos" runat="server" class="btn btn-outline-secondary py-3 px-5" onclick="btnFiltrarTodos_Click"/>
    </div>


<%--    <%foreach (dominio.Pokemon poke in listaPokeActivos)
      {
    %>        
            <div class="col">
                <div class="card">
                    <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"> <%: poke.Nombre%> </h5>
                        <p class="card-text"><%: poke.Descripcion %></p>
                        <a href="detallePokemon.aspx?id= <%: poke.Id %>">Ver detalle</a>
                        <%if (WebPokedex.Helpers.CarritoHelper.estaEnCarrito(poke.Id)) { } %>
                    </div>
                </div>
            </div>
   <% } %>--%>
    

      <%--listar con repeater--%>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater ID="repCards" runat="server">
                    <ItemTemplate>

                        <div class="col">
                            <div class="card">
                                <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="...">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Nombre")%> </h5>
                                    <h3 class="card-title"><%# Eval("PrecioUnitario")%> </h3>
                                    <p class="card-text"><%# Eval("Descripcion") %></p>
                                    <a href="DetalleProducto.aspx?id= <%# Eval("Id") %>">Ver detalle</a>
                                    <asp:Button CssClass="btn btn-secondary" Text="Favorito" runat="server" ID="btGuardarId" CommandArgument='<%#Eval("Id")%>' CommandName="PokemonID" OnClick="btGuardarId_Click" />
                                    <span class ="position-relative d-incline-block">
                                        <asp:Button CssClass="btn btn-primary" Text="Agregar a carrito🛒" runat="server" ID="btnAgregarCarrito" CommandArgument='<%#Eval("Id")%>' CommandName="PokemonID" OnClick="btnAgregarCarrito_Click" />                                        
                                          <%#MostrarEtiquetaBtnAgregarCarrito((int)Eval("Id")) %>
                                    </span>
                                    <%# MostrarEtiquetaCarrito((int)Eval("Id")) %>
                                    
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
