using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    [Serializable]
    public class CarritoItem
    {   

        public int? IdPedido {get;set;}

        public int PokeId { get; set; }

        public string PokeName { get; set; }

        public Elemento PokeTipo { get; set; }

        public int CantidadMax { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal => PrecioUnitario * Cantidad;
   
    } 

}
