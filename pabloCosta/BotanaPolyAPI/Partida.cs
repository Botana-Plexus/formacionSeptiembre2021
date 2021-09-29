using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI
{
    public class Partida 
    {
        
        public string nombre { get; set; }
        public int admin { get; set; }
        public int? maxJugadores { get; set; }
        public int? maxTiempo { get; set; }
        public string? pass { get; set; }
        public int? tablero { get; set; }

        public Partida()
        {
        }

        public Partida(string nombre, int admin, int? maxJugadores, int? maxTiempo, string pass, int? tablero)
        {
            this.nombre = nombre;
            this.admin = admin;
            this.maxJugadores = maxJugadores;
            this.maxTiempo = maxTiempo;
            this.pass = pass;
            this.tablero = tablero;
        }

        public Partida(object[] array)
        {
            this.nombre = (string)array[1];
            this.admin = (int)array[2];
            this.maxJugadores = (int)array[3] ;
            this.maxTiempo = array[4] != System.DBNull.Value ? (int)array[4] : null;
            this.pass = array[5] != System.DBNull.Value ? (string)array[5] : null;
            this.maxTiempo =  (int)array[6] ;
        }

    }
}
