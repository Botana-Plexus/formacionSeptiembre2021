using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Botanapoly.Controllers
{
    [Route("partida")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        Database database = new Database();
        // POST api/<LobbyController>
        [HttpPost("crear")]
        public string addPartida([FromBody] Partida partida)
        {
            if(partida.maxJugadores>6)
            {
                return "Numero de xogadores non valido";
            }

            string query = $"crearPartida'{partida.nombre}','{partida.administrador}','{partida.maxJugadores}','{partida.maxTiempo}','{partida.pass}','{partida.tablero}'";

            return database.insertQuery(query);
        }
        // POST api/<LobbyController>
        [HttpPost("unirse")]
        public string addJugador( int idUsuario, int idPartida)
        {
            string query = $"anadirJugador'{idUsuario}','{idPartida}'";

            return database.insertQuery(query);
        }

        [HttpPost("comenzar")]
        public string startPartida(int idPartida)
        {
            string query = $"ComenzarPartida'{idPartida}'";

            return database.insertQuery(query);
        }

    }
}
