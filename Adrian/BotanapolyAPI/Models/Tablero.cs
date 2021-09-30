using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BotanapolyAPI.Controllers
{
    public class Tablero
    {
        private int? id;
        public int? Id
        {
            get => id;
            set => id = value;
        }
        private string? descripcion;
        public string? Descripcion
        {
            get => descripcion;
            set => descripcion = value;
        }
        private int? importe;
        public int? Importe
        {
            get => importe;
            set => importe = value;
        }
        private int? numCasillas;
        public int? NumCasillas
        {
            get => numCasillas;
            set => numCasillas = value;
        }
        [JsonConstructor]
        public Tablero(int? id, string? descripcion, int? importe, int? numCasillas)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.importe = importe;
            this.numCasillas = numCasillas;
        }
        public Tablero(object[] info)
        {
            this.id = info[0] != System.DBNull.Value ? (int)info[0] : null;
            this.descripcion = info[1] != System.DBNull.Value ? (string)info[1] : null;
            this.importe = info[2] != System.DBNull.Value ? (int)info[2] : null;
            this.numCasillas = info[3] != System.DBNull.Value ? (int)info[3] : null;
        }
    }
}
