using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI
{
    public class Cartas
    {
        public int id { get; set; }
        public string texto { get; set; }
        public int valor { get; set; }
        public int tipo { get; set; }

        public Cartas(int id, string texto, int valor, int tipo)
        {
            this.id = id;
            this.texto = texto;
            this.valor = valor;
            this.tipo = tipo;
        }

        public Cartas(object[] array)
        {
            this.id = (int)array[0];
            this.texto = (string)array[1];
            this.valor = (int)array[2];
            this.tipo = (int)array[3];
        }
    }
}
