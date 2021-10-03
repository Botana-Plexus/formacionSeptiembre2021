using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyV1.Modelos.Dto
{
    public class CartaModeloDto
    {
        public int id { get; set; }
        public string texto { get; set; }
        public int tablero  {get; set;}
        public int conjunto  {get; set;}
        public int tipo  {get; set;}
        public int valor  {get; set;}
    }
}
