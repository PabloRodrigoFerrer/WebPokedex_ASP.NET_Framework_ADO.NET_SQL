<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebPokedex.Loging" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
        

        <div class="col-4 mt-4">
            <h3 class="col-6 mb-2">Login usuario</h3>
            <div class="mb-3">
                <asp:Label Text="Usuario" runat="server" />
                <asp:TextBox runat="server" CssClass="form-control" placeholder="User o email" ID="txtLogDato" />
            </div>

            <div class="mb-3">
                <asp:Label Text="Contraseña" runat="server" />
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" placeholder="******" />
            </div>

            <%if (mostrarError)
                { %>
            <div class="mb-2">
                <p style="color: red">El usuario o la contraseña ingresada son invalidos.</p>
            </div>
            <%}%>

            <div class="d-flex align-items-center">
                <div class="mb-3">
                    <asp:Button Text="Ingresar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
                    <a href="Default.aspx">Regresar</a>
                </div>
            </div>
            <p>No tiene una <strong>cuenta</strong>? ir a <a style="color: dodgerblue" href="Registrarse.aspx">registrarse</a></p>
        </div>

    </div>

</asp:Content>
