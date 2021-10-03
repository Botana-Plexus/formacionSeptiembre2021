using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using botanapoli_api.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanapoli_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // Listar plantillas de tableros
        [HttpGet]
        [ActionName("ListarTableros")]
        public List<Modelos.Tablero> ListarTableros()
        {
            string query = "getTableros";
            DbController conexion = new DbController();
            List<Modelos.Tablero> listaTableros = new List<Modelos.Tablero>();

                DataTable db = conexion.DbRetrieveQuery(query);

                for (int i = 0; i < db.Rows.Count; i++)
                {
                    var tab = new Modelos.Tablero();
                    tab.Id = Convert.ToInt32(db.Rows[i]["id"]);
                    tab.Descripcion = Convert.ToString(db.Rows[i]["descripcion"]);
                    tab.Importe = Convert.ToInt32(db.Rows[i]["importe"]);
                    tab.NumCasillas = Convert.ToInt32(db.Rows[i]["numCasillas"]);
                    listaTableros.Add(tab);
                }

                return listaTableros;
        }

        // Obtener datos de partida
        [HttpGet]
        [ActionName("ListarPartida")]
        public Modelos.Partida ListarPartida(int gameId)
        {
            string query = $"getPartidas {gameId}";
            DbController conexion = new DbController();
            var infoPartida = new Modelos.Partida();

            DataTable dt = conexion.DbRetrieveQuery(query);
            infoPartida.Id = (int)dt.Rows[0]["id"];
            infoPartida.Estado = (int)dt.Rows[0]["Estado"];
            infoPartida.Nombre = (string)dt.Rows[0]["nombre"];
            infoPartida.NumJugadores = (int)dt.Rows[0]["numJugadores"];
            infoPartida.Tablero = (int)dt.Rows[0]["tablero"];
            infoPartida.Turno = (int)dt.Rows[0]["Turno"];
            infoPartida.MaxJugadores = System.DBNull.Value != dt.Rows[0]["maxJugadores"] ? (int)dt.Rows[0]["maxJugadores"] : null;
            infoPartida.MaxTiempo = System.DBNull.Value != dt.Rows[0]["maxTiempo"] ? (int)dt.Rows[0]["maxTiempo"] : null;
            infoPartida.TiempoTranscurrido = System.DBNull.Value != dt.Rows[0]["tiempoTranscurrido"] ? (int)dt.Rows[0]["tiempoTranscurrido"] : null;
            return infoPartida;
        }

        // Obtener lista de partidas
        [HttpGet]
        [ActionName("ListarPartidas")]
        public List<Modelos.Partida> ListarPartidas()
        {
            string query = $"getPartidas";
            DbController conexion = new DbController();
            var listaPartidas = new List<Models.Modelos.Partida>();

            DataTable dt = conexion.DbRetrieveQuery(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Models.Modelos.Partida partida = new Models.Modelos.Partida();
                partida.Id = (int)dt.Rows[i]["id"];
                partida.Estado = (int)dt.Rows[i]["Estado"];
                partida.Nombre = (string)dt.Rows[i]["nombre"];
                partida.Tablero = (int)dt.Rows[i]["tablero"];
                partida.Turno = (int)dt.Rows[i]["turno"];
                partida.NumJugadores = (int)dt.Rows[i]["numJugadores"];
                partida.MaxJugadores = System.DBNull.Value != dt.Rows[i]["maxJugadores"] ? (int)dt.Rows[i]["maxJugadores"] : null;
                partida.MaxTiempo = System.DBNull.Value != dt.Rows[i]["maxTiempo"] ? (int)dt.Rows[i]["maxTiempo"] : null;
                partida.TiempoTranscurrido = System.DBNull.Value != dt.Rows[i]["tiempoTranscurrido"] ? (int)dt.Rows[i]["tiempoTranscurrido"] : null;
                listaPartidas.Add(partida);
            }
            return listaPartidas;
        }

        // Crear partida 
        [HttpPost]
        [ActionName("CrearPartida")]
        public int CrearPartida([FromBody] Modelos.Partida game)
        {
            DbController conexion = new DbController();

                game.MaxJugadores = game.MaxJugadores == 0 ? 6 : game.MaxJugadores;
                string query = $"crearPartida '{game.Nombre}', '{game.Administrador}', '{game.MaxJugadores}', '{game.MaxTiempo}', '{game.Pass}', '{game.Tablero}';";
                
                if (string.IsNullOrEmpty(game.Pass))
                {
                    query = $"crearPartida '{game.Nombre}', '{game.Administrador}', '{game.MaxJugadores}', '{game.MaxTiempo}', null, '{game.Tablero}';";
                }
                return conexion.DbInsertQuery(query);
        }

        // Iniciar Partida
        [HttpPost]
        [ActionName("IniciarPartida")]
        public int IniciarPartida(int idPartida)
        {
            string query = $"ComenzarPartida {idPartida}";
            DbController conexion = new DbController();

            return conexion.DbInsertQuery(query);
        }

        // Post Finalizar Partida
        [HttpPost]
        [ActionName("FinalizarPartida")]
        public int FinalizarPartida(int idPartida)
        {
            DbController conexion = new DbController();
            return conexion.DbInsertQuery($"finalizarPartida {idPartida}");
        }

        // Obtener casillas de un tablero
        [HttpGet]
        [ActionName("ObtenerTablero")]
        public List<Modelos.Casilla> ObtenerTablero(int tableroId)
        {
            string query = $"getCasillas {tableroId}, null";
            DbController conexion = new DbController();
            var listaCasillas = new List<Modelos.Casilla>();
            DataTable db = conexion.DbRetrieveQuery(query);
                
            for(int i = 0; i < db.Rows.Count; i++)
            {
                var casilla = new Modelos.Casilla();
                casilla.Id = (int)db.Rows[i]["id"];
                casilla.Tipo = (int)db.Rows[i]["tipo"];
                casilla.Nombre = (string)db.Rows[i]["nombre"];
                casilla.Orden = (int)db.Rows[i]["orden"];
                casilla.Propietario = System.DBNull.Value != db.Rows[i]["jugador"] ? (int)db.Rows[i]["jugador"] : null;
                casilla.PrecioCompra = System.DBNull.Value != db.Rows[i]["precioCompra"] ? (int)db.Rows[i]["precioCompra"] : null;
                casilla.PrecioVenta = System.DBNull.Value != db.Rows[i]["precioVenta"] ? (int)db.Rows[i]["precioVenta"] : null;
                casilla.CosteEdificacion = System.DBNull.Value != db.Rows[i]["costeEdificacion"] ? (int)db.Rows[i]["costeEdificacion"] : null;
                casilla.PrecioVentaEdificacion = System.DBNull.Value != db.Rows[i]["precioVentaEdificacion"] ? (int)db.Rows[i]["precioVentaEdificacion"] : null;
                casilla.Coste1 = System.DBNull.Value != db.Rows[i]["Coste1"] ? (int)db.Rows[i]["Coste1"] : null;
                casilla.Coste2 = System.DBNull.Value != db.Rows[i]["Coste2"] ? (int)db.Rows[i]["Coste2"] : null;
                casilla.Coste3 = System.DBNull.Value != db.Rows[i]["Coste3"] ? (int)db.Rows[i]["Coste3"] : null;
                casilla.Coste4 = System.DBNull.Value != db.Rows[i]["Coste4"] ? (int)db.Rows[i]["Coste4"] : null;
                casilla.Coste5 = System.DBNull.Value != db.Rows[i]["Coste5"] ? (int)db.Rows[i]["Coste5"] : null;
                casilla.Coste6 = System.DBNull.Value != db.Rows[i]["Coste6"] ? (int)db.Rows[i]["Coste6"] : null;
                casilla.Conjunto = System.DBNull.Value != db.Rows[i]["conjunto"] ? (int)db.Rows[i]["conjunto"] : null;
                casilla.Destino = System.DBNull.Value != db.Rows[i]["destino"] ? (int)db.Rows[i]["destino"] : null;

                listaCasillas.Add(casilla);
            }
            return listaCasillas;
        }

        // Obtener casillas de todos los tableros
        [HttpGet]
        [ActionName("ObtenerCasilla")]
        public Modelos.Casilla ObtenerTableros(int idCasilla)
        {
            string query = $"getCasillas null, {idCasilla}";
            DbController conexion = new DbController();
            var casilla = new Modelos.Casilla();
            DataTable db = conexion.DbRetrieveQuery(query);

            casilla.Id = (int)db.Rows[0]["id"];
            casilla.Tipo = (int)db.Rows[0]["tipo"];
            casilla.Nombre = (string)db.Rows[0]["nombre"];
            casilla.Propietario = System.DBNull.Value != db.Rows[0]["jugador"] ? (int)db.Rows[0]["jugador"] : null;
            casilla.PrecioCompra = System.DBNull.Value != db.Rows[0]["precioCompra"] ? (int)db.Rows[0]["precioCompra"] : null;
            casilla.PrecioVenta = System.DBNull.Value != db.Rows[0]["precioVenta"] ? (int)db.Rows[0]["precioVenta"] : null;
            casilla.CosteEdificacion = System.DBNull.Value != db.Rows[0]["costeEdificacion"] ? (int)db.Rows[0]["costeEdificacion"] : null;
            casilla.PrecioVentaEdificacion = System.DBNull.Value != db.Rows[0]["precioVentaEdificacion"] ? (int)db.Rows[0]["precioVentaEdificacion"] : null;
            casilla.Coste1 = System.DBNull.Value != db.Rows[0]["Coste1"] ? (int)db.Rows[0]["Coste1"] : null;
            casilla.Coste2 = System.DBNull.Value != db.Rows[0]["Coste2"] ? (int)db.Rows[0]["Coste2"] : null;
            casilla.Coste3 = System.DBNull.Value != db.Rows[0]["Coste3"] ? (int)db.Rows[0]["Coste3"] : null;
            casilla.Coste4 = System.DBNull.Value != db.Rows[0]["Coste4"] ? (int)db.Rows[0]["Coste4"] : null;
            casilla.Coste5 = System.DBNull.Value != db.Rows[0]["Coste5"] ? (int)db.Rows[0]["Coste5"] : null;
            casilla.Coste6 = System.DBNull.Value != db.Rows[0]["Coste6"] ? (int)db.Rows[0]["Coste6"] : null;
            casilla.Conjunto = System.DBNull.Value != db.Rows[0]["conjunto"] ? (int)db.Rows[0]["conjunto"] : null;
            casilla.Destino = System.DBNull.Value != db.Rows[0]["destino"] ? (int)db.Rows[0]["destino"] : null;

            return casilla;
        }

        // Obtener info jugadores de una partida
        [HttpGet]
        [ActionName("GetInfoJugadores")]
        public List<Modelos.Jugador> GetInfoJugadores(int idPartida)
        {
            string query = $"getJugadoresInfo {idPartida}";
            DbController conexion = new DbController();
            var listaInfoJugadores = new List<Modelos.Jugador>();
            DataTable dt = conexion.DbRetrieveQuery(query);
                
            for(int i = 0; i < dt.Rows.Count ; i++)
            {
                var player = new Modelos.Jugador();
                player.Id = (int)dt.Rows[i]["id"];
                player.IdUsuario = System.DBNull.Value != dt.Rows[i]["idUsuario"] ? (int)dt.Rows[i]["idUsuario"] : null;
                player.IdPartida = (int)dt.Rows[i]["idPartida"];
                player.Saldo = (int)dt.Rows[i]["saldo"];
                player.Orden = (int)dt.Rows[i]["orden"];
                player.Posicion = System.DBNull.Value != dt.Rows[i]["posicion"] ? (int)dt.Rows[i]["posicion"] : null;
                player.Dobles = (int)dt.Rows[i]["dobles"];
                player.TurnosDeCastigo = (int)dt.Rows[i]["turnosDeCastigo"];
                listaInfoJugadores.Add(player);
            }
            return listaInfoJugadores;
        }
    }
}
