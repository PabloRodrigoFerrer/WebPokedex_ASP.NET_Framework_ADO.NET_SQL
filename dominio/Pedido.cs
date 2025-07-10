using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pedido
    {
        public  int IdPedido { get; set; }

        public DateTime FechaPedido { get; set; }

        public int IdCliente { get; set; }

        public string Cliente {  get; set; }

        public string Estado {  get; set; }

        public decimal TotalPedido { get; set; }

        public int CantidadTotal { get; set; }

    }
}
