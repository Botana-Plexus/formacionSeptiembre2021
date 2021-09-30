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
    public class usersController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost("autenticar")]
        public int Authenticate([FromBody] Autenticado usuario)
        {
            string query = $"autenticar '{usuario.email}', '{usuario.pass}';";
            DbController conexion = new DbController();
            return conexion.DbInsertQuery(query);
        }

        // POST api/<ValuesController>
        [HttpPost("registrar")]
        public object Register([FromBody] Registrado user)
        {
            string query = $"registrar '{user.email}', '{user.nick}', '{user.pass}', '{user.fechaNac}';";
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
        public object AddPlayer([FromBody] AñadirJugador addPLayer)
        {
            string query = $"añadirJugador {addPLayer.idJugador}, {addPLayer.idPartida}";
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
        public object AddBot([FromBody] AñadirJugador addBot)
        {
            string query = $"añadirJugador NULL, {addBot.idPartida}";
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
