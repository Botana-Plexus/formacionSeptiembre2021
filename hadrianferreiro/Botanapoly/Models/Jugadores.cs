using System.Text.Json.Serialization;

namespace Botanapoly.Models
{
    public class Jugadores
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idPartida { get; set; }
        public int saldo { get; set; }
        public int orden { get; set; }
        public int posicion { get; set; }
        public string partidaPass { get; set; }
        public int dobles { get; set; }
        public int turnosDeCastigo { get; set; }
        public int deuda { get; set; }
        public string acreedor { get; set; }
        public int casillaEspecifica { get; set; }
        public int tirada { get; set; }

        public Jugadores()
        {
        }

        [JsonConstructor]
        public Jugadores(int id, int idUsuario, int idPartida, int saldo, int orden, int posicion, string partidaPass)
        {
            this.id = id;
            this.idUsuario = idUsuario;
            this.idPartida = idPartida;
            this.saldo = saldo;
            this.orden = orden;
            this.posicion = posicion;
            this.partidaPass = partidaPass;
        }

        public Jugadores(object[] array)
        {
            this.id = (int)array[0];
            if (array[1] != System.DBNull.Value) this.idUsuario = (int)array[1];
            this.idPartida = (int)array[2];
            this.saldo = (int)array[3];
            this.orden = (int)array[4];
            if (array[5] != System.DBNull.Value) this.posicion = (int)array[5];
            this.dobles = (int)array[6];
            this.turnosDeCastigo = (int)array[7];
        }
    }
}
