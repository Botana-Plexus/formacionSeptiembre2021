using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BotanapolyAPI.Models
{
    public class Jugador
    {
        private int? id;
        public int? Id
        {
            get => id;
            set => id = value;
        }
        private int? idUsuario;
        public int? IdUsuario
        {
            get => idUsuario;
            set => idUsuario = value;
        }
        private int? idPartida;
        public int? IdPartida
        {
            get => idPartida;
            set => idPartida = value;
        }
        private int? saldo;
        public int? Saldo
        {
            get => saldo;
            set => saldo = value;
        }
        private int? orden;
        public int? Orden
        {
            get => orden;
            set => orden = value;
        }
        private int? posicion;
        public int? Posicion
        {
            get => posicion;
            set => posicion = value;
        }
        private int? dobles;
        public int? Dobles
        {
            get => dobles;
            set => dobles = value;
        }
        private int? turnosDeCastigo;
        public int? TurnosDeCastigo
        {
            get => turnosDeCastigo;
            set => turnosDeCastigo = value;
        }
        private int? deuda;
        public int? Deuda
        {
            get => deuda;
            set => deuda = value;
        }
        private int? acreedor;
        public int? Acreedor
        {
            get => acreedor;
            set => acreedor = value;
        }
        [JsonConstructor]
        public Jugador(int? id, int? idUsuario, int? idPartida, int? saldo, int? orden, int? posicion, int? dobles, int? turnosDeCastigo, int? deuda, int? acreedor)
        {
            this.id = id;
            this.idUsuario = idUsuario;
            this.idPartida = idPartida;
            this.saldo = saldo;
            this.orden = orden;
            this.posicion = posicion;
            this.dobles = dobles;
            this.turnosDeCastigo = turnosDeCastigo;
            this.deuda = deuda;
            this.acreedor = acreedor;
        }
        public Jugador(object[] info)
        {
            this.id = info[0] != System.DBNull.Value ? (int)info[0] : null;
            this.idUsuario = info[1] != System.DBNull.Value ? (int)info[1] : null;
            this.idPartida = info[2] != System.DBNull.Value ? (int)info[2] : null;
            this.saldo = info[3] != System.DBNull.Value ? (int)info[3] : null;
            this.orden = info[4] != System.DBNull.Value ? (int)info[4] : null;
            this.posicion = info[5] != System.DBNull.Value ? (int)info[5] : null;
            this.dobles = info[6] != System.DBNull.Value ? (int)info[6] : null;
            this.turnosDeCastigo = info[7] != System.DBNull.Value ? (int)info[7] : null;
            this.deuda = info[8] != System.DBNull.Value ? (int)info[8] : null;
            this.acreedor = info[9] != System.DBNull.Value ? (int)info[9] : null;
        }
    }
}
