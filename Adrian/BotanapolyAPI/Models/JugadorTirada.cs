using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyAPI.Models
{
    public class JugadorTirada
    {
        private int? idJugador;
        public int? IdJugador
        {
            get => idJugador;
            set => idJugador = value;
        }
        private int? tirada;
        public int? Tirada
        {
            get => tirada;
            set => tirada = value;
        }
    }
}
