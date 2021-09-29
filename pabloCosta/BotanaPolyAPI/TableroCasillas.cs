namespace BotanaPolyAPI
{
    public class TableroCasillas
    {
        public int id;
        public string descripcion;
        public int tipo;
        public string nombre;
        public int orden;
        public int precioCompra;
        public int precioVenta;
        public int nivelEdificacion;
        public int costeEdificacion;
        public int precioVentaEdificacion;
        public int coste1;
        public int coste2;
        public int coste3;
        public int coste4;
        public int coste5;
        public int conjunto;
        public int destino;

        public TableroCasillas(int id, string descripcion, int tipo, string nombre, int orden, int precioCompra, int precioVenta, int nivelEdificacion, int costeEdificacion, int precioVentaEdificacion, int coste1, int coste2, int coste3, int coste4, int coste5, int conjunto, int destino)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.tipo = tipo;
            this.nombre = nombre;
            this.orden = orden;
            this.precioCompra = precioCompra;
            this.precioVenta = precioVenta;
            this.nivelEdificacion = nivelEdificacion;
            this.costeEdificacion = costeEdificacion;
            this.precioVentaEdificacion = precioVentaEdificacion;
            this.coste1 = coste1;
            this.coste2 = coste2;
            this.coste3 = coste3;
            this.coste4 = coste4;
            this.coste5 = coste5;
            this.conjunto = conjunto;
            this.destino = destino;
        }

        public TableroCasillas(object[] array)
        {
            this.id = (int)array[0];
            this.descripcion = (string)array[1];
            this.tipo = (int)array[2];
            this.nombre = (string)array[3];
            this.orden = (int)array[4];
            this.precioCompra = (int)array[5];
            this.precioVenta = (int)array[6];
            this.nivelEdificacion = (int)array[7];
            this.costeEdificacion = (int)array[8];
            this.precioVentaEdificacion = (int)array[9];
            this.coste1 = (int)array[10];
            this.coste2 = (int)array[11];
            this.coste3 = (int)array[12];
            this.coste4 = (int)array[13];
            this.coste5 = (int)array[14];
            this.conjunto = (int)array[15];
            this.destino = (int)array[16];
        }
    }
}
