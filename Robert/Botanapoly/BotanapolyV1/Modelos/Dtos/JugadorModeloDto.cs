using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyV1.Modelos.Dto
{
    public class JugadorModeloDto
    {
        public int id { get; set; }
        public int? idUsuario { get; set; }
        public int idPartida { get; set; }
        public int saldo { get; set; }
        public int orden { get; set; }
        public int? posicion { get; set; }
        public int dobles { get; set; }
        public int turnosDeCastigo { get; set; }
    }
}
