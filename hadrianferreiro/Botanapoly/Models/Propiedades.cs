using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botanapoly.Models
{
    public class Propiedades
    {
        public int id { get; set; }
        public int tipo { get; set; }
        public int tablero { get; set; }
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
        public int conjutno { get; set; }
        public int destino { get; set; }
        public int nivelEdificacion { get; set; }

        public Propiedades(object[] array)
        {
            this.id = (int)array[0];
            this.tipo = (int)array[1];
            this.tablero = (int)array[2];
            this.nombre = (string)array[3];
            this.orden = (int)array[4];
            this.precioCompra = (int)array[5];
            this.precioVenta = (int)array[6];
            if (array[7] != System.DBNull.Value) this.costeEdificacion = (int)array[7];
            if (array[8] != System.DBNull.Value) this.precioVentaEdificacion = (int)array[8];
            if (array[9] != System.DBNull.Value) Coste1 = (int)array[9];
            if (array[10] != System.DBNull.Value) Coste2 = (int)array[10];
            if (array[11] != System.DBNull.Value) Coste3 = (int)array[11];
            if (array[12] != System.DBNull.Value) Coste4 = (int)array[12];
            if (array[13] != System.DBNull.Value) Coste5 = (int)array[13];
            if (array[14] != System.DBNull.Value) Coste6 = (int)array[14];
            this.conjutno = (int)array[15];
            if (array[16] != System.DBNull.Value) this.destino = (int)array[16];
            if (array[17] != System.DBNull.Value) this.nivelEdificacion = (int)array[17];
        }
    }
}
