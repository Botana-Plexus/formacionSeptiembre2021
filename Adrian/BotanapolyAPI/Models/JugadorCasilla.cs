using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyAPI.Models
{
    public class JugadorCasilla
    {
        private int? idJugador;
        public int? IdJugador
        {
            get => idJugador;
            set => idJugador = value;
        }
        private int? idCasilla;
        public int? IdCasilla
        {
            get => idCasilla;
            set => idCasilla = value;
        }
    }
}
