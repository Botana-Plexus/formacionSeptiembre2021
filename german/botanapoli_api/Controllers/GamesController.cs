using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using botanapoly_api.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanapoly_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        public List<Models.Modelos.Tablero> ListTemplates()
        {
            string query = "getTableros";
            DbController conexion = new DbController();
            List<Models.Modelos.Tablero> listaTableros = new List<Models.Modelos.Tablero>();

            try
            {
                DataTable db = conexion.DbRetrieveQuery(query);

                for (int i = 0; i < db.Rows.Count; i++)
                {
                    Models.Modelos.Tablero tab = new Models.Modelos.Tablero();
                    tab.Id = Convert.ToInt32(db.Rows[i]["id"]);
                    tab.Descripcion = Convert.ToString(db.Rows[i]["descripcion"]);
                    tab.Importe = Convert.ToInt32(db.Rows[i]["importe"]);
                    tab.NumCasillas = Convert.ToInt32(db.Rows[i]["numCasillas"]);
                    listaTableros.Add(tab);
                }

                return listaTableros;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        [HttpGet("{idPartida}")]
        public object[] GetGames([FromBody] int gameId)
        {
            string query = $"getPartidas {gameId}";
            DbController conexion = new DbController();
            object[] infoPartida = new object[5];

            try
            {
                DataTable dt = conexion.DbRetrieveQuery(query);
                infoPartida[0] = dt.Rows[0]["id"];
                infoPartida[1] = dt.Rows[0]["nombre"];
                infoPartida[2] = dt.Rows[0]["maxJugadores"];
                infoPartida[3] = dt.Rows[0]["maxTiempo"];
                infoPartida[4] = dt.Rows[0]["tiempoTranscurrido"];
                return infoPartida;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        [HttpGet]
        public List<Models.Modelos.Partida> GetGames()
        {
            string query = $"getPartidas";
            DbController conexion = new DbController();
            List<Models.Modelos.Partida> listaPartidas = new List<Models.Modelos.Partida>();

            try
            {
                DataTable dt = conexion.DbRetrieveQuery(query);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Models.Modelos.Partida partida = new Models.Modelos.Partida();
                    partida.Id = (int)dt.Rows[0]["id"];
                    partida.Nombre = (string)dt.Rows[0]["nombre"];
                    partida.MaxJugadores = (int)dt.Rows[0]["maxJugadores"];
                    partida.MaxTiempo = (int)dt.Rows[0]["maxTiempo"];
                    partida.TiempoTranscurrido = (int)dt.Rows[0]["tiempoTranscurrido"];
                    listaPartidas.Add(partida);
                }
                return listaPartidas;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        [HttpPost]
        public int CreateGame([FromBody] Models.Modelos.Partida game)
        {
            DbController conexion = new DbController();

            try
            {
                game.MaxJugadores = game.MaxJugadores == 0 ? 6 : game.MaxJugadores;
                string query = $"crearPartida '{game.Nombre}', '{game.Administrador}', '{game.MaxJugadores}', '{game.MaxTiempo}', '{game.Pass}', '{game.Tablero}';";
                
                if (string.IsNullOrEmpty(game.Pass))
                {
                    query = $"crearPartida '{game.Nombre}', '{game.Administrador}', '{game.MaxJugadores}', '{game.MaxTiempo}', null, '{game.Tablero}';";
                }
                return conexion.DbInsertQuery(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }
        [HttpPost]
        public int InitiateGame([FromBody] Models.Modelos.Partida game)
        {
            string query = $"ComenzarPartida {game.Id}";
            DbController conexion = new DbController();

            try
            {
                return conexion.DbInsertQuery(query);
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post Finalizar Partida
        [HttpPost]
        [ActionName("FinalizarPartida")]
        public int FinalizarPartida(int idPartida)
        {
            DbController conexion = new DbController();

            try
            {
                int res = conexion.DbInsertQuery($"finalizarPartida {idPartida}");
                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        [HttpGet]
        [ActionName("getTablero")]
        public List<Models.Modelos.Casilla> GetTablero(int tableroId)
        {
            string query = $"getCasillas {tableroId}";
            DbController conexion = new DbController();
            List<Models.Modelos.Casilla> listaCasillas = new List<Models.Modelos.Casilla>();

            try
            {
                DataTable db = conexion.DbRetrieveQuery(query);
                
                for(int i = 0; i < db.Rows.Count; i++)
                {
                    Models.Modelos.Casilla casilla = new Models.Modelos.Casilla();
                    casilla.Id = (int)db.Rows[i]["id"];
                    casilla.Tipo = (int)db.Rows[i]["tipo"];
                    casilla.Nombre = (string)db.Rows[i]["nombre"];
                    casilla.Orden = (int)db.Rows[i]["orden"];
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
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        [HttpGet]
        [ActionName("GetInfoJugadores")]
        public List<Jugador> GetInfoJugadores(int idPartida)
        {
            string query = $"getJugadoresInfo {idPartida}";
            DbController conexion = new DbController();
            List<Jugador> listaInfoJugadores = new List<Jugador>();

            try
            {
                DataTable dt = conexion.DbRetrieveQuery(query);
                
                for(int i = 0; i < dt.Rows.Count ; i++)
                {
                    Jugador player = new Jugador();
                    player.Id = (int)dt.Rows[i]["id"];
                    player.IdUsuario = (int)dt.Rows[i]["idusuario"];
                    player.IdPartida = (int)dt.Rows[i]["idPartida"];
                    player.Saldo = (int)dt.Rows[i]["saldo"];
                    player.Orden = (int)dt.Rows[i]["orden"];
                    player.Posicion = (int)dt.Rows[i]["posicion"];
                    player.Dobles = (int)dt.Rows[i]["dobles"];
                    player.TurnosDeCastigo = (int)dt.Rows[i]["turnosDeCastigo"];
                    listaInfoJugadores.Add(player);
                }
                return listaInfoJugadores;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }




    }
}
