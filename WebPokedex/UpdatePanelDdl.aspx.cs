using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPokedex
{
    public partial class UpdatePanelDdl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
           

            if (!IsPostBack)
            {
                PokemonNegocio listaPokemons = new PokemonNegocio();
                ElementoNegocio negocioElemento = new ElementoNegocio();
                Session["listaPokemons"] = listaPokemons.listarConSP();
                Session["listaElementos"] = negocioElemento.listar();

                ddlTipo.DataSource = negocioElemento.listar();
                ddlTipo.DataValueField = "Id";
                ddlTipo.DataTextField = "Descripcion";
                ddlTipo.DataBind();


                ddlPreseleccionado.DataSource = Session["listaElementos"];
                ddlPreseleccionado.DataValueField = "Id";
                ddlPreseleccionado.DataTextField = "Descripcion";
                ddlPreseleccionado.DataBind();

            }
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlTipo.SelectedItem.Value);
            ddlFiltrado.DataSource = ((List<Pokemon>)Session["listaPokemons"]).FindAll(x => x.Tipo.Id == id);
            ddlFiltrado.DataValueField = "Id";
            ddlFiltrado.DataTextField = "Nombre";
            ddlFiltrado.DataBind();
            
        }

        protected void btnPreseleccionAceptar_Click(object sender, EventArgs e)
        {
            //cargar el ddlTipo según el id 


            // opción 2 un poco más complicad para mi.
            // ddlPreseleccionado.SelectedIndex = ddlPreseleccionado.Items.IndexOf(ddlPreseleccionado.Items.FindByValue(txtId.Text));

            //opcion 1 más clara para mi
            if (EsNumero(txtId.Text))
            {
                if(int.Parse(txtId.Text) < ((List<Elemento>)Session["listaElementos"]).Count()) 
                {
                    ddlPreseleccionado.SelectedIndex = -1;
                    ddlPreseleccionado.Items.FindByValue(txtId.Text).Selected = true;
                }
            }
            else
            {
                return;
            }
        }
        
        private bool EsNumero(string s) 
        {
            foreach (char caracter in s)
            {
                if (!char.IsDigit(caracter))
                    return false;
            }
                    
             return true;
        }


    }
}