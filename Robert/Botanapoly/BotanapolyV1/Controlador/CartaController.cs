using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanapolyV1.Modelos.Dto;
using BotanapolyV1.Modelos.Dao;
using System.Data;

namespace BotanapolyV1.Controlador
{ 
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartaController : Controller
    {
        readonly BaseDatos NuevaConexionBD = new();
        // ------------------- GET: INFORMACION CARTA--------------------
        #region GET: Informacion de Carta
        [HttpPost("informacion")]
        public CartaModeloDto InfoCarta(int idCarta)
        {
            string query = $"getInfoCarta '{idCarta}'";

            DataTable setResultados = NuevaConexionBD.HazLaConsulta(query);

            CartaModeloDto carta = new();

            carta.id = Convert.ToInt32(setResultados.Rows[0]["id"]);
            carta.texto = Convert.ToString(setResultados.Rows[0]["texto"]);
            carta.valor = Convert.ToInt32(setResultados.Rows[0]["valor"]);
            carta.tipo = Convert.ToInt32(setResultados.Rows[0]["tipo"]);

            return carta;
        }


        #endregion FIN: Mostrar Casillas

        // ------------------- POST: CARTA ALEATORIA --------------------
        #region POST: Carta Aleatoria

        [HttpPost("aleatoria")]
        public int CartaAleatoria(int idJugador)
        {
            string CartaAleatoria = $"getCartaAleatoria '{idJugador}'";

            System.Data.DataTable dt = NuevaConexionBD.HazLaConsulta(CartaAleatoria);

            return Convert.ToInt32(dt.Rows[0]["id"]);
        }

        #endregion FIN: Carta Aleatoria
    }
}
