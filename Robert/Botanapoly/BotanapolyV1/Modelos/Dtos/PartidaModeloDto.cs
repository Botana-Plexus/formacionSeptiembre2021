using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BotanapolyV1.Modelos.Dto
{
    public class PartidaModeloDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int? administrador { get; set; }
        public int? maxJugadores { get; set; }
        public int? tiempoTranscurrido { get; set; }
        public int? maxTiempo { get; set; }
        public DateTime? fechaInicio { get; set; }
        public string pass { get; set; }
        public int numJugadores { get; set; }
        public int turno { get; set; }
        public int estado { get; set; }
        public int tablero { get; set; }
        public bool tienePass { get; set; }
    }
}
