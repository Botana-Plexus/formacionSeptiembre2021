using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace botanapoli_api
{
    public class CrearPartida
    {
        string nombre { get; set; }
        int idAdmin { get; set; }
        int maxJugadores { get; set; }
        int maxTiempo { get; set; }
        string pass { get; set; }
        int idPlantilla { get; set; }
    }
    public class IniciarPartida
    {
        public int id { get; set; }
    }
}
