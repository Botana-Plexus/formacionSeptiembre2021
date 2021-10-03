using System.Text.Json.Serialization;

namespace Botanapoly.Models
{
    public class Tableros
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int importe { get; set; }
        public int numCasillas { get; set; }

        [JsonConstructor]
        public Tableros(int id, string descripcion, int importe, int numCasillas)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.importe = importe;
            this.numCasillas = numCasillas;
        }

        public Tableros(object[] array)
        {
            this.id = (int)array[0];
            this.descripcion = (string)array[1];
            this.importe = (int)array[2];
            this.numCasillas = (int)array[3];
        }

    }
}
