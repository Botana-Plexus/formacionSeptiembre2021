using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BotanapolyV1.Modelos.Dto
{
    //SOLO ATRIBUTOS Y PROPIEDADES [NO METODOS]
    public class UsuarioModeloDto
    {
       
        public int id { get; set; }
        public string email { get; set; }
        public string nick { get; set; } 
        public string password { get; set; }
        public DateTime fechaNacimiento { get; set; }
     

        public UsuarioModeloDto()
        {
            
        }

        public UsuarioModeloDto(int id, string email, string nick, string password, DateTime fechaNacimiento)
        {
            this.id = id;
            this.email = email;
            this.nick = nick;
            this.password = password;
            this.fechaNacimiento = fechaNacimiento;
        }

        public UsuarioModeloDto(Object[] array)
        {
            this.id = (int)array[0];
            this.email = (string)array[1];
            this.nick = (string)array[2];
            this.password = (string)array[3];// != System.DBNull.Value ? (string)array[4] : null;
            this.fechaNacimiento = (DateTime)array[4];
        }
       
    }
}
