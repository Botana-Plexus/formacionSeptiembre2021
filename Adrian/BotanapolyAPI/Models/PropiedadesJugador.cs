using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BotanapolyAPI.Models
{
    public class PropiedadesJugador
    {
        private int? id;
        public int? Id
        {
            get => id;
            set => id = value;
        }
        private int? tipo;
        public int? Tipo
        {
            get => tipo;
            set => tipo = value;
        }
        private int? tablero;
        public int? Tablero
        {
            get => tablero;
            set => tablero = value;
        }
        private string? nombre;
        public string? Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        private int? orden;
        public int? Orden
        {
            get => orden;
            set => orden = value;
        }
        private int? precioCompra;
        public int? PrecioCompra
        {
            get => precioCompra;
            set => precioCompra = value;
        }
        private int? precioVenta;
        public int? PrecioVenta
        {
            get => precioVenta;
            set => precioVenta = value;
        }
        private int? costeEdificacion;
        public int? CosteEdificacion
        {
            get => costeEdificacion;
            set => costeEdificacion = value;
        }
        private int? precioVentaEdificacion;
        public int? PrecioVentaEdificacion
        {
            get => precioVentaEdificacion;
            set => precioVentaEdificacion = value;
        }
        private int? coste1;
        public int? Coste1
        {
            get => coste1;
            set => coste1 = value;
        }
        private int? coste2;
        public int? Coste2
        {
            get => coste2;
            set => coste2 = value;
        }
        private int? coste3;
        public int? Coste3
        {
            get => coste3;
            set => coste3 = value;
        }
        private int? coste4;
        public int? Coste4
        {
            get => coste4;
            set => coste4 = value;
        }
        private int? coste5;
        public int? Coste5
        {
            get => coste5;
            set => coste5 = value;
        }
        private int? coste6;
        public int? Coste6
        {
            get => coste6;
            set => coste6 = value;
        }
        private int? conjunto;
        public int? Conjunto
        {
            get => conjunto;
            set => conjunto = value;
        }
        private int? destino;
        public int? Destino
        {
            get => destino;
            set => destino = value;
        }
        private int? nivelEdificacion;
        public int? NivelEdificacion
        {
            get => nivelEdificacion;
            set => nivelEdificacion = value;
        }

        [JsonConstructor]
        public PropiedadesJugador(int? id, int? tipo, int? tablero, string nombre, int? orden, int? precioCompra, int? precioVenta, int? costeEdificacion, int? precioVentaEdificacion, int? coste1, int? coste2, int? coste3, int? coste4, int? coste5, int? coste6, int? conjunto, int? destino, int? nivelEdificacion)
        {
            this.id = id;
            this.tipo = tipo;
            this.tablero = tablero;
            this.nombre = nombre;
            this.orden = orden;
            this.precioCompra = precioCompra;
            this.precioVenta = precioVenta;
            this.costeEdificacion = costeEdificacion;
            this.precioVentaEdificacion = precioVentaEdificacion;
            this.coste1 = coste1;
            this.coste2 = coste2;
            this.coste3 = coste3;
            this.coste4 = coste4;
            this.coste5 = coste5;
            this.coste6 = coste6;
            this.conjunto = conjunto;
            this.destino = destino;
            this.nivelEdificacion = nivelEdificacion;
        }

        public PropiedadesJugador(object[] info)
        {
            this.id = info[0] != System.DBNull.Value ? (int)info[0] : null;
            this.tipo = info[1] != System.DBNull.Value ? (int)info[1] : null;
            this.tablero = info[2] != System.DBNull.Value ? (int)info[2] : null;
            this.nombre = info[3] != System.DBNull.Value ? (string)info[3] : null;
            this.orden = info[4] != System.DBNull.Value ? (int)info[4] : null;
            this.precioCompra = info[5] != System.DBNull.Value ? (int)info[5] : null;
            this.precioVenta = info[6] != System.DBNull.Value ? (int)info[6] : null;
            this.costeEdificacion = info[7] != System.DBNull.Value ? (int)info[7] : null;
            this.precioVentaEdificacion = info[8] != System.DBNull.Value ? (int)info[8] : null;
            this.coste1 = info[9] != System.DBNull.Value ? (int)info[9] : null;
            this.coste2 = info[10] != System.DBNull.Value ? (int)info[10] : null;
            this.coste3 = info[11] != System.DBNull.Value ? (int)info[11] : null;
            this.coste4 = info[12] != System.DBNull.Value ? (int)info[12] : null;
            this.coste5 = info[13] != System.DBNull.Value ? (int)info[13] : null;
            this.coste6 = info[14] != System.DBNull.Value ? (int)info[14] : null;
            this.conjunto = info[15] != System.DBNull.Value ? (int)info[15] : null;
            this.destino = info[16] != System.DBNull.Value ? (int)info[16] : null;
            this.nivelEdificacion = info[17] != System.DBNull.Value ? (int)info[17] : null;
        }
    }
}
