using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Botanapoly
{
    public class Usuario
    {
        public int id { set; get; }
        public string email { set; get; }
        public string nick { set; get; }
        public string pass { set; get; }
        public DateTime fechaNacimiento { set; get; }


        public Usuario(int id, string email, string nick, string pass, DateTime fechaNacimiento)
        {
            this.id = id;
            this.email = email;
            this.nick = nick;
            this.pass = pass;
            this.fechaNacimiento = fechaNacimiento;
        }
    }


}