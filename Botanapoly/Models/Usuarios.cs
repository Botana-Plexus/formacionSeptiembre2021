using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botanapoly.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nick { get; set; }
        public string Pass { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public virtual ICollection<Partidas> Partidas { get; set; }

    }
}
