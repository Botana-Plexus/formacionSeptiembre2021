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
        /*
        ~ - registrado
        0 - no registrado
        */
        public int Registrarse([FromBody] UsuarioRegistro usuarioRegistro)
        {
            string consulta = $"registrar '{usuarioRegistro.Email}', '{usuarioRegistro.Nick}', '{usuarioRegistro.Pass}', '{usuarioRegistro.FechaNacimiento}'";
            return baseDatos.generarMod(consulta);
        }

        [HttpPost]
        [ActionName("Autenticar")]
        /*
        1 - autenticado
        0 - no autenticado
        */
        public int Autenticar([FromBody] UsuarioAutenticar usuarioAutenticar)
        {
            string consulta = $"autenticar '{usuarioAutenticar.Email}', '{usuarioAutenticar.Pass}'";
            return (int)baseDatos.generarConsulta(consulta)[0][0];
        }

        [HttpGet]
        [ActionName("ObtenerTableros")]
        /*
        Lista de Tableros
        */
        public IEnumerable<Tablero> ObtenerTableros()
        {
            string consulta = "getTableros";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new Tablero(listado[index])).ToArray();
        }

        [HttpPost]
        [ActionName("CrearPartida")]
        /*
        ~ - partida creada
        0 - partida no creada
        */
        public int CrearPartida([FromBody] PartidaCrear partidaCrear)
        {
            string passParameter = partidaCrear.Pass == null ? "null" : $"'{partidaCrear.Pass}'";
            string consulta = $"CrearPartida '{partidaCrear.Nombre}', '{partidaCrear.Administrador}', '{partidaCrear.MaxJugadores}', '{partidaCrear.MaxTiempo}', {passParameter}, '{partidaCrear.Tablero}';";
            return baseDatos.generarMod(consulta);
        }

        [HttpGet]
        [ActionName("ObtenerListadoPartidas")]
        /*
        Lista de Partidas
        */
        public IEnumerable<Partida> ObtenerListadoPartidas()
        {
            string consulta = "getPartidas";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new Partida(listado[index])).ToArray();
        }

        [HttpPost]
        [ActionName("UnirsePartida")]
        /*
        0 - Unido a la Partida
        1 - Partida completa
        */
        public int UnirsePartida([FromBody]PartidaUnirse partidaUnirse)
        {
            string passParameter = partidaUnirse.Pass == null ? "null" : $"'{partidaUnirse.Pass}'";
            string consulta = $"anadirJugador '{partidaUnirse.IdUsuario}', '{partidaUnirse.IdPartida}', {passParameter}";
            return (int)baseDatos.generarConsulta(consulta)[0][1];
        }

        [HttpPost]
        [ActionName("IniciarPartida")]
        /*
        0 - Partida no iniciada
        ~ - Partida iniciada
        */
        public int IniciarPartida(int idPartida)
        {
            string consulta = $"ComenzarPartida {idPartida};";
            return baseDatos.generarMod(consulta);
        }

        [HttpPost]
        [ActionName("CrearBot")]
        /*
        0 - Bot no creado
        ~ - Bot creado
        */
        public int crearBot(int partida, string pass)
        {
            string consulta = $"anadirJugador NULL, {partida}, '{pass}'";
            return baseDatos.generarMod(consulta);
        }

        [HttpGet]
        [ActionName("GetTablero")]
        /*
        Lista de Casillas
        */
        public IEnumerable<Casilla> GetTablero(int idTablero)
        {
            string consulta = $"getCasillas {idTablero}";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new Casilla(listado[index])).ToArray();
        }

        [HttpGet]
        [ActionName("GetJugadores")]
        /*
        Lista de Jugadores
        */
        public IEnumerable<Jugador> GetJugadores(int idPartida)
        {
            string consulta = $"getJugadoresInfo {idPartida}";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new Jugador(listado[index])).ToArray();
        }

        [HttpGet]
        [ActionName("GetPropiedadesJugador")]
        /*
        Lista de Propiedades
        */
        public IEnumerable<PropiedadesJugador> GetPropiedadesJugador(int idJugador)
        {
            string consulta = $"getPropiedades  {idJugador}";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return Enumerable.Range(0, listado.Length).Select(index => new PropiedadesJugador(listado[index])).ToArray();
        }

        [HttpGet]
        [ActionName("GetTurno")]
        /*
        0 - No es tu turno
        1 - Es tu turno
        2 - Sigues en la carcel
        */
        public int GetTurno(int idJugador)
        {
            string consulta = $"getTurno {idJugador}";
            object[][] listado = baseDatos.generarConsulta(consulta);
            return (int)baseDatos.generarConsulta(consulta)[0][0];
        }

        [HttpPost]
        [ActionName("Edificar")]
        /*
        0 - Edificado
        1 - No es propietario de todo el conjunto
        2 - No edificable
        3 - Saldo insuficiente
        4 - Nivel máximo alcanzado
        */
        public int Edificar([FromBody] JugadorCasilla jugadorCasilla)
        {
            string consulta = $"edificar {jugadorCasilla.IdJugador}, {jugadorCasilla.IdCasilla};";
            return (int)baseDatos.generarConsulta(consulta)[0][0];
        }

        [HttpPost]
        [ActionName("Moverse")]
        /*
        1 - tipoCasilla 1
        2 - tipoCasilla 2, 3, 4
        3 - tipoCasilla 5, TipoCarta = 1
        4 - tipoCasilla 5, TipoCarta = 2
        5 - tipoCasilla 5, TipoCarta = 3
        6 - tipoCasilla 6
        7 - tipoCasilla 7
        8 - tipoCasilla 8
        */
        public int Moverse([FromBody] JugadorTirada jugadorTirada)
        {
            return actionMoverse(jugadorTirada);
        }

        private int actionMoverse(JugadorTirada jugadorTirada)
        {
            string consulta = $"mover {jugadorTirada.IdJugador}, {jugadorTirada.Tirada};";
            int idCasilla = (int)baseDatos.generarConsulta(consulta)[0][0];
            int tipoCasilla = (int)baseDatos.generarConsulta($"getCasillas NULL, {idCasilla}")[0][1];
            if (tipoCasilla == 1)
            {
                return 1;
            }
            else if (tipoCasilla == 2 || tipoCasilla == 3 || tipoCasilla == 4 || tipoCasilla == 8)
            {
                baseDatos.generarConsulta($"actualizarDeudaCompleta {jugadorTirada.IdJugador}, NULL");
                return tipoCasilla == 8 ? 8 : 2;
            }
            else if (tipoCasilla == 5)
            {
                int idCarta = (int)baseDatos.generarConsulta($"getCartaAleatoria {jugadorTirada.IdJugador}")[0][0];
                object[][] info = baseDatos.generarConsulta($"getInfoCarta NULL, {idCasilla}");
                if ((int)info[0][3] == 1)
                    return 3;
                else if ((int)info[0][3] == 2)
                {
                    baseDatos.generarConsulta($"actualizarDeudaCompleta {jugadorTirada.IdJugador}, {idCarta}");
                    return 4;
                }
                else if ((int)info[0][3] == 3)
                {
                    return actionMoverse(new JugadorTirada(jugadorTirada.IdJugador, (int)info[0][2])); ;
                }
                else
                {
                    return 0;
                }
            }
            else if (tipoCasilla == 7)
            {
                baseDatos.generarConsulta($"castigar {jugadorTirada.IdJugador}");
                return 7;
            }
            else
            {
                return 6;
            }
        }

        [HttpPost]
        [ActionName("Vender")]
        /*
        0 - Vendido
        1 - Casilla no es propiedad
        */
        public int Vender([FromBody] JugadorCasilla jugadorCasilla)
        {
            string consulta = $"vender {jugadorCasilla.IdJugador}, {jugadorCasilla.IdCasilla};";
            return (int)baseDatos.generarConsulta(consulta)[0][0];
        }

        [HttpPost]
        [ActionName("Comprar")]
        /*
        0 - Comprada
        1 - No comprada
        */
        public int Comprar(int idJugador)
        {
            string consulta = $"comprar {idJugador}";
            return (int)baseDatos.generarConsulta(consulta)[0][0];
        }
        [HttpPost]
        [ActionName("VenderEdificacion")]
        /*
        0 - Edificacion Vendida
        1 - No realizado
        */
        public string VenderEdificacion([FromBody] JugadorCasilla jugadorCasilla)
        {
            string consulta = $"venderEdificacion {jugadorCasilla.IdJugador}, {jugadorCasilla.IdCasilla}";
            return baseDatos.generarConsulta(consulta)[0][1].ToString();
        }


        [HttpPost]
        [ActionName("FinalizarTurno")]
        /*
        0 - Error al finalizar turno
        ~ - Turno Finalizado
        */
        public int FinalizarTurno(int idPartida, int idJugador)
        {
            string consulta = $"finalizarTurno {idPartida}, {idJugador}";
            return baseDatos.generarMod(consulta);
        }

        [HttpPost]
        [ActionName("Retirarse")]
        /*
        0 - No retirado
        ~ - Retirado
        */
        public int Retirarse(int idJugador)
        {
            string consulta = $"retirarJugador {idJugador}";
            return baseDatos.generarMod(consulta);
        }

        [HttpPost]
        [ActionName("Abandonar")]
        /*
        0 - No abandonado
        ~ - Abandonado
        */
        public int Abandonar(int idJugador)
        {
            string consulta = $"abandonarPartida {idJugador};";
            return baseDatos.generarMod(consulta);
        }

    }

}
