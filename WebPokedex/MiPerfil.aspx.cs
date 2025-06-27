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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            cargarImagen();
            if(!IsPostBack)
                cargarCampos();
        }

        protected void btnPerfilGuardar_Click(object sender, EventArgs e)
        {   
            UsuarioNegocio negocio = new UsuarioNegocio();
            int id = UserManager.CurrentUser.Id;

            if(txtImageFile.HasFile)
            {
                string ruta = Server.MapPath("./Images/");
                txtImageFile.PostedFile.SaveAs(ruta + "perfil-" + id.ToString() + ".jpg" );
                UserManager.CurrentUser.urlImagen = "perfil-" + id.ToString() + ".jpg";
            }
            UserManager.CurrentUser.Nombre = txtPerfilNombre.Text;
            UserManager.CurrentUser.Apellido = txtPerfilApellido.Text;
            UserManager.CurrentUser.FechaNacimiento = DateTime.Parse(txtPerfilFecha.Text);

            negocio.actualizar(UserManager.CurrentUser);

        }

        private void cargarImagen()
        {
            if (UserManager.isActivo && UserManager.tieneImgPerfil)
            {
                imgPerfil.ImageUrl = "~/Images/" + UserManager.CurrentUser.urlImagen;
            }
            else
            {
                imgPerfil.ImageUrl = "https://doc24.com.ar/wp-content/uploads/2023/10/placeholder-2-1.png";
            }
        }
        private void cargarCampos()
        {
            if (UserManager.CurrentUser != null)
            {
                txtPerfilEmail.Text = UserManager.CurrentUser.Email;
                txtPerfilNombre.Text = UserManager.CurrentUser.Nombre;
                txtPerfilApellido.Text = UserManager.CurrentUser.Apellido;
                txtPerfilFecha.Text = UserManager.CurrentUser.FechaNacimiento.ToString("yyyy-MM-dd");
            }
        }


    }
}