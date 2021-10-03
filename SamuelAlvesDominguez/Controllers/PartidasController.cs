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
        [HttpGet("{idPartida}")]
        public List<Jugadores> GetJugadoresInfo(int idPartida)
        {
            return BDConnection.GetJugadoresInfo(idPartida);
        }

        [HttpGet("{tiempo}")]
        public void GetTiempo(int partida)
        {
            BDConnection.GetTiempo(partida);
        }

        [HttpGet("{partida}")]
        public void GetMasRico(int partida)
        {
            BDConnection.GetMasRico(partida);
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

        [HttpPut("{idJugador}")]
        public void RetirarJugador(int idJugador)
        {
            BDConnection.RetirarJugador(idJugador);
        }

        [HttpPut("{partida}/{jugador}")]
        public void FinalizarTurno(int partida, int jugador)
        {
            BDConnection.FinalizarTurno(partida, jugador);
        }

        // DELETE api/<PartidasController>/5
        [HttpDelete("{idJugador}")]
        public void AbandonarPartida(int idJugador)
        {
            BDConnection.AbandonarPartida(idJugador);
        }

        [HttpDelete]
        public void FinalizarPartida(int id)
        {
            BDConnection.FinalizarPartida(id);
        }
        
    }
}
