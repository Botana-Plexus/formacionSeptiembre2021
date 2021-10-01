using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botanapoly.Models
{
    public class Jugadores
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int Partida { get; set; }
        public int Saldo { get; set; }
        public int Orden { get; set; }
        public int Posicion { get; set; }
        public int Dobles { get; set; }
        public int Castigo { get; set; }
        public int Deuda { get; set; }
        public int Acreedor { get; set; }
    }
}
