using Botanapoly.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace Botanapoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        // GET: api/<APIController>
        


        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIController>
        [HttpPost]
        public void PostUsuario(Usuarios usuario)
        {
           BDConnection.RegistrarUsuario(usuario);
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        /*  PROCEDIMIENTOS PENDIENTES
            - Retirarse
            - Abandonar
            - FinalizarPartida
            - EdificarUp
            - EdificarDown
            - VenderPropiedad
            - ComprarPropiedad
            - Moverse
            - ActualizarCastigo
            - ObtenerCarta
            - GetDatosTablero
            - FinalizarTurno
         */
        //[HttpGet]
        //public string Autenticar(string email, string pass)
        //{
        //    return BDConnection.Autenticar(email, pass);
            
        //}
        /*  METODOS NECESARIOS DE LA APP
            - registrarse
            - autenticarse
            - mostrar listado de plantillas
            - mostrar tablero
            - crear partida
            - mostrar listado de partida
            - unirse a una partida
            - crear bots de la partida
            - iniciar una partida
            - mostrar info de los jugadores
            - mostrar detalles del jugador
            - mostPropJugador ?
            - mostrar turno
            - edificar
            - moverse
            - vender
            - comprar
            - vender edificacion
            - pagar
            - obtener carta
            - retirarse
            - abandonar
            - finalizar partida
            - finalizar turno
            - tirada
         */




    }
}
