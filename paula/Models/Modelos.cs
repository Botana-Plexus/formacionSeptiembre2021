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
            protected int tiempoTranscurrido;
            public int TiempoTranscurrido
            {
                get => tiempoTranscurrido;
                set => tiempoTranscurrido = value;
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

            protected int tienePass;
            public int TienePass
            {
                get => tienePass;
                set => tienePass = value;
            }
        }
        

        public class Jugador
        {
            protected int id;
            public int Id
            {
                get => id;
                set => id = value;
            }
            protected int acreedor;
            public int Acreedor
            {
                get => acreedor;
                set => acreedor = value;
            }
            protected int turnosDeCastigo;
            public int TurnosDeCastigo
            {
                get => turnosDeCastigo;
                set => turnosDeCastigo = value;
            }
            protected int dobles;
            public int Dobles
            {
                get => dobles;
                set => dobles = value;
            }
            protected int idUsuario;
            public int IdUsuario
            {
                get => idUsuario;
                set => idUsuario = value;
            }
            protected int idPartida;
            public int IdPartida
            {
                get => idPartida;
                set => idPartida = value;
            }
            protected int saldo;
            public int Saldo
            {
                get => saldo;
                set => saldo = value;
            }
            protected int orden;
            public int Orden
            {
                get => orden;
                set => orden = value;
            }
            protected int posicion;
            public int Posicion
            {
                get => posicion;
                set => posicion = value;
            }
        }


        public class Usuario
        {
            protected int id;
            public int Id
            {
                get => id;
                set => id = value;
            }
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
        }

        public class Casilla
        {
            protected int id;
            public int Id
            {
                get => id;
                set => id = value;
            }
            protected int tipo;
            public int Tipo
            {
                get => tipo;
                set => tipo = value;
            }
            protected int tablero;
            public int Tablero{
                get => tablero;
                set => tablero = value;
                }
            protected string nombre;
            public string Nombre
            {
                get => nombre;
                set => nombre = value;
            }
            protected int orden;
            public int Orden{
                get => orden;
                set => orden = value;
                }
            protected int precioCompra;
            public int PrecioCompra{
                get => precioCompra;
                set => precioCompra = value;
                }
            protected int precioVenta;
            public int PrecioVenta{
                get => precioVenta;
                set => precioVenta = value;
                }
            protected int costeEdificacion;
            public int CosteEdificacion{
                get => costeEdificacion;
                set => costeEdificacion = value;
                }
            protected int precioVentaEdificacion;
            public int PrecioVentaEdificacion{
                get => precioVentaEdificacion;
                set => precioVentaEdificacion = value;
                }
            protected int coste1;
            public int Coste1{
                get => coste1;
                set => coste1 = value;
                }
            protected int coste2;
            public int Coste2{
                get => coste2;
                set => coste2 = value;
                }
            protected int coste3;
            public int Coste3{
                get => coste3;
                set => coste3 = value;
                }
            protected int coste4;
            public int Coste4{
                get => coste4;
                set => coste4 = value;
                }
            protected int coste5;
            public int Coste5{
                get => coste5;
                set => coste5 = value;
                }
            protected int coste6;
            public int Coste6
            {
                get => coste6;
                set => coste6 = value;
            }
            protected int conjunto;
            public int Conjunto{
                get => conjunto;
                set => conjunto = value;
                }
            protected int destino;
            public int Destino{
                get => destino;
                set => destino = value;
                }
            protected int propietario;
            public int Propietario
            {
                get => propietario;
                set => propietario = value;
            }
        }

        public class Propiedad
        {
            protected int id;
            public int Id
            {
                get => id;
                set => id = value;
            }
            protected int jugador;
            public int Jugador
            {
                get => jugador;
                set => jugador = value;
            }
            protected int partida;
            public int Partida
            {
                get => partida;
                set => partida = value;
            }
            protected int casilla;
            public int Casilla
            {
                get => casilla;
                set => casilla = value;
            }
            protected int nivelEdificacion;
            public int NivelEdificacion
            {
                get => nivelEdificacion;
                set => nivelEdificacion = value;
            }
        }


        public class PropiedadesJugador
        {
            protected int id;
            public int Id
            {
                get => id;
                set => id = value;
            }
            protected int tipo;
            public int Tipo
            {
                get => tipo;
                set => tipo = value;
            }
            protected int tablero;
            public int Tablero
            {
                get => tablero;
                set => tablero = value;
            }
            protected string nombre;
            public string Nombre
            {
                get => nombre;
                set => nombre = value;
            }
            protected int orden;
            public int Orden
            {
                get => orden;
                set => orden = value;
            }
            protected int precioCompra;
            public int PrecioCompra
            {
                get => precioCompra;
                set => precioCompra = value;
            }
            protected int precioVenta;
            public int PrecioVenta
            {
                get => precioVenta;
                set => precioVenta = value;
            }
            protected int costeEdificacion;
            public int CosteEdificacion
            {
                get => costeEdificacion;
                set => costeEdificacion = value;
            }
            protected int precioVentaEdificacion;
            public int PrecioVentaEdificacion
            {
                get => precioVentaEdificacion;
                set => precioVentaEdificacion = value;
            }
            protected int coste1;
            public int Coste1
            {
                get => coste1;
                set => coste1 = value;
            }
            protected int coste2;
            public int Coste2
            {
                get => coste2;
                set => coste2 = value;
            }
            protected int coste3;
            public int Coste3
            {
                get => coste3;
                set => coste3 = value;
            }
            protected int coste4;
            public int Coste4
            {
                get => coste4;
                set => coste4 = value;
            }
            protected int coste5;
            public int Coste5
            {
                get => coste5;
                set => coste5 = value;
            }
            protected int coste6;
            public int Coste6
            {
                get => coste6;
                set => coste6 = value;
            }
            protected int conjunto;
            public int Conjunto
            {
                get => conjunto;
                set => conjunto = value;
            }
            protected int destino;
            public int Destino
            {
                get => destino;
                set => destino = value;
            }

            protected int nivelEdificacion;
            public int NivelEdificacion
            {
                get => nivelEdificacion;
                set => nivelEdificacion = value;
            }
        }

        public class TipoCartas
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
        }

        public class Carta
        {
            protected int id;
            public int Id
            {
                get => id;
                set => id = value;
            }
            protected int tablero;
            public int Tablero{
                get => tablero;
                set => tablero = value;
                }
            protected int conjunto;
            public int Conjunto{
                get => conjunto;
                set => conjunto = value;
                }
            protected int tipo;
            public int Tipo{
                get => tipo;
                set => tipo = value;
                }
            protected string texto;
            public string Texto
            {
                get => texto;
                set => texto = value;
            }
            protected int valor;
            public int Valor{
                get => valor;
                set => valor = value;
                }
        }
    }
}
