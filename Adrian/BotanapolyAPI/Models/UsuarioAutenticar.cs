using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyAPI.Models
{
    public class UsuarioAutenticar
    {
        private string? email;
        public string? Email
        {
            get => email;
            set => email = value;
        }
        private string? pass;
        public string? Pass
        {
            get => pass;
            set => pass = value;
        }
    }
}
