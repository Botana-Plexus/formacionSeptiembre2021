using System;

namespace monopoly
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
    public class Autenticar{
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
        public int  tablero { get; set; }
    }
    public class UnirsePartida
    {
        public int idUsuario { get; set; }
        public int idPartida { get; set; }
    }
    public class ComenzarPartida
    {
        public int idPartida { get; set; }
    }
}