using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QC = Microsoft.Data.SqlClient;
using DT = System.Data;
using botanapoli_api;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanapoli_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //// POST: api/register
        //[HttpPost]
        //public void RegisterUser([FromBody] string nombre, string telefono, string dni, string email, string pass, string nick, string fecha_nacimiento, string estado_civil)
        //{

        //}

        //// POST: api/authenticate
        //[HttpPost]
        //public void AuthenticateUser([FromBody] string email, string pass)
        //{
        //}

        //// POST: api/games/join/game_id
        //[HttpPost]
        //public void JoinGame([FromBody] string username, int game_id)
        //{
        //}

        // GET: api/<ValuesController>/users
        //[HttpGet]
        //public IEnumerable<string> GetUsers(int id)
        //{
            

            //try
            //{
            //    var command = new QC.SqlCommand();

            //    command.Connection = connection;
            //    command.CommandType = DT.CommandType.Text;
            //    command.CommandText = $@"
            //        SELECT nombre, email, pass, nick FROM usuarios WHERE id = {id}
            //    ";

            //    QC.SqlDataReader reader = command.ExecuteReader();

            //    string[] users = new string[4];
            //    while (reader.Read())
            //    {
            //        users[0] = reader.GetString(0);
            //        users[1] = reader.GetString(1);
            //        users[2] = reader.GetString(2);
            //        users[3] = reader.GetString(3);
            //    }
            //    reader.Close();
            //    return users;
            //}
            //catch (QC.SqlException e)
            //{
            //    throw new Exception(e.GetType() + " " + e.Message);
            //}
        //}


        // EJEMPLOS
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
