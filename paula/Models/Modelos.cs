using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI.Models
{
    public class Modelos
    {
        public class Partida
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public int admin { get; set; }
        }
        

        public class Jugador
        {
            public int rol { get; set; }
            public int dinero { get; set; }
            public int posicion { get; set; }
            public int partida { get; set; }
            public int orden { get; set; }
        }


        public class Usuario
        {
            protected int id { get; set; }
            protected string email { get; set; }
            protected string nick { get; set; }
            protected string pass { get; set; }
            protected DateTime fechaNacimiento { get; set; }
        }

        public class Tableros
        {
            protected int id { get; set; }
            protected string descripcion { get; set; }
            protected int importe { get; set; }
            protected int numCasillas { get; set; }
        }

        public class Casillas
        {
            protected int id { get; set; }
            protected int tipo { get; set; }
            protected int tablero { get; set; }
            protected string nombre { get; set; }
            protected int orden { get; set; }
            protected int precioCompra { get; set; }
            protected int precioVenta { get; set; }
            protected int nivelEdificacion { get; set; }
            protected int costeEdificacion { get; set; }
            protected int precioVentaEdificacion { get; set; }
            protected int coste1 { get; set; }
            protected int coste2 { get; set; }
            protected int coste3 { get; set; }
            protected int coste4 { get; set; }
            protected int coste5 { get; set; }
            protected int conjunto { get; set; }
            protected int destino { get; set; }

        }

    }
}
