using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botanapoly.Models
{
    public class Propiedades
    {
        public int Id { get; set; }
        public Jugadores Jugador { get; set; }
        public Partidas Partida { get; set; }
        public Casillas Casilla { get; set; }
        public int NivelEdificacion { get; set; }

    }
}
