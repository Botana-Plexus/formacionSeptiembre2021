using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Botanapoly.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public Database BD = new Database();

        //AUTENTICAR USUARIO
        [HttpPost("login")]
        public string autenticar(string email, string pass)
        {

            string consulta = $"autenticar '{email}', '{pass}'";

            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            return dt.Rows[0]["Column2"].ToString();
        }

        //REGISTRAR USUARIO
        [HttpPost("registrar")]
        public string addUser([FromBody] Usuarios usuario)
        {
            string consulta = $"registrar'{usuario.email}','{usuario.nick}','{usuario.pass}','{usuario.fechaNacimiento}'";

            return BD.ejecutarConsultaInsert(consulta);

        }
    }
}

