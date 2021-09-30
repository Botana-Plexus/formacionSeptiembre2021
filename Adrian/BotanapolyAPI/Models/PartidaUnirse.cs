using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyAPI.Models
{
    public class PartidaUnirse
    {
        private int idUsuario;
        public int IdUsuario
        {
            get => idUsuario;
            set => idUsuario = value;
        }
        private int idPartida;
        public int IdPartida
        {
            get => idPartida;
            set => idPartida = value;
        }
        private string? pass;
        public string? Pass
        {
            get => pass;
            set => pass = value;
        }
    }
}
