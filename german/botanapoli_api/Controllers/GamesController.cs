using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanapoli_api.Controllers
{
    [Route("api/[controller]/{idPartida}")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public int ListTemplates()
        {
            return 1;
        }

        [HttpGet("PartidasCreadas")]
        public int GetGames()
        {
            return 1;
        }
        [HttpPost("PartidasCreadas")]
        public int CreateGame([FromBody] CrearPartida game)
        {
            return 1;
        }
        [HttpPost("IniciarPartida")]
        public int InitiateGame([FromBody] IniciarPartida game)
        {
            return 1;
        }

        []
    }
}
