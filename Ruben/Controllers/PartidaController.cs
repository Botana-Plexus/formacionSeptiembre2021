using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Botanapoly.Controllers
{
    [Route("partida")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        public Database BD = new Database();

        //getCasillas (partida)
        [HttpGet("listaCasillas")]
        public List<Casillas> getCasillas(int idTablero)
        {
            string consulta = $"getCasillas '{idTablero}'";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            var lista = new List<Casillas>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Casillas casilla = new Casillas();
                casilla.id = Convert.ToInt32(dt.Rows[i]["id"]);
                casilla.tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                casilla.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                casilla.precioCompra =
                    dt.Rows[i]["precioCompra"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioCompra"]) : null;
                casilla.precioVenta =
                    dt.Rows[i]["precioVenta"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVenta"]) : null;
                casilla.costeEdificacion = 
                    dt.Rows[i]["costeEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["costeEdificacion"]) : null;
                casilla.precioVentaEdificacion =
                    dt.Rows[i]["precioVentaEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]) : null;
                casilla.Coste1 =
                    dt.Rows[i]["Coste1"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste1"]) : null;
                casilla.Coste2 =
                    dt.Rows[i]["Coste2"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste2"]) : null;
                casilla.Coste3 =
                    dt.Rows[i]["Coste3"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste3"]) : null;
                casilla.Coste4 =
                    dt.Rows[i]["Coste4"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste4"]) : null;
                casilla.Coste5 =
                    dt.Rows[i]["Coste5"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste5"]) : null;
                casilla.conjunto =
                    dt.Rows[i]["conjunto"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["conjunto"]) : null;
                casilla.destino =
                    dt.Rows[i]["destino"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["destino"]) : null;
                lista.Add(casilla);
            }

            return lista;

        }
        //getPartidas (partida)
        [HttpGet("listaPartidas")]
        public List<Partidas> getPartidas(int idPartida)
        {
            string consulta = $"getPartidas '{idPartida}'";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            var lista = new List<Partidas>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Partidas parttida = new Partidas();
   

                lista.Add(parttida);
            }

            return lista;

        }



        //getTABLEROS
        [HttpGet("listaTableros")]
        public List<Tableros> getTableros()
        {
            string consulta = $"getTableros";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

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

        //getJugadores
        [HttpGet("listaJugadores")]
        public List<Jugadores> getJugadores(int idPartida)
        {

            string consulta = $"getJugadoresInfo '{idPartida}'";

            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            var lista = new List<Jugadores>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Jugadores jugador = new Jugadores();
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

        //Crear Partida
        [HttpPost("crear")]
        public string crearPartida([FromBody] Partidas partida)
        {
            if ( partida.maxJugadores > 6)
            {
                return "Numero de jugadores nor válido";
            }

            string consulta = $"crearPartida'{partida.nombre}','{partida.administrador}'," +
            $"'{partida.maxJugadores}','{partida.maxTiempo}','{partida.pass}','{partida.tablero}'";

            return BD.ejecutarConsultaInsert(consulta);
        }


        //Unirse Partida
        [HttpPost("unirse")]
        public string añadirJugador(int idJugador, int idPartida)
        {
            string consulta = $"anadirJugador  '{idJugador }','{idPartida}'";

            return BD.ejecutarConsultaInsert(consulta);
        }


        //Comenzar Partida
        [HttpPost("comenzar")]
        public string comenzarPartida(int idPartida)
        {
            string consulta = $"comenzarPartida '{idPartida}'";

            return BD.ejecutarConsultaInsert(consulta);
        }

        //Actualizar Nivel Edificación
        [HttpPost("actualizarNivelEdificacion")]
        public string actualizarNivelEdificacion(int idJugador,int tipo)
        {
            if(tipo != 2 || tipo != 3)
            {
                return "Tipo de casilla no valido";
            }

            string consulta = $"actualizarNivelConstruccion '{idJugador}','{tipo}'"; 
            return BD.ejecutarConsultaInsert(consulta);
        }

        //Comprar casilla
        [HttpPost("comprar")]
        public string comprar(int idJugador)
        {
            string consulta = $"comprar '{idJugador}' ";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            return dt.Rows[0]["Column2"].ToString();
        }

        //Vender casilla
        [HttpPost("vender")]
        public string vender(int idJugador,int idCasilla)
        {
            string consulta = $"vender '{idJugador}','{idCasilla}' ";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            return dt.Rows[0]["Column2"].ToString();
        }


     
        //retirarJugador (partida)
        //abandonarPartida (partida)
        //mover (jugador)
        //edificar (partida)
        //set dobles (partida)
        //venderEdif (partida)
        //edificar (partida)

    }
}
