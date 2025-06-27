using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPokedex
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Pokemon> listaPokemons { get; set; }
        public List<Pokemon> listaPokeActivos;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocioPoke = new PokemonNegocio();
            Session["listaPokemons"] = negocioPoke.listarConSP();
            listaPokemons = (List<Pokemon>)Session["listaPokemons"];

            ElementoNegocio negocioElem = new ElementoNegocio();
            Session["listaElementos"] = negocioElem.listar();

            listaPokeActivos = listaPokemons.FindAll(x => x.Activo==true);

            

            if (!IsPostBack) 
            {
                repCards.DataSource = listaPokeActivos;
                repCards.DataBind();
            }
            
        }

        protected void btGuardarId_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Pokemon seleccionado = listaPokeActivos.Find(x => x.Id == int.Parse(id));

            List<Pokemon> favoritos;

            if (Session["listaFavoritos"] == null)
                favoritos = new List<Pokemon>();
            else
                favoritos = (List<Pokemon>)Session["listaFavoritos"];
            
            if(!favoritos.Any(x => x.Id == int.Parse(id)))
                favoritos.Add(seleccionado);

            Session["listaFavoritos"] = favoritos;
                        
           
        }
    }
}