using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT = System.Data;
using botanapoly_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanapoly_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost]
        [ActionName("Autenticar")]
        public int Authenticar([FromBody] Models.Modelos.Usuario user)
        {
            string query = $"autenticar '{user.Email}', '{user.Pass}';";
            DbController conexion = new DbController();
            return conexion.DbInsertQuery(query);
        }

        // POST api/<ValuesController>
        [HttpPost("registrar")]
        public object Register([FromBody] Models.Modelos.Usuario user)
        {
            string query = $"registrar '{user.Email}', '{user.Nick}', '{user.Pass}', '{user.FechaNacimiento}';";
            DbController conexion = new DbController();

            try
            {
                return conexion.DbInsertQuery(query);
            }
            catch (Exception e)
            {
                return e.GetType() + ": " + e.Message;
            }
        }

        // POST api/<ValuesController>
        [HttpPost("añadirJugador")]
        public object AddPlayer([FromBody] Models.Modelos.Usuario user)
        {
            string query = $"añadirJugador {user.Id}, {user.Id}";
            DbController conexion = new DbController();

            try
            {
                return conexion.DbInsertQuery(query);
            }
            catch (Exception e)
            {
                return e.GetType() + ": " + e.Message;
            }
        }
        // POST api/<ValuesController>
        [HttpPost("añadirBots")]
        public object AddBot([FromBody] Models.Modelos.Jugador bot)
        {
            string query = $"añadirJugador NULL, {bot.IdPartida}";
            DbController conexion = new DbController();

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
