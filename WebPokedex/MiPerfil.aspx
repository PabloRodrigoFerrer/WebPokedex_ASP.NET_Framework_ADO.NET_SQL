<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="WebPokedex.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Mi perfil</h3>

  <div class ="d-flex mt-3"> 
    <div class="col-4">
        <div class="mb-3">
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="txtPerfilEmail" TextMode="Email" ReadOnly="true" CssClass="form-control" runat="server" />
        </div>
        <div class="mb-3">
            <asp:Label Text="Nombre" runat="server" />
            <asp:TextBox ID="txtPerfilNombre" CssClass="form-control" runat="server" />
        </div>
        <div class="mb-3">
            <asp:Label Text="Apellido" runat="server" />
            <asp:TextBox ID="txtPerfilApellido" CssClass="form-control" runat="server" />
        </div>
         <div class="mb-3">
             <asp:Label Text="Genero" runat="server" />
             <asp:DropDownList ID="txtPerfilGenero" CssClass="form-select" runat="server">
                 <asp:ListItem Text="--Seleccionar--"/>
                 <asp:ListItem Text="Masculino" />
                 <asp:ListItem Text="Femenino" />
             </asp:DropDownList>
         </div>
        <div class="mb-3">
            <asp:Label Text="Fecha Nacimiento" runat="server" />
            <asp:TextBox ID="txtPerfilFecha" TextMode="Date" CssClass="form-control" runat="server" />         
        </div>
    </div>

    <div class="col-6 ms-5">
        <div class="mb-3">
            <asp:FileUpload  ID="txtImageFile" runat="server" />
        </div>
        <div  >
            <asp:Image ID="imgPerfil" Width="500px" Height="450px" runat="server" />                
        </div>
    </div>
  </div>

    <div class ="mt-4">
        <asp:Button ID="btnPerfilGuardar" onclick="btnPerfilGuardar_Click" Text="Guardar" CssClass="btn btn-primary" runat="server" />
        <a class="ms-2" href="Default.aspx">Regresar</a>
    </div>

</asp:Content>
