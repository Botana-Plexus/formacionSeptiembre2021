using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT = System.Data;
using botanapoli_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanapoli_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost("AutenticarJugador")]
        [ActionName("AutenticarJugador")]
        public int AutenticarJugador([FromBody] Modelos.Usuario user)
        {
            string query = $"autenticar '{user.Email}', '{user.Pass}';";
            DbController conexion = new DbController();
            return conexion.DbInsertQuery(query);
        }

        // POST api/<ValuesController>
        [HttpPost("RegistrarJugador")]
        [ActionName("RegistrarJugador")]
        public object RegistrarJugador([FromBody] Modelos.Usuario user)
        {
            string query = $"registrar '{user.Email}', '{user.Nick}', '{user.Pass}', '{user.FechaNacimiento}';";
            DbController conexion = new DbController();
            return conexion.DbInsertQuery(query);
        }

        // POST api/<ValuesController>
        [HttpPost("AñadirJugador")]
        [ActionName("AñadirJugador")]
        public int AñadirJugador(int idUsuario, int idPartida, string pass)
        {
            string query = string.IsNullOrEmpty(pass) ?
                $"añadirJugador {idUsuario}, {idPartida}, null"
                : $"añadirJugador {idUsuario}, {idPartida}, {pass}";
            DbController conexion = new DbController();
            return conexion.DbInsertQuery(query);
        }

        // POST api/<ValuesController>
        [HttpPost("AñadirBot")]
        [ActionName("AñadirBot")]
        public object AddBot([FromBody] int idPartida, string pass)
        {
            string query = string.IsNullOrEmpty(pass) ?
                $"añadirJugador null, {idPartida}, null"
                : $"añadirJugador null, {idPartida}, {pass}";
            DbController conexion = new DbController();

            return conexion.DbInsertQuery(query);
        }
    }
}
