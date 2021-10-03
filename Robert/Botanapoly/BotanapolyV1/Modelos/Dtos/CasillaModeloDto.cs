using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyV1.Modelos.Dto
{
    public class CasillaModeloDto
    {
        public int id { get; set; }
        public int tipo { get; set; }
        public int tablero {get; set;}
        public string nombre {get; set;}
        public int orden {get; set;}
        public int? precioCompra {get; set;}
        public int? precioVenta {get; set;}
        public int? nivelEdificacion {get; set;}
        public int? costeEdificacion {get; set;}
        public int? precioVentaEdificacion {get; set;}
        public int? Coste1 {get; set;}
        public int? Coste2 {get; set;}
        public int? Coste3 {get; set;}
        public int? Coste4 {get; set;}
        public int? Coste5 {get; set;}
        public int? Coste6 { get; set; }
        public int? jugador { get; set; }
        public int? conjunto {get; set;}
        public int? destino {get; set;}
    }
}
