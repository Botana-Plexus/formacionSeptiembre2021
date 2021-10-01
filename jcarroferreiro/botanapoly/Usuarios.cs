using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace botanapoly
{
    public class Usuarios
    {
        /*
            Estructura de la tabla usuario de BBDD
         */
        public int id { get; set; }
        public string email { get; set; }
        public string nick { get; set; }
        public string pass { get; set; }
        public string fechaNacimiento { get; set; }

    }
    public class Autenticar
    {
        public string email { get; set; }
        public string pass { get; set; }
    }
    public class Tablero
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int importe { get; set; }
        public int numCasillas { get; set; }
    }
    public class CrearPartida
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int admin { get; set; }
        public int maxJugadores { get; set; }
        public int maxTiempo { get; set; }
        public string pass { get; set; }
        public int tablero { get; set; }
    }
    public class AnadirJugador
    {
        public int idUsuario { get; set; }
        public int idPartida { get; set; }
    }
    public class getPartidas
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int maxJugadores { get; set; }
        public int? maxTiempo { get; set; }
        public int tiempoTranscurrido { get; set; }
        public int numJugadores { get; set; }
        public int turno { get; set; }
        public int estado { get; set; }
        public int tablero { get; set; }
    }
    public class getTablero
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int importe { get; set; }
        public int numCasillas { get; set; }
    }
    public class ComenzarPartida
    {
        public int idPartida { get; set; }
    }

    public class getJugadoresInfo
    {
        public int id { get; set; }
        public int? idUsuario { get; set; }
        public int idPartida { get; set; }
        public int saldo { get; set; }
        public int orden { get; set; }
        public int posicion { get; set; }
        public int dobles { get; set; }
        public int turnosDeCastigo { get; set; }

    }
    public class getCasillas
    {
        public int id { get; set; }
        public int tipo { get; set; }
        public string nombre { get; set; }
        public int orden { get; set; }
        public int? precioCompra { get; set; }
        public int? precioVenta { get; set; }
        public int? costeEdificacion { get; set; }
        public int? precioVentaEdificacion { get; set; }
        public int? Coste1 { get; set; }
        public int? Coste2 { get; set; }
        public int? Coste3 { get; set; }
        public int? Coste4 { get; set; }
        public int? Coste5 { get; set; }
        public int? conjunto { get; set; }
        public int? destino { get; set; }
    }

    //public class ActualizarNivelConstruccion
    //{
    //    public int idJugador { get; set; }
    //    public int tipo { get; set; }
    //}
}
