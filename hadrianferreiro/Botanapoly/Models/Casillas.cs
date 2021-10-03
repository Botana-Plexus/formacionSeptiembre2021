using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Botanapoly.Models
{
    public class Casillas
    {
        public int id { get; set; }
        public int tipo { get; set; }
        public string nombre { get; set; }
        public int orden { get; set; }
        public int precioCompra { get; set; }
        public int precioVenta { get; set; }
        public int costeEdificacion { get; set; }
        public int precioVentaEdificacion { get; set; }
        public int Coste1 { get; set; }
        public int Coste2 { get; set; }
        public int Coste3 { get; set; }
        public int Coste4 { get; set; }
        public int Coste5 { get; set; }
        public int Coste6 { get; set; }
        public int conjunto { get; set; }
        public int destino { get; set; }

        [JsonConstructor]
        public Casillas(int id, int tipo, string nombre, int orden, int precioCompra, int precioVenta, int costeEdificacion, int precioVentaEdificacion, int coste1, int coste2, int coste3, int coste4, int coste5, int coste6, int conjunto, int destino)
        {
            this.id = id;
            this.tipo = tipo;
            this.nombre = nombre;
            this.orden = orden;
            this.precioCompra = precioCompra;
            this.precioVenta = precioVenta;
            this.costeEdificacion = costeEdificacion;
            this.precioVentaEdificacion = precioVentaEdificacion;
            Coste1 = coste1;
            Coste2 = coste2;
            Coste3 = coste3;
            Coste4 = coste4;
            Coste5 = coste5;
            Coste6 = coste6;
            this.conjunto = conjunto;
            this.destino = destino;
        }

        public Casillas(object[] array)
        {
            this.id = (int)array[0];
            this.tipo = (int)array[1];
            this.nombre = (string)array[2];
            this.orden = (int)array[3];
            if (array[4] != System.DBNull.Value) this.precioCompra = (int)array[4];
            if (array[5] != System.DBNull.Value) this.precioVenta = (int)array[5];
            if (array[6] != System.DBNull.Value) this.costeEdificacion = (int)array[6];
            if (array[7] != System.DBNull.Value) this.precioVentaEdificacion = (int)array[7];
            if (array[8] != System.DBNull.Value) Coste1 = (int)array[8];
            if (array[9] != System.DBNull.Value) Coste2 = (int)array[9];
            if (array[10] != System.DBNull.Value) Coste3 = (int)array[10];
            if (array[11] != System.DBNull.Value) Coste4 = (int)array[11];
            if (array[12] != System.DBNull.Value) Coste5 = (int)array[12];
            if (array[13] != System.DBNull.Value) Coste6 = (int)array[13];
            if (array[14] != System.DBNull.Value) this.conjunto = (int)array[14];
            if (array[15] != System.DBNull.Value) this.destino = (int)array[15];
        }

    }
}
