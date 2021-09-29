using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Botanapoly
{
    public class Tableros
    {
        public int id { set; get; }
        public string descripcion { set; get; }
        public int importe { get; set; }
        public int numCasillas { get; set; }

    }
}
