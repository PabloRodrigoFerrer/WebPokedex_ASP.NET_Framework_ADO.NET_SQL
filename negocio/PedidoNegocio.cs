using dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negocio
{
    public class PedidoNegocio
    {
        public int insertarPedido(Usuario user, List<CarritoItem> carrito)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO PEDIDOS (FechaPedido,IdCliente,Estado,TotalPedido,TotalUnidades, Cliente) OUTPUT inserted.IdPedido VALUES(@fecha,@IdCliente,@estado,@totalPedido,@totalUnidades,@cliente)";

                datos.setearConsulta(consulta);
                datos.setearParametro("@fecha", DateTime.Now);
                datos.setearParametro("@IdCliente", user.Id);
                datos.setearParametro("@estado", "En preparación");
                datos.setearParametro("@totalPedido", carrito.Sum(x => x.Subtotal));
                datos.setearParametro("@totalUnidades", carrito.Sum(x => x.Cantidad));
                user.Nombre = user.Nombre != null ? user.Nombre : "NO REGISTRADO";
                datos.setearParametro("@cliente", user.Nombre);
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
        
        public void insertarDetalle(int idPedido, List<CarritoItem> carrito) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                foreach (var item in carrito)
                {
                    string consulta = "INSERT INTO DETALLEPEDIDO(IdPedido,IdProducto,Cantidad,PrecioUnitario, SubTotal ,NombreProducto,Color) VALUES (@IdPedido,@IdProducto,@Cantidad,@PrecioUnitario,@SubTotal,@NombreProducto,@Color)";

                    datos.limpiarParemetro();
                    datos.setearParametro("@IdPedido", idPedido);
                    datos.setearParametro("@IdProducto", item.PokeId);
                    datos.setearParametro("@Cantidad", item.Cantidad);
                    datos.setearParametro("@PrecioUnitario", item.PrecioUnitario);
                    datos.setearParametro("@SubTotal", item.Subtotal);
                    datos.setearParametro("@NombreProducto", item.PokeName);
                    datos.setearParametro("@Color", item.PokeTipo.Descripcion);

                    datos.setearConsulta(consulta);
                    datos.ejecutarAccion(true);

                }
                
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


        public List<Pedido> listarPedidos(int? id = null)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT IdPedido,IdCliente,FechaPedido, Cliente ,TotalPedido,TotalUnidades,Estado FROM PEDIDOS";

                if (id == null)
                {
                    datos.setearConsulta(consulta);
                }
                else
                {
                    consulta += " WHERE IdCliente = @id";
                    datos.setearConsulta(consulta);
                    datos.setearParametro("id", id);
                }

                    datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    listaPedidos.Add(new Pedido
                    {
                        IdPedido = (int)datos.Lector["IdPedido"],
                        IdCliente = (int)datos.Lector["IdCliente"],
                        FechaPedido = DateTime.Parse(datos.Lector["FechaPedido"].ToString()),
                        Cliente = datos.Lector["Cliente"] != DBNull.Value ? (string)datos.Lector["Cliente"] : "",
                        TotalPedido = (decimal)datos.Lector["TotalPedido"],
                        CantidadTotal = datos.Lector["TotalUnidades"] != DBNull.Value ? (int)datos.Lector["TotalUnidades"] : 0,
                        Estado = (string)datos.Lector["Estado"]
                    });
                }


                return listaPedidos;

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


        public List<CarritoItem> listarCarrito(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<CarritoItem> listaCarrito = new List<CarritoItem>();
            try
            {
                datos.setearConsulta("SELECT IdPedido, IdProducto, NombreProducto,Color, Cantidad, PrecioUnitario FROM DETALLEPEDIDO WHERE IdPedido = @idPedido");
                datos.setearParametro("@idPedido", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    listaCarrito.Add(new CarritoItem
                    {
                        IdPedido = (int)datos.Lector["IdPedido"],
                        PokeId = (int)(datos.Lector["IdProducto"]),
                        PokeName = (string)datos.Lector["NombreProducto"],
                        PokeTipo = new Elemento((string)datos.Lector["Color"]),
                        Cantidad = (int)datos.Lector["Cantidad"],
                        PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"]
                    });

                }

                return listaCarrito;
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


        public int InsertarRemito(Usuario user ,List<CarritoItem> carritoRemito, int idPedido)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "INSERT INTO REMITOS (FechaRemito,IdCliente,IdPedido,TotalRemito) OUTPUT inserted.IdRemito VALUES(@FechaRemito,@idCliente,@idPedido,@TotalRemito)";


                datos.setearConsulta(consulta);
                datos.setearParametro("@FechaRemito",DateTime.Now);
                datos.setearParametro("@idCliente", user.Id);
                datos.setearParametro("@idPedido", idPedido);
                datos.setearParametro("@TotalRemito",carritoRemito.Sum(x => x.Subtotal));              

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
        
        public void InsertarDetalleRemito(int idRemito, List<CarritoItem> carritoRemito) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                foreach (var item in carritoRemito) 
                {
                    string consulta = "INSERT INTO DETALLEREMITO (RemitoId,ProductoId,Cantidad,NombreProducto, Color, PrecioUnitario,SubTotal) VALUES(@idRemito,@productoId,@cantidad,@nombreProducto,@color,@precioUnitario,@subTotal)";

                    datos.limpiarParemetro();
                    datos.setearParametro("@idRemito", idRemito);
                    datos.setearParametro("@productoId", item.PokeId);
                    datos.setearParametro("@cantidad", item.Cantidad);
                    datos.setearParametro("@nombreProducto", item.PokeName);
                    datos.setearParametro("@color", item.PokeTipo.Descripcion);
                    datos.setearParametro("@precioUnitario", item.PrecioUnitario);
                    datos.setearParametro("@subTotal", item.Subtotal);
                    
                    datos.setearConsulta(consulta);
                    datos.ejecutarAccion(true);
                }
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

        public List<RemitoItem> ListarDetalleRemito(int idRemito) 
        {
            List<RemitoItem> listaDetalleRemito = new List<RemitoItem>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT RemitoId, ProductoId, Cantidad, NombreProducto, Color, PrecioUnitario  FROM DETALLEREMITO WHERE RemitoId = @idRemito";   
                datos.setearParametro("@idRemito", idRemito);
                datos.setearConsulta(consulta);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    listaDetalleRemito.Add(new RemitoItem
                    {
                        RemitoId = (int)datos.Lector["RemitoId"],
                        ProductoId = (int)datos.Lector["ProductoId"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        NombreProducto = (string)datos.Lector["NombreProducto"],
                        Color = (string)datos.Lector["Color"],
                        PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"]
                    });
                }
                return listaDetalleRemito;
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

        public int RecuperarIdRemito(int idPedido) 
        {
            AccesoDatos datos = new AccesoDatos();
            int idRemito = 0;
            datos.setearConsulta("SELECT IdRemito FROM REMITOS WHERE IdPedido = @idPedido");
            datos.setearParametro("@idPedido", idPedido);
            datos.ejecutarLectura();
            while (datos.Lector.Read()) 
            {
                idRemito = datos.Lector["idRemito"] != null ? (int)datos.Lector["idRemito"] : 0;
                
                return idRemito;
            }

            return idRemito;
        }
    }
}
