<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="WebPokedex.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Favoritos..</h3>

    <%if (Session["listaFavoritos"] != null)
      {%>
            <div class="row row-cols-1 row-cols-md-4 g-3">
            <%foreach (dominio.Pokemon poke in (List<dominio.Pokemon>)Session["listaFavoritos"])
                {
            %>     
                    <div class="col">
                        <div class="card" style="width: 18rem;">
                            <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"> <%: poke.Nombre%> </h5>
                                <p class="card-text"><%: poke.Descripcion %></p>
                                <a href="detalleProducto.aspx?id= <%: poke.Id %>">Ver detalle</a>
                            </div>
                        </div>
                    </div>
           <% } %>
            </div>
    <%}
      else
      {%>
         <h3 class="mt-5">No hay favoritos aún...</h3>
      <%}%>
</asp:Content>
