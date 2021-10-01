using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Botanapoly
{
    public class Casillas
    {
        public int id { set; get; }
        public int tipo { set; get; }
        public int tablero { set; get; }
        public string nombre { set; get; }
        public int orden { set; get; } //orden dentro del tablero.debe comenzar en 1 y solo puede haber una 1, aunque se podria repetir algun orden
        public int? precioCompra { set; get; }
        public int? precioVenta { set; get; }
        public int? nivelEdificacion { set; get; }
        public int? costeEdificacion { set; get; }
        public int? precioVentaEdificacion { set; get; }
        public int? Coste1 { set; get; }
        public int? Coste2 { set; get; }
        public int? Coste3 { set; get; }
        public int? Coste4 { set; get; }
        public int? Coste5 { set; get; }
        public int? conjunto { set; get; }
        public int? destino { set; get; } //casilla destino para castigo, por ejemplo
        public int? propietario { set; get; }

    }
}
