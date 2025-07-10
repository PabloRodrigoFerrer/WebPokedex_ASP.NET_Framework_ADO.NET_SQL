<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="UpdatePanelDdl.aspx.cs" Inherits="WebPokedex.UpdatePanelDdl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager id="scriptmanager1" runat="server" /> 

    <h2>DropDown list enlazado + UpdatePanel</h2>
   
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row mb-4">
                <div class="col">
                    <asp:DropDownList ID="ddlTipo" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" runat="server"></asp:DropDownList>
                </div>
                <div class="col">
                    <asp:DropDownList ID="ddlFiltrado" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="row mt-5">
        <div class ="col">
            <asp:Label Text="ID" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtId" runat="server"></asp:TextBox>
        </div>
        <div class="col">
            <asp:Label Text="tipo preseleccionado" runat="server" />
            <asp:DropDownList CssClass="form-select" ID="ddlPreseleccionado" runat="server"></asp:DropDownList>

        </div>

    </div>
    <asp:Button CssClass="btn btn-primary mt-3" Text="Aceptar" runat="server" id ="btnPreseleccionAceptar" onclick="btnPreseleccionAceptar_Click" />
</asp:Content>


