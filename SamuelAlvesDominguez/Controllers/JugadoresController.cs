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

        // PUT api/<JugadoresController>/5
        [HttpPut]
        public void AddJugador(int usuario, int partida, string pass)
        {
            BDConnection.AddJugador(usuario, partida, pass);
        }

        [HttpPut("{jugador}/{tirada}")]
        public void Mover(int jugador, int tirada)
        {
            BDConnection.Mover(jugador, tirada);
        }

        [HttpPut("{jugador}/{casilla}")]
        public void Edificar(int jugador, int casilla)
        {
            BDConnection.Edificar(jugador, casilla);
        }

        [HttpPut("{jugador}/{carta}")]
        public static void ActualizarDeuda(int jugador, int carta)
        {
            BDConnection.ActualizarDeuda(jugador, carta);
        }

        [HttpPut("{jugador}")]
        public static void PagarDeuda(int jugador)
        {
            BDConnection.PagarDeuda(jugador);
        }

        [HttpPut("{castigado}")]
        public void Castigar(int castigado)
        {
            BDConnection.Castigar(castigado);
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

        [HttpPost("{jugador}/{casillaEdificacion}")]
        public void VenderEdificacion(int jugador, int casillaEdificacion)
        {
            BDConnection.VenderEdificacion(jugador, casillaEdificacion);
        }
        
        [HttpPost("{jugador}/{reset}")]
        public void SetDobles(int jugador, int reset)
        {
            BDConnection.SetDobles(jugador, reset);
        }
    }
}
