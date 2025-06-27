<%@ Page Title="ListaPokemons" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="listaPokemons.aspx.cs" Inherits="WebPokedex.listaPokemons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Acá va la lista </h2>

    <div class="d-flex col-6 align-items-center mt-3">
        <asp:TextBox runat="server" id="txtFiltroRapido" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control" placeholder="filtrar"/>
        <asp:CheckBox Text="Filtro avanzado" CssClass="ms-2 form-check-input text-nowrap" runat="server" id ="cbxFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="cbxFiltroAvanzado_CheckedChanged"/>
    </div>

    <%if (cbxFiltroAvanzado.Checked)
        {%>
                <div class ="row mt-4 mb-4">
                    <div class ="d-flex col-9 align-items-center">
                        <label>Campo: </label>
                        <asp:DropDownList runat="server" ID="ddlCampo" CssClass="ms-2 form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Número"/>
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                        
                        </asp:DropDownList>
                        <label class="ms-2">Criterio: </label>
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="ms-2 form-select">
                            
                            
                        </asp:DropDownList>
                        <label class="ms-2">Filtro: </label>
                        <asp:TextBox runat="server" id ="txtFiltro" CssClass="ms-2 form-control"/>

                        <asp:DropDownList runat="server" ID="ddlActivo" CssClass="ms-2 form-select">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>

                        <asp:Button Text="Buscar" CssClass="ms-2 btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
                    </div>

                </div>   

           <% } %>



    <asp:GridView ID="dgvPokemons" runat="server" CssClass="mt-2 table" AutoGenerateColumns="false" DataKeyNames="Id"
        OnSelectedIndexChanged ="dgvPokemons_SelectedIndexChanged"
        OnPageIndexChanging ="dgvPokemons_PageIndexChanging"
        AllowPaging="true" PageSize="3">
        
        <Columns>
            <asp:BoundField HeaderText ="Nombre"  DataField="Nombre" />
            <asp:BoundField HeaderText="Número" DataField="Numero" />               
            <asp:BoundField HeaderText ="Tipo"  DataField="Tipo.Descripcion" />
            <asp:CheckBoxField HeaderText ="Activo" DataField="Activo" />
            <asp:CommandField ShowSelectButton="true" HeaderText="Acción" SelectText="Modificar🔄️" />
        </Columns>    
    </asp:GridView>
    <a href="frmAltaPokemon.aspx" class="btn btn-primary">Agregar</a>
        

</asp:Content>



