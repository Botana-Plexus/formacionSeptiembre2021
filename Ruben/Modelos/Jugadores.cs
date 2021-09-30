using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Botanapoly
{
    public class Jugadores
    {
        public int id { set; get; }
        public int? idUsuario { set; get; }
        public int idPartida { set; get; }
        public int saldo { set; get; }
        public int orden { set; get; } //orden 0 = no tiene orden, por lo que es observador
        public int posicion { set; get; } //casilla sobre la que esta situado el jugador.
        public int turnosDeCastigo { set; get; }
        public int dobles { set; get; }

    }
}
