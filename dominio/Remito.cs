using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Remito
    {
        public int IdRemito { get; set; }

        public DateTime FechaRemito { get; set; }

        public int IdCliente {  get; set; }

        public int IdPedido {  get; set; }

        public decimal TotalRemito { get; set; }

        //public string Direccion {  get; set; } opcionalFuturo
    }
}
