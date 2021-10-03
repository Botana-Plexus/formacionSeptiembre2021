using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI
{
    public class Propiedades
    {
        public int tipo { get; set; }
        public int tablero { get; set; }
        public string nombre { get; set; }
        public int orden { get; set; }
        public int? precioCompra { get; set; }
        public int? precioVenta { get; set; }
        public int? nivelEdificacion { get; set; }
        public int? precioVentaEdificacion { get; set; }
        public int? coste1 { get; set; }
        public int? coste2 { get; set; }
        public int? coste3 { get; set; }
        public int? coste4 { get; set; }
        public int? coste5 { get; set; }
        public int? coste6 { get; set; }
        public int? conjunto { get; set; }
        public int? destino { get; set; }
        public int? costeEdificacion { get; set; }

        public Propiedades(int tipo, int tablero, string nombre, int orden, int? precioCompra, int? precioVenta, int? nivelEdificacion, int? precioVentaEdificacion, int? coste1, int? coste2, int? coste3, int? coste4, int? coste5, int? coste6, int? conjunto, int? destino, int? costeEdificacion)
        {
            this.tipo = tipo;
            this.tablero = tablero;
            this.nombre = nombre;
            this.orden = orden;
            this.precioCompra = precioCompra;
            this.precioVenta = precioVenta;
            this.nivelEdificacion = nivelEdificacion;
            this.precioVentaEdificacion = precioVentaEdificacion;
            this.coste1 = coste1;
            this.coste2 = coste2;
            this.coste3 = coste3;
            this.coste4 = coste4;
            this.coste5 = coste5;
            this.coste6 = coste6;
            this.conjunto = conjunto;
            this.destino = destino;
            this.costeEdificacion = costeEdificacion;
        }

        public Propiedades(object[] array)
        {
            this.tipo = (int)array[1];
            this.tablero = (int)array[2];
            this.nombre = (string)array[3];
            this.orden = (int)array[4];
            this.precioCompra = array[5] != System.DBNull.Value ? (int)array[5] : null;
            this.precioVenta = array[6] != System.DBNull.Value ? (int)array[6] : null;
            this.costeEdificacion = array[7] != System.DBNull.Value ? (int)array[7] : null;
            this.precioVentaEdificacion = array[8] != System.DBNull.Value ? (int)array[8] : null;
            this.coste1 = array[9] != System.DBNull.Value ? (int)array[9] : null;
            this.coste2 = array[10] != System.DBNull.Value ? (int)array[10] : null;
            this.coste3 = array[11] != System.DBNull.Value ? (int)array[11] : null;
            this.coste4 = array[12] != System.DBNull.Value ? (int)array[12] : null;
            this.coste5 = array[13] != System.DBNull.Value ? (int)array[13] : null;
            this.coste6 = array[14] != System.DBNull.Value ? (int)array[14] : null;
            this.conjunto = array[15] != System.DBNull.Value ? (int)array[15] : null;
            this.destino = array[16] != System.DBNull.Value ? (int)array[16] : null;
            this.nivelEdificacion = array[17] != System.DBNull.Value ? (int)array[17] : null;
        }
    }
}
