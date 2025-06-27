<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebPokedex.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Pokemon tengo que atraparlo🪝..</h2>
    <br />

 <%--   <%foreach (dominio.Pokemon poke in listaPokemons)
      {
    %>        
            <div class="col">
                <div class="card">
                    <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"> <%: poke.Nombre%> </h5>
                        <p class="card-text"><%: poke.Descripcion %></p>
                        <a href="detallePokemon.aspx?id= <%: poke.Id %>">Ver detalle</a>
                    </div>
                </div>
            </div>
   <% } %>--%>
    

      <%--listar con repeater--%>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repCards" runat="server">
            <ItemTemplate>

                <div class="col">
                    <div class="card">
                        <img src="<%# Eval("UrlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre")%> </h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <a href="detallePokemon.aspx?id= <%# Eval("Id") %>">Ver detalle</a>
                            <asp:Button CssClass="btn btn-primary" Text="Guardar" runat="server" ID="btGuardarId" CommandArgument='<%#Eval("Id")%>' CommandName="PokemonID" OnClick="btGuardarId_Click" />
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
