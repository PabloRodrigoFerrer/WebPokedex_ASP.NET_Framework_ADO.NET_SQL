using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPokedex.Helpers;

namespace WebPokedex
{
    public partial class Default : System.Web.UI.Page
    {

        private Mi MasterPage 
        {
            get { return (Mi)this.Master; }
        }
        
        
        public List<Pokemon> listaPokemons { get; set; }
        public List<Pokemon> listaPokeActivos { get; set; }

        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocioPoke = new PokemonNegocio();
            Session["listaPokemons"] = negocioPoke.listarConSP();
            listaPokemons = (List<Pokemon>)Session["listaPokemons"];

            ElementoNegocio negocioElem = new ElementoNegocio();
            Session["listaElementos"] = negocioElem.listar();

            listaPokeActivos = listaPokemons.FindAll(x => x.Activo==true);


            
            MasterPage.BuscarYFiltrar += Master_BuscarYFiltrar;

            

            if (!IsPostBack) 
            {
                Session.Remove("ListaFiltrada");
                repCards.DataSource = listaPokeActivos;
                repCards.DataBind();

                
            }
            
        }

        private void Master_BuscarYFiltrar(object sender, EventArgs e)
        {
            
            string buscar = MasterPage.TextoBuscado;

            listaPokeActivos = listaPokeActivos.FindAll(x => x.Nombre.ToLower().Contains(buscar.ToLower()));
            Session["ListaFiltrada"] = listaPokeActivos;
            repCards.DataSource = listaPokeActivos;
            repCards.DataBind();
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

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Pokemon seleccionado = listaPokeActivos.Find(x => x.Id == int.Parse(id));

            var existente = CarritoHelper.itemExistente(seleccionado);

            if(existente != null)
            {
                if(existente.Cantidad < existente.CantidadMax)
                    CarritoHelper.AgregarCarrito(existente);
            }
            else
            {
                var item = CarritoHelper.mapPokeACarrito(seleccionado);
                CarritoHelper.AgregarCarrito(item);    
            }

            //bindeamos repCard para actualizar la label de encarrito...
            if (Session["ListaFiltrada"] != null)
            {
                repCards.DataSource = Session["ListaFiltrada"] as List<Pokemon>;
                repCards.DataBind();
            }
            else
            {
                repCards.DataSource = listaPokeActivos;
                repCards.DataBind();
            }

            //actualizamos pestaña carrito(si es necesario)
            var master = this.Master as Mi;
            if (master != null)
            {
                master.PanelNavCarrito.Update();
            }


        }

        public string MostrarEtiquetaBtnAgregarCarrito(int id)
        {
            var item = CarritoHelper.obtenerItemDeCarrito(id);
            
            return WebPokedex.Helpers.CarritoHelper.estaEnCarrito(id)
                ? $@"<span class='position-absolute translate-middle badge rounded-pill bg-danger'>
                     {item.Cantidad}
                     <span class='visually-hidden'>cantidad en carrito</span>
                     </span>": "";
        }

        public string MostrarEtiquetaCarrito(int id)
        {          
            return WebPokedex.Helpers.CarritoHelper.estaEnCarrito(id)
                ? "<span class='badge bg-success'>En carrito</span>": "";
        }


        protected void btnFiltrarAgua_Click(object sender, EventArgs e)
        {
            List<Pokemon> filtroAgua = listaPokeActivos.FindAll(x => x.Tipo.Descripcion == "Agua");
            Session["ListaFiltrada"] = filtroAgua;
            repCards.DataSource = filtroAgua;
            repCards.DataBind();
            
        }

        protected void btnFiltrarFuego_Click(object sender, EventArgs e)
        {
            List<Pokemon> filtroFuego = listaPokeActivos.FindAll(x => x.Tipo.Descripcion == "Fuego");
            Session["ListaFiltrada"] = filtroFuego;
            repCards.DataSource = filtroFuego;
            repCards.DataBind();
        }

        protected void btnFiltrarPlanta_Click(object sender, EventArgs e)
        {
            List<Pokemon> filtroPlanta = listaPokeActivos.FindAll(x => x.Tipo.Descripcion == "Planta");
            Session["ListaFiltrada"] = filtroPlanta;
            repCards.DataSource = filtroPlanta;
            repCards.DataBind();
        }

        protected void btnFiltrarTodos_Click(object sender, EventArgs e)
        {
            Session.Remove("ListaFiltrada");
            repCards.DataSource = listaPokeActivos;
            repCards.DataBind();
        }
    }
}