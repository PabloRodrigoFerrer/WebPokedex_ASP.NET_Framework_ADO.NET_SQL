using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public  class RemitoItem
    {
        public int DetalleId { get; set; }

        public int RemitoId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public string NombreProducto {  get; set; }

        public string Color {  get; set; }

        public decimal PrecioUnitario {  get; set; }

        public decimal SubTotal => Cantidad * PrecioUnitario;

    }
}
