using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BotanapolyAPI.Models
{
    public class Partida
    {
        private int? id;
        public int? Id
        {
            get => id;
            set => id = value;
        }
        private string? nombre;
        public string? Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        private int? administrador;
        public int? Administrador
        {
            get => administrador;
            set => administrador = value;
        }
        private int? maxJugadores;
        public int? MaxJugadores
        {
            get => maxJugadores;
            set => maxJugadores = value;
        }
        private int? maxTiempo;
        public int? MaxTiempo
        {
            get => maxTiempo;
            set => maxTiempo = value;
        }
        private DateTime? fechaInicio;
        public DateTime? FechaInicio
        {
            get => fechaInicio;
            set => fechaInicio = value;
        }
        private int? tiempoTranscurrido;
        public int? TiempoTranscurrido
        {
            get => tiempoTranscurrido;
            set => tiempoTranscurrido = value;
        }
        private string? pass;
        public string? Pass
        {
            get => pass;
            set => pass = value;
        }
        private int? numJugadores;
        public int? NumJugadores
        {
            get => numJugadores;
            set => numJugadores = value;
        }
        private int? turno;
        public int? Turno
        {
            get => turno;
            set => turno = value;
        }
        private int? estado;
        public int? Estado
        {
            get => estado;
            set => estado = value;
        }
        private int? tablero;
        public int? Tablero
        {
            get => tablero;
            set => tablero = value;
        }
        [JsonConstructor]
        public Partida(int? id, string nombre, int? administrador, int? maxJugadores, int? maxTiempo, DateTime? fechaInicio, int? tiempoTranscurrido, string pass, int? numJugadores, int? turno, int? estado, int? tablero)
        {
            this.id = id;
            this.nombre = nombre;
            this.administrador = administrador;
            this.maxJugadores = maxJugadores;
            this.maxTiempo = maxTiempo;
            this.fechaInicio = fechaInicio;
            this.tiempoTranscurrido = tiempoTranscurrido;
            this.pass = pass;
            this.numJugadores = numJugadores;
            this.turno = turno;
            this.estado = estado;
            this.tablero = tablero;
        }

        public Partida(object[] info)
        {
            this.id = info[0] != System.DBNull.Value ? (int)info[0] : null ;
            this.nombre = info[1] != System.DBNull.Value ? (string)info[1] : null;
            this.maxJugadores = info[2] != System.DBNull.Value ? (int)info[2] : null;
            this.maxTiempo = info[3] != System.DBNull.Value ? (int)info[3] : null;
            this.tiempoTranscurrido = info[4] != System.DBNull.Value ? (int)info[4] : null;
            this.pass = info[5] != System.DBNull.Value ? info[5].ToString() : null;
            this.numJugadores = info[6] != System.DBNull.Value ? (int)info[6] : null;
            this.turno = info[7] != System.DBNull.Value ? (int)info[7] : null;
            this.estado = info[8] != System.DBNull.Value ? (int)info[8] : null;
            this.tablero = info[9] != System.DBNull.Value ? (int)info[9] : null;
        }
    }
}
