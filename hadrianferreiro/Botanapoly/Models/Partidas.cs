using System;
using System.Text.Json.Serialization;

namespace Botanapoly.Models
{
    public class Partidas
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int administrador { get; set; }
        public int maxJugadores { get; set; }
        public int maxTiempo { get; set; }
        public DateTime fechaInicio { get; set; }
        public string pass { get; set; }
        public int numJugadores { get; set; }
        public int turno { get; set; }
        public int estdo { get; set; }
        public int tablero { get; set; }
        public int tiempoEnJuego { get; set; }

        [JsonConstructor]
        public Partidas(string nombre, int administrador, int maxJugadores, int maxTiempo, string pass, int tablero)
        {
            this.nombre = nombre;
            this.administrador = administrador;
            this.maxJugadores = maxJugadores;
            this.maxTiempo = maxTiempo;
            this.pass = pass;
            this.tablero = tablero;
        }

        public Partidas(object[] array)
        {
            this.id = (int)array[0];
            this.nombre = (string)array[1];
            if (array[2] != System.DBNull.Value) this.maxJugadores = (int)array[2];
            if (array[3] != System.DBNull.Value) this.maxTiempo = (int)array[3];
            if (array[4] != System.DBNull.Value) this.tiempoEnJuego = (int)array[4];
        }
    }
}
