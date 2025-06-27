using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }


    public class Usuario
    {
        public int Id { get; set; }

        public string sexo {  get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento {  get; set; }

        public string Email {  get; set; }

        public string User { get; set; }

        public string Pass {  get; set; }

        public string urlImagen {  get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public bool isAdmin
        {
            get { return TipoUsuario == TipoUsuario.ADMIN;}
        }

        public Usuario(string dato, string Pass)
        {

            if (esEmail(dato))
            {
                this.Email = dato;
            }
            else
            {
                this.User = dato;
            }            
            this.Pass = Pass;
        }

        private bool esEmail(string dato) 
        { 
            if(dato.Contains("@") && dato.Contains("."))
            {
                return true;
            }
            return false;
        }

    }
}
