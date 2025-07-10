using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPokedex
{
    public partial class Mi : System.Web.UI.MasterPage
    {
        public bool usuarioActivo = UserManager.CurrentUser != null ? true : false;

        public event EventHandler BuscarYFiltrar;

        public string TextoBuscado
        {
            get { return txtBuscarProducto.Text; }
        }


        public  UpdatePanel PanelNavCarrito 
        { 
            get { return upNavbarCarrito; }
        }

        public void Page_Load(object sender, EventArgs e)
        {
            if(!usuarioActivo && !(Page is Loging || Page is Default || Page is Registrarse))
            {
                Response.Redirect("Login.aspx");
            }
            cargarImgAvatar();            
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            if (UserManager.CurrentUser != null)
            {
                Session.Remove("carrito");
                Session.Remove("listaFavoritos");
                Session.Remove("user");
                Response.Redirect("Login.aspx");
            }
                
        }

        private void cargarImgAvatar()
        {
            if (usuarioActivo && UserManager.tieneImgPerfil)
            {
                imgAvatar.ImageUrl = "~/Images/" + UserManager.CurrentUser.urlImagen;
            }
            else
            {
                imgAvatar.ImageUrl = "https://w7.pngwing.com/pngs/1000/665/png-transparent-computer-icons-profile-s-free-angle-sphere-profile-cliparts-free.png";
            }
        }

        protected void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            if(BuscarYFiltrar != null)
            {
                BuscarYFiltrar(this, EventArgs.Empty);
            }
        }


    }
}