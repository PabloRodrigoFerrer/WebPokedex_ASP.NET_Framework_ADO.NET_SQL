using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPokedex
{
    public partial class Pedidos : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !UserManager.isActivo) 
            {
                Response.Redirect("Login.aspx");
            }


            PedidoNegocio negocio = new PedidoNegocio();
            if(UserManager.isActivo && UserManager.isAdmin) 
            {
                dgvPedidosAdmin.DataSource = negocio.listarPedidos();
                dgvPedidosAdmin.DataBind();
            }
            else 
            {
                int idCliente = UserManager.CurrentUser.Id;
                dgvPedidos.DataSource = negocio.listarPedidos(idCliente);
                dgvPedidos.DataBind();
            }


        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = UserManager.isAdmin == true ? dgvPedidosAdmin.SelectedDataKey.Value.ToString():dgvPedidos.SelectedDataKey.Value.ToString();

            Response.Redirect("PedidosDetalle.aspx?id=" + id);
        }

        protected void dgvPedidosAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "GenerarRemito")
            {
                string idPedido = e.CommandArgument.ToString();
                Response.Redirect("GenerarRemito.aspx?id=" + idPedido);
            }
            else if(e.CommandName =="VerDetalleRemito")
            {
                int idPedido = int.Parse(e.CommandArgument.ToString());
                PedidoNegocio negocio = new PedidoNegocio();

                // QUE IdRemito tiene el IDPedido recuperado..?
                int idRemito = negocio.RecuperarIdRemito(idPedido);
                Response.Redirect("RemitoDetalle.aspx?idRemito=" + idRemito);
            }

        }
    }
}