using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyAPI.Models
{
    public class PartidaCrear
    {

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        private int administrador;
        public int Administrador
        {
            get => administrador;
            set => administrador = value;
        }
        private int maxJugadores;
        public int MaxJugadores
        {
            get => maxJugadores;
            set => maxJugadores = value;
        }
        private int maxTiempo;
        public int MaxTiempo
        {
            get => maxTiempo;
            set => maxTiempo = value;
        }
        private string pass;
        public string Pass
        {
            get => pass;
            set => pass = value;
        }
        private int tablero;
        public int Tablero
        {
            get => tablero;
            set => tablero = value;
        }
    }
}
