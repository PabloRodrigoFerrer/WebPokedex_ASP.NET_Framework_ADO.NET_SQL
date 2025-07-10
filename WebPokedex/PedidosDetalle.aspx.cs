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
    public partial class PedidosDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //recibo id pedido y listo() filtrando en la base de datos...
            PedidoNegocio negocio = new PedidoNegocio();

            if (Request.QueryString["id"] != null) 
            {
                int id = int.Parse(Request.QueryString["id"]);

                List<CarritoItem> listaCarrito = negocio.listarCarrito(id);

                dgvPedidosDetalle.DataSource = listaCarrito;
                dgvPedidosDetalle.DataBind();

            }
        }
    }
}