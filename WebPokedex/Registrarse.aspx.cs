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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrase_Click(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario(txtLogDato.Text, txtPass.Text);
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                negocio.insertarUsuario(nuevoUsuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //agregamos a sesion el usuario creado
            if (negocio.Login(nuevoUsuario))
            {
                Session.Add("user", nuevoUsuario);
                Response.Redirect("MiPerfil.aspx");
            }
            
        }
    }
}