using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanapolyAPI.Models;


namespace BotanapolyAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]

    public class BotanapolyController : ControllerBase
    {

        private BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly" ,"adrian", "abc123.");

        [HttpPost]
        [ActionName("Registrarse")]
        public int Registrarse([FromBody] UsuarioRegistro usuarioRegistro)
        {
            string consulta = $"registrar '{usuarioRegistro.Email}', '{usuarioRegistro.Nick}', '{usuarioRegistro.Pass}', '{usuarioRegistro.FechaNacimiento}'";
            return baseDatos.generarMod(consulta);
        }

        [HttpPost]
        [ActionName("Autenticar")]
        public string Autenticar([FromBody] UsuarioAutenticar usuarioAutenticar)
        {
            string consulta = $"autenticar '{usuarioAutenticar.Email}', '{usuarioAutenticar.Pass}'";
            return baseDatos.generarConsulta(consulta)[0][1].ToString();
        }

        [HttpGet]
        [ActionName("ObtenerTableros")]
        public IEnumerable<Tablero> ObtenerTableros()
        {
            string consulta = "getTableros";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new Tablero(listado[index])).ToArray();
        }

        [HttpPost]
        [ActionName("CrearPartida")]
        public int CrearPartida([FromBody] PartidaCrear partidaCrear)
        {
            string passParameter = partidaCrear.Pass == null ? "null" : $"'{partidaCrear.Pass}'";
            string consulta = $"CrearPartida '{partidaCrear.Nombre}', '{partidaCrear.Administrador}', '{partidaCrear.MaxJugadores}', '{partidaCrear.MaxTiempo}', {passParameter}, '{partidaCrear.Tablero}';";
            return baseDatos.generarMod(consulta);
        }

        [HttpGet]
        [ActionName("ObtenerListadoPartidas")]
        public IEnumerable<Partida> ObtenerListadoPartidas()
        {
            string consulta = "getPartidas";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new Partida(listado[index])).ToArray();
        }

        [HttpPost]
        [ActionName("UnirsePartida")]
        public string UnirsePartida([FromBody]PartidaUnirse partidaUnirse)
        {
            string passParameter = partidaUnirse.Pass == null ? "null" : $"'{partidaUnirse.Pass}'";
            string consulta = $"anadirJugador '{partidaUnirse.IdUsuario}', '{partidaUnirse.IdPartida}', {passParameter}";
            return baseDatos.generarConsulta(consulta)[0][1].ToString();
        }

        [HttpPost]
        [ActionName("IniciarPartida")]
        public int IniciarPartida(int idPartida)
        {
            string consulta = $"ComenzarPartida {idPartida};";
            return baseDatos.generarMod(consulta);
        }

        [HttpPost]
        [ActionName("CrearBot")]
        public int crearBot(int partida, string pass)
        {
            string consulta = $"anadirJugador NULL, {partida}, '{pass}'";
            return baseDatos.generarMod(consulta);
        }

        [HttpGet]
        [ActionName("GetTablero")]
        public IEnumerable<Casilla> GetTablero(int idTablero)
        {
            string consulta = $"getCasillas {idTablero}";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new Casilla(listado[index])).ToArray();
        }

        [HttpGet]
        [ActionName("GetJugadores")]
        public IEnumerable<Jugador> GetJugadores(int idPartida)
        {
            string consulta = $"getJugadoresInfo {idPartida}";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new Jugador(listado[index])).ToArray();
        }

        [HttpGet]
        [ActionName("GetPropiedadesJugador")]
        public IEnumerable<PropiedadesJugador> GetPropiedadesJugador(int idJugador)
        {
            string consulta = $"getPropiedades  {idJugador}";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new PropiedadesJugador(listado[index])).ToArray();
        }

        [HttpGet]
        [ActionName("GetTurno")]
        public string GetTurno(int idPartida, int idJugador)
        {
            string consulta = $"getTurno {idPartida}, {idJugador}";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return baseDatos.generarConsulta(consulta)[0][1].ToString();
        }

        [HttpPost]
        [ActionName("Edificar")]
        public string Edificar([FromBody] JugadorCasilla jugadorCasilla)
        {
            string consulta = $"edificar {jugadorCasilla.IdJugador}, {jugadorCasilla.IdCasilla};";
            return baseDatos.generarConsulta(consulta)[0][1].ToString();
        }

        [HttpPost]
        [ActionName("Moverse")]
        public string Moverse([FromBody] JugadorTirada jugadorTirada)
        {
            string consulta = $"mover {jugadorTirada.IdJugador}, {jugadorTirada.Tirada};";
            return baseDatos.generarConsulta(consulta)[0][1].ToString();
        }

        [HttpPost]
        [ActionName("Vender")]
        public string Vender([FromBody] JugadorCasilla jugadorCasilla)
        {
            string consulta = $"vender {jugadorCasilla.IdJugador}, {jugadorCasilla.IdCasilla};";
            return baseDatos.generarConsulta(consulta)[0][1].ToString();
        }

        [HttpPost]
        [ActionName("Comprar")]
        public string Comprar(int idJugador)
        {
            string consulta = $"comprar {idJugador}";
            return baseDatos.generarConsulta(consulta)[0][1].ToString();
        }
        [HttpPost]
        [ActionName("VenderEdificacion")]
        public string VenderEdificacion([FromBody] JugadorCasilla jugadorCasilla)
        {
            string consulta = $"venderEdificacion {jugadorCasilla.IdJugador}, {jugadorCasilla.IdCasilla}";
            return baseDatos.generarConsulta(consulta)[0][1].ToString();
        }

        [HttpPost]
        [ActionName("Retirarse")]
        public int Retirarse(int idJugador)
        {
            string consulta = $"retirarJugador {idJugador};";
            return baseDatos.generarMod(consulta);
        }

        [HttpPost]
        [ActionName("Abandonar")]
        public int Abandonar(int idJugador)
        {
            string consulta = $"abandonarPartida {idJugador};";
            return baseDatos.generarMod(consulta);
        }

    }

}
