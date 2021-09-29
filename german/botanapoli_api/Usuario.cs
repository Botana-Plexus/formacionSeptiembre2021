using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace botanapoli_api
{
    public class Autenticado
    {
        public string email { get; set; }
        public string pass { get; set; }
    }

    public class Registrado
    {
        public string email { get; set; }
        public string nick{ get; set; }
        public string pass { get; set; }
        public string fechaNac { get; set; }
    }

    public class AñadirJugador
    {
        public int idJugador { get; set; }
        public int idPartida { get; set; }
    }
}
