using BotanapolyV1.Modelos.Dao;
using BotanapolyV1.Modelos.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;

namespace BotanapolyV1.Controlador
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        readonly BaseDatos NuevaConexionBD = new();
        // ------------------- POST: AGREGAR JUGADOR --------------------
        #region POST: Agregar Jugador a Partida

        [HttpPost("agregar")]
        public string AgregarJugador([FromQuery] int idUsuario, int idPartida, string passPartida)
        {
            dynamic NuevoJugadorPartida;

            if (string.IsNullOrEmpty(passPartida))
            {
                NuevoJugadorPartida = $"anadirJugador'{idUsuario}','{idPartida}',null";
            }
            else
            {
                NuevoJugadorPartida = $"anadirJugador'{idUsuario}','{idPartida}','{passPartida}'";
            }

            return NuevaConexionBD.InsertaLosDatos(NuevoJugadorPartida);
        }

        #endregion FIN: Agregar Jugador a Partida

        // ------------------- POST: AGREGAR BOTS --------------------
        #region POST: Agregar Bots a Partida

        [HttpPost("bot/agregar")]
        public string AgregarBots([FromQuery] int idPartida, string passPartida)
        {
            string BotAgregado;

            if (string.IsNullOrEmpty(passPartida))
            {
                BotAgregado = $"anadirJugador null,'{idPartida}',null";
            }
            else
            {
                BotAgregado = $"anadirJugador null,'{idPartida}','{passPartida}'";

            }

            DataTable setResultados = NuevaConexionBD.HazLaConsulta(BotAgregado);

            return setResultados.Rows[0]["Column2"].ToString();
        }
        #endregion FIN: Agregar Bots a Partida

        // ------------------- GET: JUGADORES INFO --------------------
        #region GET: Infromacion Jugador en una Partida

        [HttpGet("lista")]
        public List<JugadorModeloDto> InformacionJugadores(int idPartida)
        {

            string InformacionJugadores = $"getJugadoresInfo '{idPartida}'";

            System.Data.DataTable setResultados = NuevaConexionBD.HazLaConsulta(InformacionJugadores);

            var ListaJugadores = new List<JugadorModeloDto>();

            for (int i = 0; i < setResultados.Rows.Count; i++)
            {
                JugadorModeloDto Jugador = new();
                Jugador.id = Convert.ToInt32(setResultados.Rows[i]["id"]);
                Jugador.idUsuario =
                setResultados.Rows[i]["idUsuario"] == DBNull.Value ? null : Convert.ToInt32(setResultados.Rows[i]["idUsuario"]);
                Jugador.idPartida = Convert.ToInt32(setResultados.Rows[i]["idPartida"]);
                Jugador.saldo = Convert.ToInt32(setResultados.Rows[i]["saldo"]);
                Jugador.orden = Convert.ToInt32(setResultados.Rows[i]["orden"]);
                Jugador.dobles = Convert.ToInt32(setResultados.Rows[i]["dobles"]);
                Jugador.turnosDeCastigo = Convert.ToInt32(setResultados.Rows[i]["turnosDeCastigo"]);
                ListaJugadores.Add(Jugador);
            }

            return ListaJugadores;
        }
        #endregion GET: Infromacion Jugador en una Partida


        // ------------------- POST: RETIRARSE PARTIDA --------------------
        #region POST: Retirarse de una Partida

        [HttpPost("retirar")]
        public string retirarsePartida(int idJugador)
        {
            string JugadorRetirado = $"retirarJugador '{idJugador}'";

            return NuevaConexionBD.InsertaLosDatos(JugadorRetirado);
        }
        #endregion POST: Retirarse de una Partida


        // ------------------- POST: MANEJADOR DE DOBLES --------------------
        #region POST: Manejador de Dobles

        [HttpPost("dados-dobles")]
        public string setDobles(int idJugador, int reset)
        {
            string turnoDoble = $"setDobles '{idJugador}','{reset}'";

            return NuevaConexionBD.InsertaLosDatos(turnoDoble);
        }

        #endregion POST: Manejador de Dobles



        // ------------------- POST: MOVERSE EN UNA PARTIDA --------------------
        #region POST: Moverse en una Partida

        [HttpPost("mover")]
        public string MoversePartida(int idJugador, int tirada)
        {
            string query;
            query = $"mover '{idJugador}','{tirada}'";

            DataTable setResultados = NuevaConexionBD.HazLaConsulta(query);

            int casillaNova = Convert.ToInt32(setResultados.Rows[0][0]);

            query = $"getCasillas null,'{casillaNova}'";

            System.Data.DataTable dt2 = NuevaConexionBD.HazLaConsulta(query);

            int tipoCasilla = Convert.ToInt32(dt2.Rows[0]["tipo"]);

            switch (tipoCasilla)
            {
                case 2:
                case 3:
                case 4:
                case 8:
                    query = $"actualizarDeuda '{idJugador}','{casillaNova}'";

                    return NuevaConexionBD.InsertaLosDatos(query);
                case 1:
                case 6:

                    return "casilla neutra";
                case 7:
                    query = $"castigar '{idJugador}'";

                    return NuevaConexionBD.InsertaLosDatos(query);
                case 5:
                    query = $"getCartaAleatoria '{idJugador}'";
                    System.Data.DataTable dt3 = NuevaConexionBD.HazLaConsulta(query);
                    int idCarta = Convert.ToInt32(dt3.Rows[0][0]);

                    query = $"getInfoCarta '{idCarta}'";
                    System.Data.DataTable dt4 = NuevaConexionBD.HazLaConsulta(query);
                    int tipoCarta = Convert.ToInt32(dt4.Rows[0]["tipo"]);
                    int valorCarta = Convert.ToInt32(dt4.Rows[0]["valor"]);

                    if (tipoCarta == 2)
                    {
                        query = $"actualizarDeuda '{idCarta}','{idCarta}'";
                        return NuevaConexionBD.InsertaLosDatos(query);
                    }
                    else
                    {
                        return MoversePartida(idJugador, valorCarta);
                    }

            }
            return "";

        }


        #endregion FIN: Moverse en una Partida

        
    }
}
