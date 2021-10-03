using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI
{
    public class Tablero
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int numCasillas { get; set; }
        public int dineroInicial { get; set; }

        public Tablero(int id, string descripcion, int numCasillas, int dineroInicial)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.dineroInicial = dineroInicial;
            this.numCasillas = numCasillas;
        }

        public Tablero(object[] array)
        {
            this.id = (int)array[0];
            this.descripcion = (string)array[1];
            this.dineroInicial = (int)array[2];
            this.numCasillas = (int)array[3];
        }
    }
}
