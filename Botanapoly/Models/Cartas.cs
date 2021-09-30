using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botanapoly.Models
{
    public class Cartas
    {
        public int Id { get; set; }
        public Tableros Tablero { get; set; }
        public int Conjunto { get; set; }
        public TiposCartas Tipo { get; set; }
        public int Valor { get; set; }

    }
}
