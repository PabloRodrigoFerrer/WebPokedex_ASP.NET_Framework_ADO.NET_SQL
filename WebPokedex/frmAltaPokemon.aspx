<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="frmAltaPokemon.aspx.cs" Inherits="WebPokedex.detallePokemon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2> Pagina detalle</h2>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Número</label>
                <asp:TextBox ID="txtNumero" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlTipo"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlDebilidad"></asp:DropDownList>
            </div>
            <div class ="mb-3">
                <asp:CheckBox Text="Activo" ID="chkAltaActivo" CssClass="form-check" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button CssClass="btn btn-primary" Text="Aceptar" ID="btnAltaAceptar" OnClick="btnAltaAceptar_Click" runat="server" />
                <a href="listaPokemons.aspx" class="btn btn-primary">Cancelar</a>
            </div>
        </div>    
        <div class="col-6">
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Url imagen</label>
                        <asp:TextBox ID="txtUrlImagen" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true" CssClass="form-control" TextMode="Url" runat="server"></asp:TextBox>
                    </div>

                    <asp:Image ID="imgAltaPoke" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
   </div>
    <div class="row">
        <div class="col-6">
            <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="btnEliminar" OnClick="btnEliminar_Click"  runat="server" />

        </div>
            
            <%if (baderaConfirmacionEliminar){ %>
                <div>
                    <asp:CheckBox Text="¿Eliminar permanentemente?" id="chkEliminarPermanente" Checked="false" runat="server" />
                    <asp:Button Text="Eliminar" id="btnConfirmarEliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminar_Click" runat="server" />
                </div>              
            <%} %>
            
    </div>
    
    
</asp:Content>
