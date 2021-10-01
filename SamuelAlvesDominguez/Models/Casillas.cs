using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botanapoly.Models
{
    public class Casillas
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public int Tablero { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }

        public int? PrecioCompra { get; set; }
        public int? PrecioVenta { get; set; }
        public int? NivelEdificacion { get; set; }
        public int? CosteEdificacion { get; set; }
        public int? PrecioVentaEdificacion { get; set; }
        public int? Coste1 { get; set; }
        public int? Coste2 { get; set; }
        public int? Coste3 { get; set; }
        public int? Coste4 { get; set; }
        public int? Coste5 { get; set; }
        public int? Conjunto { get; set; }
        public int? Destino { get; set; }

    }
}
