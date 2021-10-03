using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI
{
    public class Partida 
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int admin { get; set; }
        public int? maxJugadores { get; set; }
        public int? maxTiempo { get; set; }
        public int? tiempoTranscurrido { get; set; }
        public int numJugadores { get; set; }
        public int turno { get; set; }
        public int estado { get; set; }
        public string? pass { get; set; }
        public int? tablero { get; set; }

        public Partida(int id, string nombre, int? maxJugadores, int? maxTiempo, int tiempoTranscurrido, int numJugadores, int turno, int estado, int? tablero)
        {
            this.id = id;
            this.nombre = nombre;
            this.maxJugadores = maxJugadores;
            this.maxTiempo = maxTiempo;
            this.tiempoTranscurrido = tiempoTranscurrido;
            this.numJugadores = numJugadores;
            this.turno = turno;
            this.estado = estado;
            this.tablero = tablero;
        }

        public Partida(object[] array)
        {
            this.id = (int)array[0];
            this.nombre = (string)array[1];
            this.maxJugadores = (int)array[2];
            this.maxTiempo = array[3] != System.DBNull.Value ? (int)array[3] : null;
            this.tiempoTranscurrido = array[4]!= System.DBNull.Value ? (int)array[4] : null;
            this.numJugadores = (int)array[5];
            this.turno = (int)array[6];
            this.estado = (int)array[7];
            this.tablero = (int)array[8];
        }

    }
}
