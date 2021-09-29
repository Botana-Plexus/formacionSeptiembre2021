using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI.Models
{
    public class Modelos
    {
        public class Partida
        {
            protected int id;
            public int Id
            {
                get => id;
                set => id = value;
            }
            protected string nombre;
            public string Nombre
            {
                get => nombre;
                set => nombre = value;
            }
            protected int administrador;
            public int Administrador
            {
                get => administrador;
                set => administrador = value;
            }
            protected int maxJugadores;
            public int MaxJugadores
            {
                get => maxJugadores;
                set => maxJugadores = value;
            }
            protected int maxTiempo;
            public int MaxTiempo
            {
                get => maxTiempo;
                set => maxTiempo = value;
            }
            protected DateTime fechaInicio;
            public DateTime FechaInicio
            {
                get => fechaInicio;
                set => fechaInicio = value;
            }
            protected string pass;
            public string Pass
            {
                get => pass;
                set => pass = value;
            }
            protected int numJugadores;
            public int NumJugadores
            {
                get => numJugadores;
                set => numJugadores = value;
            }
            protected int turno;
            public int Turno
            {
                get => turno;
                set => turno = value;
            }
            protected int estado;
            public int Estado
            {
                get => estado;
                set => estado = value;
            }
            protected int tablero;
            public int Tablero
            {
                get => tablero;
                set => tablero = value;
            }
        }
        

        public class Jugador
        {
            protected int id;
            protected int idUsuario;
            protected int idPartida;
            protected int saldo;
            protected int orden;
            protected int posicion;
        }


        public class Usuario
        {
            protected int id;
            protected string email;
            public string Email{
                get => email;
                set => email = value;
            }
            protected string nick;
            public string Nick{
                get => nick;
                set => nick = value;
            }
            protected string pass;
            public string Pass{
                get => pass ;
                set => pass = value;
            }
            protected DateTime fechaNacimiento;
            public DateTime FechaNacimiento{
                get => fechaNacimiento;
                set => fechaNacimiento= value;
            }
        }

        public class Tablero
        {
            protected int id;
            public int Id
            {
                get => id;
                set => id = value;
            }
            protected string descripcion;
            public string Descripcion
            {
                get => descripcion;
                set => descripcion = value;
            }
            protected int importe;
            public int Importe {
                get => importe;
                set => importe = value;
            }
            protected int numCasillas;
            public int NumCasillas {
                get => numCasillas;
                set => numCasillas = value;
            }
        }

        public class TipoCasillas
        {
            protected int id;
            protected string descripcion;
        }

        public class Casilla
        {
            protected int id;
            protected int tipo;
            protected int tablero;
            protected string nombre;
            protected int orden;
            protected int precioCompra;
            protected int precioVenta;
            protected int nivelEdificacion;
            protected int costeEdificacion;
            protected int precioVentaEdificacion;
            protected int coste1;
            protected int coste2;
            protected int coste3;
            protected int coste4;
            protected int coste5;
            protected int conjunto;
            protected int destino;
        }

        public class Propiedad
        {
            protected int id;
            protected int jugador;
            protected int partida;
            protected int casilla;
            protected int nivelEdificacion;
        }

        public class TipoCartas
        {
            protected int id;
            protected string descripcion;
        }

        public class Carta
        {
            protected int id;
            protected int tablero;
            protected int conjunto;
            protected int tipo;
            protected int valor;
        }
    }
}
