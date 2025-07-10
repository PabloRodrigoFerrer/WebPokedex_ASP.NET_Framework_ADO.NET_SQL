<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="WebPokedex.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-5">
        <div class="mb-3 mt-3">
            <asp:Label runat="server">Email</asp:Label>
            <asp:TextBox TextMode="Email" ID="txtMailCliente" CssClass="form-control" runat="server" />
        </div>
        <div class ="mb-3">
            <asp:Label runat="server">Asunto</asp:Label>
            <asp:TextBox CssClass="form-control" ID="txtAsunto" runat="server" />
        </div>
        <div class ="mb-3">
            <asp:Label runat="server">Mensaje</asp:Label>
            <asp:TextBox TextMode="MultiLine" ID="txtMensaje" CssClass="form-control" runat="server" />
        </div>
        <asp:Button ID="btnEmail" CssClass="btn btn-primary" OnClick="btnEmail_Click" Text="Enviar" runat="server"/>
    </div>




</asp:Content>
