using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI
{
    public class Jugador
    {
        public int id { get; set; }
        public int idPartida { get; set; }
        public int? idUsuario { get; set; }
        public int saldo { get; set; }
        public int orden { get; set; }
        public int posicion { get; set; }
        public int dobles { get; set; }
        public int turnosCastigo { get; set; }

        public Jugador()
        {
        }

        public Jugador(int id, int idPartida, int idUsuario, int saldo, int orden, int posicion, int dobles, int turnosCastigo)
        {
            this.id = id;
            this.idPartida = idPartida;
            this.idUsuario = idUsuario;
            this.saldo = saldo;
            this.orden = orden;
            this.posicion = posicion;
            this.dobles = dobles;
            this.turnosCastigo = turnosCastigo;
        }

        public Jugador(object[] array)
        {
            this.id = (int)array[0];
            this.idPartida = (int)array[1];
            this.idUsuario = array[2] != System.DBNull.Value ? (int)array[2] : null;
            this.saldo = (int)array[3];
            this.orden = (int)array[4];
            this.posicion = (int)array[5];
            this.dobles = (int)array[6];
            this.turnosCastigo = (int)array[7];
        }
    }
}
