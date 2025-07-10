using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using dominio;

namespace WebPokedex
{
    public static class UserManager
    {
        public static Usuario CurrentUser
        {
            get { return HttpContext.Current.Session["user"] as Usuario; }
        }

        public static bool isAdmin
        {
            get {return CurrentUser != null ? CurrentUser.TipoUsuario == TipoUsuario.ADMIN : false ; }
        }

        public static bool isActivo
        {
            get { return CurrentUser != null ? true : false; }
        }

        public static bool tieneImgPerfil
        {
            get { return CurrentUser.urlImagen != "" ? true : false;}
        }

        public static bool tieneDireccion
        {
            get { return CurrentUser.Apellido != null ? true : false; }
        }

    }
}
