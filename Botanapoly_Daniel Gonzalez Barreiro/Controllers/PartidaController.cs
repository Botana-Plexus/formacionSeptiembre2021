using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Botanapoly.Controllers
{
    [Route("partida")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        Database database = new Database();
        // POST api/<PartidaController>
        [HttpPost("crear")]
        public string addPartida([FromBody] Partida partida)
        {
            if(partida.maxJugadores == null )
            {
                partida.maxJugadores=6;
            }

            string query = $"crearPartida'{partida.nombre}','{partida.administrador}','{partida.maxJugadores}','{partida.maxTiempo}','{partida.pass}','{partida.tablero}'";

            return database.insertQuery(query);
        }

        [HttpPost("unirse")]
        public string addJugador( int idUsuario, int idPartida)
        {
            string query = $"anadirJugador'{idUsuario}','{idPartida}'";

            return database.insertQuery(query);
        }

        [HttpPost("comenzar")]
        public string startPartida(int idPartida)
        {
            string query = $"ComenzarPartida'{idPartida}'";

            return database.insertQuery(query);
        }
        [HttpPost("actualizarNivelEdificacion")]
        public string actualizarNivelEdificacion(int idJugador, int tipo)
        {
            if ( tipo != 2 || tipo != 3 )
            {
                return "Tipo de casilla no valido";
            }

            string query = $"actualizarNivelConstruccion '{idJugador}','{tipo}'";
            return database.insertQuery(query);
        }

        [HttpPost("comprar")]
        public string comprar(int idJugador)
        {
            string query = $"comprar '{idJugador}' ";
            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("vender")]
        public string vender(int idJugador, int casilla)
        {
            string query = $"vender '{idJugador}','{casilla}'";
            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("mostrarTablero")]
        public string mostrarTablero(int idTablero)
        {
            string query = $"'{idTablero}'";
            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column1"].ToString();
        }

        [HttpGet("infoJugadores")]
        public List<Jugador> getJugadores(int idPartida)
        {

            string consulta = $"getJugadoresInfo '{idPartida}'";

            System.Data.DataTable dt = database.selectQuery(consulta);

            var lista = new List<Jugador>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Jugador jugador = new Jugador();
                jugador.id = Convert.ToInt32(dt.Rows[i]["id"]);
                jugador.idUsuario =
                dt.Rows[i]["idUsuario"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["idUsuario"]) : null;
                jugador.idPartida = Convert.ToInt32(dt.Rows[i]["idPartida"]);
                jugador.saldo = Convert.ToInt32(dt.Rows[i]["saldo"]);
                jugador.orden = Convert.ToInt32(dt.Rows[i]["orden"]);
                jugador.dobles = Convert.ToInt32(dt.Rows[i]["dobles"]);
                jugador.turnosDeCastigo = Convert.ToInt32(dt.Rows[i]["turnosDeCastigo"]);
                lista.Add(jugador);
            }

            return lista;
        }

        [HttpGet("listarTableros")]
        public List<Tableros> listarTableros()
        {
            string query = $"getTableros";
            System.Data.DataTable dt = database.selectQuery(query);

            var lista = new List<Tableros>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tableros tablero = new Tableros();
                tablero.id = Convert.ToInt32(dt.Rows[i]["id"]);
                tablero.descripcion = Convert.ToString(dt.Rows[i]["descripcion"]);
                tablero.importe = Convert.ToInt32(dt.Rows[i]["importe"]);
                tablero.numCasillas = Convert.ToInt32(dt.Rows[i]["numCasillas"]);

                lista.Add(tablero);
            }
            return lista;
        }
        [HttpGet("listarCasillas")]
        public List<Casilla> getCasillas(int idTablero)
        {
            string query = $"getCasillas'{idTablero}'";
            System.Data.DataTable dt = database.selectQuery(query);

            var lista = new List<Casilla>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Casilla casilla = new Casilla();
                casilla.id = Convert.ToInt32(dt.Rows[i]["id"]);
                casilla.tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                casilla.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                casilla.precioCompra = dt.Rows[i]["precioCompra"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioCompra"]) : null;
                casilla.precioVenta = dt.Rows[i]["precioVenta"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVenta"]) :null;
                casilla.costeEdificacion = dt.Rows[i]["costeEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["costeEdificacion"]) : null;
                casilla.precioVentaEdificacion = dt.Rows[i]["precioVentaEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]) :null;
                casilla.Coste1 = dt.Rows[i]["Coste1"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste1"]):null;
                casilla.Coste2 = dt.Rows[i]["Coste2"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste2"]) : null;
                casilla.Coste3 = dt.Rows[i]["Coste3"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste3"]) : null;
                casilla.Coste4 = dt.Rows[i]["Coste4"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste4"]) : null;
                casilla.Coste5 = dt.Rows[i]["Coste5"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste5"]) : null;
                casilla.conjunto = dt.Rows[i]["conjunto"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["conjunto"]) : null;
                casilla.destino = dt.Rows[i]["destino"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["destino"]) : null;

                lista.Add(casilla);
            }
            return lista;
        }
        [HttpGet("listarPartidas")]
        public List<Partida> getPartidas(int? idPartida)
        {
            string query = "getPartidas";
            if (idPartida != null)
            {
                query += "'" + idPartida +  "'";
            }
            System.Data.DataTable dt = database.selectQuery(query);

            var lista = new List<Partida>();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Partida partida = new Partida();
                partida.id = Convert.ToInt32(dt.Rows[i]["id"]);
                partida.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                partida.maxJugadores = Convert.ToInt32(dt.Rows[i]["maxJugadores"]);
                partida.maxTiempo = dt.Rows[i]["maxTiempo"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["maxTiempo"]) : null;
                partida.tiempoTranscurrido = dt.Rows[i]["tiempoTranscurrido"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["tiempoTranscurrido"]) : null;
                partida.numJugadores = Convert.ToInt32(dt.Rows[i]["numJugadores"]);
                partida.turno = Convert.ToInt32(dt.Rows[i]["turno"]);
                partida.estado = Convert.ToInt32(dt.Rows[i]["estado"]);
                partida.tablero = Convert.ToInt32(dt.Rows[i]["tablero"]);

                lista.Add(partida);
            }
            return lista;
        }
    }
}


