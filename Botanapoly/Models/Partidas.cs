using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botanapoly.Models
{
    public class Partidas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Administrador { get; set; }
        public int MaxJugadores { get; set; }
        public int MaxTiempo { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Password { get; set; }
        public int NumJugadores { get; set; }
        public int Turno { get; set; }
        public int Estado { get; set; }
        public int Tablero { get; set; }

        public DateTime TiempoTranscurrido { get; set; }


    }
}
