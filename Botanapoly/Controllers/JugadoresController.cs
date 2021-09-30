using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Botanapoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        // GET: api/<JugadoresController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JugadoresController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JugadoresController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JugadoresController>/5
        [HttpPut]
        public void AddJugador(int usuario, int partida)
        {
            BDConnection.AddJugador(usuario, partida);
        }

        [HttpPost("{jugador}/{tipo}")]
        public void ActualizarNivelConstruccion(int jugador, int tipo)
        {
            BDConnection.ActualizarNivelConstruccion(jugador, tipo);
        }

        [HttpPost("{jugador}")]
        public void Comprar(int jugador)
        {
            BDConnection.Comprar(jugador);
        }

        [HttpPost("{jugador}/{casilla}")]
        public void Vender(int jugador, int casilla)
        {
            BDConnection.Vender(jugador, casilla);
        }



        // DELETE api/<JugadoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
