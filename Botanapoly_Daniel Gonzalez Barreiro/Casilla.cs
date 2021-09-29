using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Botanapoly
{
    public class Casilla
    {
        public int id { set; get; }
        public int tipo { set; get; }
        public int tablero { set; get; }
        public string nombre { set; get; }
        public int orden { set; get; } //orden dentro del tablero.debe comenzar en 1 y solo puede haber una 1, aunque se podria repetir algun orden
        public int precioCompra { set; get; }
        public int precioVenta { set; get; }
        public int nivelEdificacion { set; get; }
        public int costeEdificacion { set; get; }
        public int precioVentaEdificacion { set; get; }
        public int Coste1 { set; get; }
        public int Coste2 { set; get; }
        public int Coste3 { set; get; }
        public int Coste4 { set; get; }
        public int Coste5 { set; get; }
        public int conjunto { set; get; }
        public int destino { set; get; } //casilla destino para castigo, por ejemplo

        public Casilla(
        int id, int tipo, int tablero, string nombre, int orden,
        int precioCompra, int precioVenta, int nivelEdificacion,
        int costeEdificacion, int precioVentaEdificacion, int Coste1, int Coste2,
        int Coste3, int Coste4, int conjunto, int destino

        )
        {
            this.id = id;
            this.tipo = tipo;
            this.tablero = tablero;
            this.nombre = nombre;
            this.orden = orden;
            this.precioCompra = precioCompra;
            this.precioVenta = precioVenta;
            this.nivelEdificacion = nivelEdificacion;
            this.costeEdificacion = costeEdificacion;
            this.precioVentaEdificacion = precioVentaEdificacion;
            this.Coste1 = Coste1;
            this.Coste2 = Coste2;
            this.Coste3 = Coste3;
            this.Coste4 = Coste4;
            this.conjunto = conjunto;
            this.destino = destino;


        }
    }
}