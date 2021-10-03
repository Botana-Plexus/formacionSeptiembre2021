using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyV1.Modelos.Dto
{
    public class TableroModeloDto
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int importe { get; set; }
        public int numCasillas { get; set; }
    }
}
