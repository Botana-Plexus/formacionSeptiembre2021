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

        //GET USERS
        [HttpGet("listaUsuarios")]
        public List<Usuarios> listarUsuarios()
        {

            string consulta = @"select * from usuarios";

            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            var lista = new List<Usuarios>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Usuarios usuario = new Usuarios();
                usuario.id = Convert.ToInt32(dt.Rows[i]["id"]);
                usuario.email = dt.Rows[i]["email"].ToString();
                usuario.nick = dt.Rows[i]["nick"].ToString();
                usuario.fechaNacimiento = (DateTime)dt.Rows[i]["fechaNacimiento"];
                lista.Add(usuario);
            }

            return lista;
        }

            
        
        }




    }

