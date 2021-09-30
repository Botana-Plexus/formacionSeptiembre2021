using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botanapoly.Models
{
    public class Jugadores
    {
        public int Id { get; set; }
        public Usuarios Usuario { get; set; }
        public Partidas Partida { get; set; }
        public int Saldo { get; set; }
        public int Orden { get; set; }
        public Casillas Posicion { get; set; }
        
    }
}
