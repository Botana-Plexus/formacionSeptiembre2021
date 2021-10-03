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
    public class CasillaController : Controller
    {
        readonly BaseDatos NuevaConexionBD = new();
        // ------------------- GET: MOSTRAR INFO CASILLA(null, idCasilla), CASILLA EN EL TABLERO (idTablero, null) --------------------
        #region GET: Mostrar Casillas
        [HttpGet("lista")]
        public List<CasillaModeloDto> Lista([FromQuery] int idTablero, int? idCasilla)
        {

            string query = "getCasillas";

            if (idCasilla != null)
            {
                query += "'" + idTablero + "'" + "," + "'" + idCasilla + "'";
            }
            else
            {
                query += "'" + idTablero + "'";
            }
            DataTable setResultados = NuevaConexionBD.HazLaConsulta(query);

            var ListaCasillas = new List<CasillaModeloDto>();

            for (int i = 0; i < setResultados.Rows.Count; i++)
            {
                CasillaModeloDto Casilla = new();
                Casilla.id = Convert.ToInt32(setResultados.Rows[i]["id"]);
                Casilla.tipo = Convert.ToInt32(setResultados.Rows[i]["tipo"]);
                Casilla.nombre = Convert.ToString(setResultados.Rows[i]["nombre"]);
                Casilla.precioCompra = setResultados.Rows[i]["precioCompra"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["precioCompra"]) : null;
                Casilla.precioVenta = setResultados.Rows[i]["precioVenta"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["precioVenta"]) : null;
                Casilla.costeEdificacion = setResultados.Rows[i]["costeEdificacion"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["costeEdificacion"]) : null;
                Casilla.precioVentaEdificacion = setResultados.Rows[i]["precioVentaEdificacion"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["precioVentaEdificacion"]) : null;
                Casilla.Coste1 = setResultados.Rows[i]["Coste1"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste1"]) : null;
                Casilla.Coste2 = setResultados.Rows[i]["Coste2"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste2"]) : null;
                Casilla.Coste3 = setResultados.Rows[i]["Coste3"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste3"]) : null;
                Casilla.Coste4 = setResultados.Rows[i]["Coste4"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste4"]) : null;
                Casilla.Coste5 = setResultados.Rows[i]["Coste5"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste5"]) : null;
                Casilla.Coste6 = setResultados.Rows[i]["Coste6"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste6"]) : null;
                Casilla.jugador = setResultados.Rows[i]["jugador"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["jugador"]) : null;
                Casilla.conjunto = setResultados.Rows[i]["conjunto"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["conjunto"]) : null;
                Casilla.destino = setResultados.Rows[i]["destino"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["destino"]) : null;


                ListaCasillas.Add(Casilla);
            }
            return ListaCasillas ;
        }


        #endregion FIN: Mostrar Casillas
    }
}
