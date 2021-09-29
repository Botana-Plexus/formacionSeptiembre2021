using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Botanapoly
{
    public class Cartas
    {
        public int id { set; get; }
        public int tablero { set; get; }
        public int conjunto { set; get; }
        public int tipo { set; get; }
        public int valor { set; get; }
    public Cartas(int id, int tablero, int conjunto, int tipo, int valor)
    {
            this.id = id;
            this.tablero = tablero;
            this.conjunto = conjunto;
            this.tipo = tipo;
            this.valor = valor;
    }
    }
}
