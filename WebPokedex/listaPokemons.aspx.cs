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
    public partial class listaPokemons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!cbxFiltroAvanzado.Checked)
            {
                cargarDatos();
            }
            else if (cbxFiltroAvanzado.Checked && !camposCompletos())
            {
                cargarDatos();
            }
            

            if (UserManager.CurrentUser == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            else if (!UserManager.isAdmin)
            {
                Response.Redirect("soloAdmin.aspx");
                return;
            }
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("frmAltaPokemon.aspx?id=" + id);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            if(cbxFiltroAvanzado.Checked && camposCompletos())
                btnBuscar_Click(null, EventArgs.Empty);
            dgvPokemons.DataBind(); 
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada = (List<Pokemon>)Session["listaPokemons"];
            
            listaFiltrada = listaFiltrada.FindAll(x => x.Nombre.ToLower().Contains(txtFiltroRapido.Text.ToLower()));

            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();

            if (string.IsNullOrEmpty(txtFiltroRapido.Text))
            {
                dgvPokemons.DataSource = Session["listaPokemons"];
                dgvPokemons.DataBind();
            }
        }

        protected void cbxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltroRapido.Enabled = cbxFiltroAvanzado.Checked ? false : true;
            ddlCriterio.Items.Clear();
            ddlCampo_SelectedIndexChanged(ddlCampo, EventArgs.Empty);
            
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlCriterio.Items.Clear();
            switch (ddlCampo.SelectedItem.ToString())
            {
                case "Número":
                    ddlCriterio.Items.Add("Mayor que");
                    ddlCriterio.Items.Add("Menor que");
                    ddlCriterio.Items.Add("Igual que");
                    break;

                default:
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Empieza con");
                    ddlCriterio.Items.Add("Termina con");
                    break;
            }          
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();

            //validar que los campos esten completos y checkfiltro avanzado activo
            if (camposCompletos())
            {
                dgvPokemons.DataSource = negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltro.Text.ToString(),
                    ddlActivo.SelectedItem.ToString()
                    );
            }
            dgvPokemons.DataBind();
        }

        //validamos campos completos
        private bool camposCompletos()
        {   
            if(ddlCampo.SelectedItem != null && ddlCriterio.SelectedItem != null && ddlActivo.SelectedItem != null)
            {
                if(string.IsNullOrWhiteSpace(ddlCampo.SelectedItem.Value.ToString()) || string.IsNullOrWhiteSpace(ddlCriterio.SelectedItem.Value.ToString()) || string.IsNullOrWhiteSpace(txtFiltro.Text.ToString()) || string.IsNullOrEmpty(ddlActivo.SelectedItem.Value.ToString()))
                    return false;
            }
            return true;
            
        }

        //carga de datos y bindeo a tabla
        private void cargarDatos()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Session["listaPokemons"] = negocio.listarConSP();
            dgvPokemons.DataSource = Session["listaPokemons"];
            dgvPokemons.DataBind();
        }
    }
}