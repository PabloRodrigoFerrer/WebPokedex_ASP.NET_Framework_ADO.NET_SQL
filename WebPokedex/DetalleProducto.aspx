<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="WebPokedex.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalle</h1>

  
    <h2>Articulo</h2>
    <hr />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="d-flex flex-column flex-lg-row gap-xl">
                <div class="carousel-fixed">
                    <div id="carouselExampleIndicators" class="carousel carousel-fade  ">
                        <div class="carousel-indicators">
                            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                        </div>
                        <div class="carousel-inner  ">
                            <div class="carousel-item active">
                                <img src="<%: seleccionado.UrlImagen %>" class="d-block w-100 h-100 object-fit-cover" alt="...">
                            </div>
                            <div class="carousel-item">
                                <img src="https://www.svgrepo.com/show/508699/landscape-placeholder.svg" class="d-block w-100 h-100 object-fit-cover" alt="...">
                            </div>
                            <div class="carousel-item">
                                <img src="https://www.svgrepo.com/show/508699/landscape-placeholder.svg" class="d-block w-100 h-100 object-fit-cover" alt="...">
                            </div>
                        </div>
                        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Previous</span>
                        </button>
                        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="visually-hidden">Next</span>
                        </button>
                    </div>
                </div>
                <div>
                    <dl class="row">
                        <dt class="col-2">Codigo</dt>
                        <dd class="col-10 mb-4"><%: seleccionado.Numero  %></dd>
                        <dt class="col-sm-2">Nombre</dt>
                        <dd class="col-sm-10 mb-4"><%: seleccionado.Nombre  %></dd>
                        <dt class="col-sm-2">Descripcion</dt>
                        <dd class="col-sm-10 mb-4"><%: seleccionado.Descripcion  %></dd>
                        <dt class="col-sm-2">Tipo</dt>
                        <dd class="col-sm-10 mb-4"><%: seleccionado.Tipo.Descripcion  %></dd>
                        <dt class="col-sm-2">Stock</dt>
                        <dd class="col-sm-10 mb-4"><%: seleccionado.Cantidad  %></dd>
                        <dt class="col-sm-2">Precio</dt>
                        <dd class="col-sm-10 mb-4"><%: seleccionado.PrecioUnitario  %></dd>
                    </dl>
                    <div class="d-flex align-items-center">
                        <div class ="position-relative d-incline-block">
                            <a href="Default.aspx">Ir a productos</a>
                            <asp:Button ID="btnAgregarCarritoDetail" CssClass="btn btn-primary my-2 ms-3" OnClick="btnAgregarCarritoDetail_Click" Text="Agregar a carrito🛒" runat="server" />
                            <%if (WebPokedex.Helpers.CarritoHelper.estaEnCarrito(seleccionado.Id) && itemSeleccionado != null)
                              {%>
                                 <span class='position-absolute badge rounded-pill bg-danger' style="top: 0.0rem; right: 0rem; transform: translate(50%, 0%);">
                                    <%:itemSeleccionado.Cantidad.ToString() %>
                                 <span class='visually-hidden'>cantidad en carrito</span>
                                 </span> 
                               
                            <%}%>
                        </div>
                    </div>
                    <%if (WebPokedex.Helpers.CarritoHelper.estaEnCarrito(seleccionado.Id))
                      {%>
                          <span class='badge bg-success'>En carrito</span>
                    <%} %>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel> 

</asp:Content>
