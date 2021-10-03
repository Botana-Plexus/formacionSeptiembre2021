using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanaPolyAPI
{

    public class Usuario
    {
        public string email { get; set; }
        public string? pass { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string nick { get; set; }

        public Usuario()
        {
        }

        public Usuario(string email, string? pass, DateTime fechaNacimiento, string nick)
        {
            this.email = email;
            this.pass = pass;
            this.fechaNacimiento = fechaNacimiento;
            this.nick = nick;
        }

        public Usuario(object[] array)
        {
            this.email = (string)array[1];
            this.nick = (string)array[2];
            this.pass = array[4] != System.DBNull.Value ? (string)array[4] : null;
            this.fechaNacimiento = (DateTime)array[3];
        }
    }
}
