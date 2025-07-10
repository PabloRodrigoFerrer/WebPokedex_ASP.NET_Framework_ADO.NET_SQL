using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebPokedex.Helpers;

namespace WebPokedex
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CarritoHelper.obtenerCarrito() != null && !IsPostBack)
                cargarCarrito();
                

           
        }

        //cargar carrito
        private void cargarCarrito()
        {
            dgvCarrito.DataSource = CarritoHelper.obtenerCarrito();
            dgvCarrito.DataBind();
            lblTotal.Text = "$ " + CarritoHelper.SumaCarrito().ToString("N2");
        }

        protected void dgvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int PokeId = Convert.ToInt32(dgvCarrito.DataKeys[e.RowIndex].Value);
            var carrito = CarritoHelper.obtenerCarrito();
            CarritoItem seleccionado = carrito.Find(x => x.PokeId == PokeId);

            carrito.Remove(seleccionado);

            cargarCarrito();
        }


        protected void ddlCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddl = (DropDownList)sender;
            GridViewRow fila = (GridViewRow)ddl.NamingContainer;
            int indice = fila.RowIndex;
            int pokeId = Convert.ToInt32(dgvCarrito.DataKeys[indice].Value);

            var carrito = CarritoHelper.obtenerCarrito();
            var item = carrito.FirstOrDefault(x => x.PokeId == pokeId);

            if (item != null) 
            {
                item.Cantidad = int.Parse(ddl.SelectedValue);
            }
            
            cargarCarrito();

        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow fila = (GridViewRow)ddl.NamingContainer;
            int indice = fila.RowIndex;
            int pokeId = Convert.ToInt32(dgvCarrito.DataKeys[indice].Value);

            var carrito = CarritoHelper.obtenerCarrito();
            var item = carrito.FirstOrDefault(x => x.PokeId == pokeId);

            if(item != null)
            {
                item.PokeTipo.Id = int.Parse(ddl.SelectedValue);
                item.PokeTipo.Descripcion = ((List<Elemento>)Session["listaElementos"]).FirstOrDefault(x => x.Id == item.PokeTipo.Id)?.Descripcion;
            }

            cargarCarrito();

        }

        protected void btnPedir_Click(object sender, EventArgs e)
        {
            int pedidoId;
            Usuario user = UserManager.CurrentUser;
            var carrito = CarritoHelper.obtenerCarrito();
            PedidoNegocio negocio = new PedidoNegocio();


            pedidoId = negocio.insertarPedido(user, carrito);
            negocio.insertarDetalle(pedidoId, carrito);


            Response.Redirect("PedidoEnviado.aspx");

        }

        protected void dgvCarrito_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //buscar item y cantidadmax
                    CarritoItem item = e.Row.DataItem as CarritoItem;
                    int stock = item.CantidadMax;

                    //cargar ddl tipo
                    DropDownList ddlTipo = (DropDownList)e.Row.FindControl("ddlTipo");
                    ddlTipo.DataSource = (List<Elemento>)Session["listaElementos"];
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    //buscar ddl
                    DropDownList ddlCantidad = (DropDownList)e.Row.FindControl("ddlCantidad");

                    ddlCantidad.Items.Clear();

                    for (int i = 1; i <= stock; i++)
                    {
                        ddlCantidad.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }

                    ddlCantidad.SelectedValue = item.Cantidad.ToString();
                    ddlTipo.SelectedValue = item.PokeTipo.Id.ToString();
                }            
        }

        protected void btnBorrarCarrito_Click(object sender, EventArgs e)
        {
            var carrito = CarritoHelper.obtenerCarrito();

            if (carrito != null)
                Session.Remove("carrito");
            cargarCarrito();

            Response.Redirect("Default.aspx");
        }

       
    }
}   



