using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPokedex.Helpers;

namespace WebPokedex
{
    public partial class DetalleProducto : System.Web.UI.Page
    {   
        private Mi masterPage
        {
            get { return (Mi)this.Master; }
        }

        public Pokemon seleccionado { get; set; }
        public CarritoItem itemSeleccionado
        { 
            get
            {
                if (CarritoHelper.estaEnCarrito(seleccionado.Id))
                {
                    return CarritoHelper.obtenerItemDeCarrito(seleccionado.Id);
                }
                else
                {
                    return null;
                }; 
            
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"]!= null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                List<Pokemon> listaPokemonActivos = ((List<Pokemon>)Session["listaPokemons"]).FindAll(x => x.Activo == true);
                seleccionado = listaPokemonActivos.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnAgregarCarritoDetail_Click(object sender, EventArgs e)
        {             
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

            masterPage.PanelNavCarrito.Update();
        }
    }
}