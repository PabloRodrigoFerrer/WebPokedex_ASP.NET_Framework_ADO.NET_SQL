using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace WebPokedex
{
    public partial class Loging : System.Web.UI.Page
    {

        public bool mostrarError;

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarError = false;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario userLoging = new Usuario(txtLogDato.Text,txtPass.Text);
            UsuarioNegocio negocio = new UsuarioNegocio();

            if (negocio.Login(userLoging))
            {
                Session.Add("user", userLoging);

                if (UserManager.isAdmin)
                    Response.Redirect("listaPokemons.aspx");
                else
                    Response.Redirect("Default.aspx");
            }
            else
            {
                mostrarError = true;
            }

        }        

    }
}