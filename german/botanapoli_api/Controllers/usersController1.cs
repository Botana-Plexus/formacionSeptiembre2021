using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT = System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanapoli_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController1 : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost("autenticar")]
        public int Authenticate([FromBody] Autenticado usuario)
        {
            string query = $"autenticar '{usuario.email}', '{usuario.pass}';";
            DbController conexion = new DbController("localhost", "botanapoly", "sqladmin", "password");
                return conexion.DbInsertQuery(query);
            //try
            //{
                //DT.DataTable dt = conexion.DbRetrieveQuery(query);

                //if (usuario.email.Equals(dt.Rows[0]["email"]) && usuario.pass.Equals(dt.Rows[0]["pass"]))
                //{
                //    return "puedes acceder";
                //}
                //else
                //{
                //    return "credenciales incorrectas";
                //}
            //}
            //catch(IndexOutOfRangeException e)
            //{
            //    return $@"Usuario no encontrado. ({e.Message})";
            //}
            //catch(Exception e)
            //{
            //    return e.GetType() + ": " + e.Message;
            //}
        }

        // POST api/<ValuesController>
        [HttpPost("registrar")]
        public object Register([FromBody] Registrado user)
        {
            string query = $"registrar '{user.email}', '{user.nick}', '{user.pass}', '{user.fechaNac}';";
            DbController conexion = new DbController("localhost", "botanapoly", "sqladmin", "password");

            try
            {
                return conexion.DbInsertQuery(query);
            }
            catch (Exception e)
            {
                return e.GetType() + ": " + e.Message;
            }
        }
    }
}
