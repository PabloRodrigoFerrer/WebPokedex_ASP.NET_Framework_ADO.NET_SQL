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
    public partial class GenerarRemito : System.Web.UI.Page
    {

        //levantar id
        public List<CarritoItem> carrito 
        { 
            get { return CarritoHelper.obtenerCarrito(); }
            set { Session["carrito"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"]!= null && !IsPostBack) 
            {
                int id = int.Parse(Request.QueryString["Id"]);
                PedidoNegocio negocio = new PedidoNegocio();
                carrito = negocio.listarCarrito(id);
                dgvGenerarRemito.DataSource = carrito;
                dgvGenerarRemito.DataBind();
                lblCarritoRemito.Text = "$ " + CarritoHelper.SumaCarrito().ToString("N2");
            }
        }



        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            //identificar txt
            //que objeto cambio
            //modificar cantidad...
            
            TextBox txt = (TextBox)sender;
            GridViewRow fila = (GridViewRow)txt.NamingContainer;
            int indice = fila.RowIndex;
            int PokeId = Convert.ToInt32(dgvGenerarRemito.DataKeys[indice].Value);

            var item = carrito.FirstOrDefault(x => x.PokeId == PokeId);

            if (item != null) 
            {
                item.Cantidad = int.Parse(txt.Text);
            }

            txt.Text = item.Cantidad.ToString();

            cargarCarrito();
            
        }

        protected void dgvGenerarRemito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pokeId =Convert.ToInt32(dgvGenerarRemito.DataKeys[e.RowIndex].Value);
            
            var item = carrito.FirstOrDefault(x => x.PokeId == pokeId);

            carrito.Remove(item);

            cargarCarrito();          

        }

        protected void dgvGenerarRemito_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                CarritoItem item = e.Row.DataItem as CarritoItem;
                TextBox txtBox = (TextBox)e.Row.FindControl("txtCantidad");
                txtBox.Text = item.Cantidad.ToString();
            }

        }

        private void cargarCarrito()
        {
            dgvGenerarRemito.DataSource = CarritoHelper.obtenerCarrito();
            dgvGenerarRemito.DataBind();
            lblCarritoRemito.Text = "$ " + CarritoHelper.SumaCarrito().ToString("N2");
        }

        protected void btnEnviarRemito_Click(object sender, EventArgs e)
        {
            PedidoNegocio negocio = new PedidoNegocio();
            int id = Request.QueryString["Id"] != null ? int.Parse(Request.QueryString["Id"]) : 0;
            Usuario user = UserManager.CurrentUser;

            //insertar remito
            int idRemito =  negocio.InsertarRemito(user, carrito, id);

            //insertarDetalleRemito
            negocio.InsertarDetalleRemito(idRemito, carrito);

            Response.Redirect("RemitoEnviado.aspx");

        }
    }
}