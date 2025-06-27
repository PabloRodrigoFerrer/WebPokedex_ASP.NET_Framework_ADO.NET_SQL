using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Login(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Id, TipoUsuario, UrlImagen, Nombre, Apellido, FechaNacimiento FROM USUARIOS WHERE Pass=@Pass";

                if(user.Email != null)
                {
                    consulta += " and Email = @Email";
                    datos.setearParametro("@Email", user.Email);

                }else if(user.User != null)
                {
                    consulta += " and Usuario = @User";
                    datos.setearParametro("@User", user.User);
                }

                datos.setearConsulta(consulta);
                datos.setearParametro("@Pass", user.Pass);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    user.TipoUsuario = (int)datos.Lector["TipoUsuario"] == 1 ? TipoUsuario.NORMAL : TipoUsuario.ADMIN;

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        user.urlImagen = (string)datos.Lector["UrlImagen"];

                    //user.urlImagen = datos.Lector["UrlImagen"] != DBNull.Value ? (string)datos.Lector["UrlImagen"]: "";
                    if (!(datos.Lector["Nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["Nombre"];
                        
                    //user.Nombre = datos.Lector["Nombre"]!= DBNull.Value? (string)datos.Lector["Nombre"]: "";

                    user.Apellido = datos.Lector["Apellido"] != DBNull.Value ? (string)datos.Lector["Apellido"] : "";

                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                        user.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }  
        }

        public int insertarUsuario(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("insertarUsuario");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Pass);

                return datos.ejecutarScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }            
        }

        public void actualizar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USUARIOS SET UrlImagen = @urlimg, Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fechaNacimiento WHERE ID = @id");
                datos.setearParametro("@urlimg", user.urlImagen);
                datos.setearParametro("@id", user.Id);
                datos.setearParametro("@nombre", string.IsNullOrEmpty(user.Nombre) ?(Object)DBNull.Value : user.Nombre); // (Object)user.Nombre ?? DbNull.Value => no cubre el vacio.
                datos.setearParametro("@apellido", string.IsNullOrEmpty(user.Apellido) ? (Object)DBNull.Value : user.Apellido);
                datos.setearParametro("@fechaNacimiento", string.IsNullOrEmpty(user.FechaNacimiento.ToString()) ? (Object)DBNull.Value : user.FechaNacimiento);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }

        }
        
    }
}
