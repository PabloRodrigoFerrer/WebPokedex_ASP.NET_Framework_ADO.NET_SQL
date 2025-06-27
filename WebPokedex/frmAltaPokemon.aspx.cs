using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace WebPokedex
{
    public partial class detallePokemon : System.Web.UI.Page
    {
        public bool baderaConfirmacionEliminar { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            if (!IsPostBack)
            {
                baderaConfirmacionEliminar = false;
                ddlDebilidad.DataSource = Session["listaElementos"];
                ddlDebilidad.DataValueField = "Id";
                ddlDebilidad.DataTextField = "Descripcion";                
                ddlDebilidad.DataBind();

                ddlTipo.DataSource = Session["listaElementos"];
                ddlTipo.DataValueField = "Id";
                ddlTipo.DataTextField = "Descripcion";
                ddlTipo.DataBind();
                CargarImagen();

                //Configuración modificar

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Pokemon seleccionado = ((List<Pokemon>)Session["listaPokemons"]).Find(x => x.Id == id);

                    txtNombre.Text = seleccionado.Nombre;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtUrlImagen.Text = seleccionado.UrlImagen;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    chkAltaActivo.Checked = seleccionado.Activo;
                    imgAltaPoke.ImageUrl = txtUrlImagen.Text;
                }
            }
        }

        protected void btnAltaAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Configuración inicial de alta...
                PokemonNegocio pokemonNegocio = new PokemonNegocio();
                Pokemon nuevo = new Pokemon();

                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtUrlImagen.Text;
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Activo = chkAltaActivo.Checked;


                //configuración modificar...

                string id = Request.QueryString["id"] == null? "": Request.QueryString["id"].ToString();
                if (id != "") 
                {
                    nuevo.Id = int.Parse(id);
                    pokemonNegocio.modificarConSP(nuevo);
                }
                else 
                {
                    pokemonNegocio.agregarConSp(nuevo);
                }
                
                Response.Redirect("listaPokemons.aspx");
            }

            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }


        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            CargarImagen();
        }

        private void CargarImagen() 
        {
            if(txtUrlImagen.Text == "") 
            {
                imgAltaPoke.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRjt-ewgNomB7qqJH9Hn5VxQsnOgH_rRb2u9Q&s";

            }
            else {
                imgAltaPoke.ImageUrl = txtUrlImagen.Text;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            baderaConfirmacionEliminar = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                if (chkEliminarPermanente.Checked)
                {
                    negocio.eliminar(int.Parse(Request.QueryString["id"]));
                    Response.Redirect("listaPokemons.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}