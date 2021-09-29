using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Botanapoly
{
    public class Partida
    {
        public int id { set; get; }
        public string nombre { set; get; }
        public int administrador { set; get; }
        public int maxJugadores { set; get; } //si no se espicifica es 6
        public int maxTiempo { set; get; }//si no se espicifica no tiene
        public DateTime fechaInicio { set; get; }
        public string pass { set; get; }
        public int numJugadores { set; get; }
        public int turno { set; get; }
        public int estado { set; get; } //estado de la partida, indica si está creada(1) o iniciada(2). No s eespecifica el 3 - finalizada, porque se eliminara
        public int tablero { set; get; }



        public Partida(int id, string nombre, int administrador, int maxJugadores, int maxTiempo,
        DateTime fechaInicio, string pass, int numJugadores, int turno, int estado, int tablero)
        {
            this.id = id;
            this.nombre = nombre;
            this.administrador = administrador;
            this.maxJugadores = maxJugadores;
            this.maxTiempo = maxTiempo;
            this.fechaInicio = fechaInicio;
            this.pass = pass;
            this.numJugadores = numJugadores;
            this.turno = turno;
            this.estado = estado;
            this.tablero = tablero;
        }



    }
}