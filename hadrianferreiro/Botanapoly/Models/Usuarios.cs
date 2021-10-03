using System;

namespace Botanapoly.Models
{
    public class Usuarios
    {
        public string email { get; set; }
        public string nick { get; set; }
        public string pass { get; set; }
        public DateTime fechaNacimiento { get; set; }

        
        public Usuarios(string email, string nick, string pass, DateTime fechaNacimiento)
        {
            this.email = email;
            this.nick = nick;
            this.pass = pass;
            this.fechaNacimiento = fechaNacimiento;
        }

    }
}
