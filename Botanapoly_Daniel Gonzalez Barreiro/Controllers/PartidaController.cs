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
            if(partida.maxJugadores>6)
            {
                return "Numero de xogadores non valido";
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
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("mostrarInfoJugador")]
        public string mostarInfoJugador(int idPartida)
        {
            string query = $"'{idPartida}'";
            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }
        //[HttpGet("listarPlantillas")]
        //public List<Tableros>listarTableros()
        //{
        //    string query = @"SELECT * FROM tableros";
        //    System.Data.DataTable dt = database.selectQuery(query);

        //    var lista = new List<Tableros>();

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        Tableros tablero = new Tableros();
        //        tablero.id = Convert.ToInt32(dt.Rows[i]["id"]);
        //        tablero.descripcion = Convert.ToString(dt.Rows[i]["descripcion"]);
        //        tablero.importe = Convert.ToInt32(dt.Rows[i]["importe"]);
        //        tablero.numCasillas = Convert.ToInt32(dt.Rows[i]["numCasillas"]);

        //        lista.Add(tablero);
        //    }
        //    return lista;
        //}

        [HttpGet("listarPlantillas")]
        public List<Tableros>listarTableros()
        {
            string query = @"SELECT * FROM tableros";
        }

    }
}


