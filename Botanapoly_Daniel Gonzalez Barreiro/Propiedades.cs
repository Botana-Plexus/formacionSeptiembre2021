using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Botanapoly
{

    public class Propiedades
    {
        public int id { set; get; }
        public int jugador { set; get; }
        public int partida { get; set; }
        public int casilla { get; set; }
        public int nivelEdificacion { get; set; } //nivel de edificacion de la casilla si procede, si no, null

        public Propiedades(int id, int jugador, int partida, int casilla, int nivelEdificacion)
        {
            this.id = id;
            this.jugador = jugador;
            this.partida = partida;
            this.casilla = casilla;
            this.nivelEdificacion = nivelEdificacion;
        }

    }
}
