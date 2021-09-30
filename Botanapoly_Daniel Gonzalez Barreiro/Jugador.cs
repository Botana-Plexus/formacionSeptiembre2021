using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Botanapoly
{
    public class Jugador
    {

        public int id { set; get; }
        public int? idUsuario { set; get; }
        public int idPartida { set; get; }
        public int saldo { set; get; }
        public int orden { set; get; }//orden 0 = no tiene orden, por lo que es observador
        public int posicion { set; get; } //casilla sobre la que esta situado el jugador.
        public int dobles { set; get; }
        public int turnosDeCastigo { set; get; }

        //public Jugador(int id, int idUsuario, int idPartida, int saldo, int orden, int posicion)
        //{
        //    this.id = id;
        //    this.idUsuario = idUsuario;
        //    this.idPartida = idPartida;
        //    this.saldo = saldo;
        //    this.orden = orden;
        //    this.posicion = posicion;
        //}
    }

}
