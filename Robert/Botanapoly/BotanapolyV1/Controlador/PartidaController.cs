using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanapolyV1.Modelos.Dao;
using BotanapolyV1.Modelos.Dto;
using System.Text.Json;
using System.Data;

namespace BotanapolyV1.Controlador
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        readonly BaseDatos NuevaConexionBD = new();

        // -------------------- POST: CREAR PARTIDA ---------------------
        #region POST: Crear Partida

        [HttpPost("crear")]
        public string Crear([FromBody] PartidaModeloDto Partida)
        {
            string NuevaPartida;
            if (Partida.maxJugadores == null)
            {
                Partida.maxJugadores = 6;
            }

            if (string.IsNullOrEmpty(Partida.pass))
            {

                NuevaPartida = $"crearPartida'{Partida.nombre}','{Partida.administrador}','{Partida.maxJugadores}','{Partida.maxTiempo}',null,'{Partida.tablero}'";
            }
            else
            {
                NuevaPartida = $"crearPartida'{Partida.nombre}','{Partida.administrador}','{Partida.maxJugadores}','{Partida.maxTiempo}','{Partida.pass}','{Partida.tablero}'";


            }
            return NuevaConexionBD.InsertaLosDatos(NuevaPartida);
        }


        #endregion FIN: Crear Partida


        // ------------------- POST: UNIRSE A LA PARTIDA --------------------
        #region POST: Unirse a la Partida
        [HttpPost("unir")]
        public string Unir([FromQuery] int idUsuario, int idPartida, string passPartida)
        {
            string IniciarPartida;

            if (string.IsNullOrEmpty(passPartida))
            {
                IniciarPartida = $"anadirJugador'{idUsuario}','{idPartida}',null";
            }
            else
            {
                IniciarPartida = $"anadirJugador'{idUsuario}','{idPartida}','{passPartida}'";

            }
            DataTable setResultados = NuevaConexionBD.HazLaConsulta(IniciarPartida);

            return setResultados.Rows[0]["Column2"].ToString();
        }

        #endregion FIN: Iniciar Partida


        // ------------------ POST: INICIAR PARTIDA -------------------
        #region POST: Iniciar Partida
            [HttpPost("iniciar")]
            public string Iniciar([FromQuery] int idPartida)
            {
            string AJugar = $"ComenzarPartida'{idPartida}'";

            return NuevaConexionBD.InsertaLosDatos(AJugar);
        }
        #endregion FIN: Iniciar Partida


        // --------------- GET: MOSTRAR TODOS LAS PARTIDAS ---------------
        #region GET: Mostrar Todas Las Partidas
        [HttpGet("lista")]
            public List<PartidaModeloDto> Lista(int? idPartida)
            {
            string Partida = "getPartidas";

            if (idPartida != null)
            {
                Partida += $"'{idPartida}'";
            }
            DataTable dt = NuevaConexionBD.HazLaConsulta(Partida);

            var ListaPartidas = new List<PartidaModeloDto>();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PartidaModeloDto partida = new PartidaModeloDto();
                partida.id = Convert.ToInt32(dt.Rows[i]["id"]);
                partida.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                partida.maxJugadores = Convert.ToInt32(dt.Rows[i]["maxJugadores"]);
                partida.maxTiempo = dt.Rows[i]["maxTiempo"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["maxTiempo"]) : null;
                partida.tiempoTranscurrido = dt.Rows[i]["tiempoTranscurrido"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["tiempoTranscurrido"]) : null;
                partida.numJugadores = Convert.ToInt32(dt.Rows[i]["numJugadores"]);
                partida.turno = Convert.ToInt32(dt.Rows[i]["turno"]);
                partida.estado = Convert.ToInt32(dt.Rows[i]["estado"]);
                partida.tablero = Convert.ToInt32(dt.Rows[i]["tablero"]);
                partida.tienePass = Convert.ToBoolean(dt.Rows[i]["tienePass"]);

                ListaPartidas.Add(partida);
            }
            return ListaPartidas;

        }
        #endregion FIN: Mostrar Todas Las Partidas


        // ------------------- POST: PAGAR DEUDA --------------------
        #region POST: Pagar Deuda

        [HttpPost("deuda-pagar")]
        public string PagarDeuda(int idJugador)
        {
            string Deuda = $"pagarDeuda '{idJugador}'";


            DataTable setResultados = NuevaConexionBD.HazLaConsulta(Deuda);

            return setResultados.Rows[0]["Column2"].ToString();

        }

        #endregion FIN: Pagar Deuda


        // ------------------- POST: TURNO PARTIDA --------------------
        #region POST: Turno en partida
        [HttpPost("turno")]
        public string Turno(int idJugador, int idPartida)
        {
            string query = $"getTurno '{idPartida}','{idJugador}'";

            DataTable setResultados = NuevaConexionBD.HazLaConsulta(query);
            return setResultados.Rows[0]["Column2"].ToString();
        }
        #endregion POST: Abandonar una Partida


        // ------------------- POST: FINALIZAR TURNO --------------------
        #region POST: Finalizar Turno

        [HttpPost("turno-finalizar")]
        public string finalizarTurno(int idJugador)
        {
            string Turno = $"pagarDeuda '{idJugador}'";

            return NuevaConexionBD.InsertaLosDatos(Turno);

        }

        #endregion FIN: Finalizar Turno


        // ------------------- POST: FINALIZAR PARTIDA --------------------
        #region POST: Finalizar Partida
        [HttpPost("finalizar")]
        public string FinalizarPartida(int idPartida)
        {
            string PartidaFinalizada = $"finalizarPartida '{idPartida}'";

            return NuevaConexionBD.InsertaLosDatos(PartidaFinalizada);
        }
        #endregion FIN: Finalizar Partida


        // ------------------- POST: ABANDONAR PARTIDA --------------------
        #region POST: Abandonar una Partida

        [HttpPost("abandonar")]
        public string AbandonarPartida(int idJugador)
        {
            string JugadorAbandona = $"abandonarPartida '{idJugador}'";

            return NuevaConexionBD.InsertaLosDatos(JugadorAbandona);
        }

        #endregion POST: Abandonar una Partida

        // ------------------- POST: GANADOR PARTIDA --------------------
        #region POST: Ganador Partida

        [HttpPost("ganador")]
        public JugadorModeloDto GanadorPartida(int idPartida)
        {
            string query;

            query = $"getJugadoresInfo {idPartida};";
            System.Data.DataTable jugadores = NuevaConexionBD.HazLaConsulta(query);
            for (int i = 0; i < jugadores.Rows.Count; i++)
            {
                int idJugador = Convert.ToInt32(jugadores.Rows[i]["id"]);
                query = $"getPropiedades {idJugador}";
                System.Data.DataTable propiedades = NuevaConexionBD.HazLaConsulta(query);
                for (int j = 0; j < propiedades.Rows.Count; j++)
                {
                    int propiedad = Convert.ToInt32(propiedades.Rows[j]["id"]);
                    int nivelEdificacion = Convert.ToInt32(propiedades.Rows[j]["nivelEdificacion"]);
                    for (int k = 0; k < nivelEdificacion; k++)
                    {
                        query = $"venderEdificacion {idJugador},{propiedad}";
                        NuevaConexionBD.HazLaConsulta(query);
                    }
                    PropiedadesController PropController = new();

                    PropController.Vender(idJugador, propiedad);
                }
            }

            string ganador = $"getMasRico {idPartida}";
            DataTable dt = NuevaConexionBD.HazLaConsulta(ganador);

            JugadorModeloDto jugador = new();
            jugador.id = Convert.ToInt32(dt.Rows[0]["id"]);
            if (dt.Rows[0]["idUsuario"] != System.DBNull.Value)
                jugador.idUsuario = Convert.ToInt32(dt.Rows[0]["idUsuario"]);
            jugador.idPartida = Convert.ToInt32(dt.Rows[0]["idPartida"]);
            jugador.saldo = Convert.ToInt32(dt.Rows[0]["saldo"]);
            jugador.orden = Convert.ToInt32(dt.Rows[0]["orden"]);
            if (dt.Rows[0]["posicion"] != System.DBNull.Value)
                jugador.posicion = Convert.ToInt32(dt.Rows[0]["posicion"]);
            jugador.dobles = Convert.ToInt32(dt.Rows[0]["dobles"]);
            jugador.turnosDeCastigo = Convert.ToInt32(dt.Rows[0]["turnosDeCastigo"]);

            return jugador;
        }
        #endregion POST: Ganador Partida


        // ------------------- POST: TIEMPO PARTIDA --------------------
        #region POST: Tiempo Partida

        [HttpPost("tiempo-comprobador")]
        public string ComprobarTiempo(int idPartida)
        {
            string query = $"getTiempo {idPartida};";
            System.Data.DataTable dt = NuevaConexionBD.HazLaConsulta(query);
            int tiempoRestante = Convert.ToInt32(dt.Rows[0]["Column1"]);


            if (tiempoRestante == 0)
            {

                JugadorModeloDto ganador = GanadorPartida(idPartida);
                return $"Ha ganado el jugador con id = {ganador.id}";
            }
            else
                return "Todavía no se ha acabado el tiempo";
        }

        #endregion FIN: Tiempo Partida

       

    }
}
