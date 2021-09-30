using Botanapoly.Models;
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
    public class PartidasController : ControllerBase
    {
        // GET: api/<PartidasController>
        [HttpGet]
        public List<Partidas> GetPartidas(int id)
        {
            return BDConnection.GetPartidas(id);
        }

        // GET api/<PartidasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PartidasController>
        [HttpPost]
        public void CrearPartida([FromBody] Partidas partida)
        {
            BDConnection.CrearPartida(partida);
        }

        // PUT api/<PartidasController>/5
        [HttpPut("{id}")]
        public void ComenzarPartida(int id)
        {
            BDConnection.ComenzarPartida(id);
        }

        // DELETE api/<PartidasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
    }
}
