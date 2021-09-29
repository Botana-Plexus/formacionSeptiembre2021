using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI
{
    public class Jugador
    {
        public int idPartida { get; set; }
        public int idUsuario { get; set; }
        public int rol { get; set; }
        public int saldo { get; set; }
        public int posicion { get; set; }

        public Jugador()
        {
        }

        public Jugador(int idPartida, int idUsuario, int rol, int saldo, int posicion)
        {
            this.idPartida = idPartida;
            this.idUsuario = idUsuario;
            this.rol = rol;
            this.saldo = saldo;
            this.posicion = posicion;
        }

        public Jugador(object[] array)
        {
            this.idPartida = (int)array[0];
            this.idUsuario = (int)array[1];
            this.rol = (int)array[2];
            this.saldo =(int)array[3];
            this.posicion =(int)array[4];
        }
    }
}
