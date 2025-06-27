<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="WebPokedex.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Registro</h3>   

    <div class="col-4 mt-4">
        <div class ="mb-3">
            <asp:Label Text="Dirección Email" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" placeholder="Email@ejemplo.com" ID="txtLogDato"/>
        </div>
        <div class="mb-3">
            <asp:Label Text="Contraseña" runat="server" />
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" placeholder="******"/>
        </div>
        <div class="d-flex align-items-center">
            <asp:Button Text="Registrarse" runat="server" id="btnRegistrase" Onclick="btnRegistrase_Click" CssClass="btn btn-primary"/>
            <a class="ms-2" href="Default.aspx">Cancelar</a>   
        </div>
    </div>
</asp:Content>
