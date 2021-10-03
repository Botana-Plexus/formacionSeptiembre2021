using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanapolyV1.Modelos.Dao;
using BotanapolyV1.Modelos.Dto;
using System.Data;

namespace BotanapolyV1.Controlador
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropiedadesController : ControllerBase
    {
        readonly BaseDatos NuevaConexionBD = new();

        // ------------------- POST: COMPRAR PROPIEDAD --------------------
        #region POST: Comprar Propiedad

        [HttpPost("comprar")]
        public string Comprar(int idJugador)
        {
            string query = $"comprar '{idJugador}' ";

            DataTable setResultados = NuevaConexionBD.HazLaConsulta(query);

            return setResultados.Rows[0]["Column2"].ToString();
        }
        #endregion FIN: Comprar Propiedad


        // ------------------- GET: VENDER PROPIEDAD --------------------
        #region POST: Vender Propiedad

        [HttpPost("vender")]
        public string Vender(int idJugador, int idCasilla)
        {
            string query = $"vender '{idJugador}','{idCasilla}'";

            DataTable setResultados = NuevaConexionBD.HazLaConsulta(query);
            return setResultados.Rows[0]["Column2"].ToString();
        }
        #endregion FIN: Vender Propiedad


        // ------------------- POST: ACTUALIZAR NIVEL CONSTRUCCION --------------------
        #region POST: Actualizar Nivel Construccion

        [HttpPost("edificacion/nivel/actualizar")]
        public string ActualizarNivelEdificacion(int idJugador, int tipo)
        {
            if (tipo != 2 || tipo != 3)
            {
                return "Tipo de casilla no valido";
            }

            string NivelEdificacionActualizada = $"actualizarNivelConstruccion '{idJugador}','{tipo}'";

            return NuevaConexionBD.InsertaLosDatos(NivelEdificacionActualizada);
        }

        #endregion FIN: Actualizar Nivel Construccion


        // ------------------- GET: MUESTRA PROPIEDADES JUGADOR --------------------
        #region GET:  Mostrar Propiedades Jugador

        [HttpGet("lista")]
        public List<CasillaModeloDto> Lista(int idJugador)
        {
            string Propiedades = $"getPropiedades'{idJugador}'";

            DataTable setResultados = NuevaConexionBD.HazLaConsulta(Propiedades);

            var ListaPropiedades = new List<CasillaModeloDto>();

            for (int i = 0; i < setResultados.Rows.Count; i++)
            {
                CasillaModeloDto casilla = new();
                casilla.id = Convert.ToInt32(setResultados.Rows[i]["id"]);
                casilla.tipo = Convert.ToInt32(setResultados.Rows[i]["tipo"]);
                casilla.nombre = Convert.ToString(setResultados.Rows[i]["nombre"]);
                casilla.precioCompra = setResultados.Rows[i]["precioCompra"] != System.DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["precioCompra"]) : null;
                casilla.precioVenta = setResultados.Rows[i]["precioVenta"] != System.DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["precioVenta"]) : null;
                casilla.costeEdificacion = setResultados.Rows[i]["costeEdificacion"] != System.DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["costeEdificacion"]) : null;
                casilla.precioVentaEdificacion = setResultados.Rows[i]["precioVentaEdificacion"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["precioVentaEdificacion"]) : null;
                casilla.Coste1 = setResultados.Rows[i]["Coste1"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste1"]) : null;
                casilla.Coste2 = setResultados.Rows[i]["Coste2"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste2"]) : null;
                casilla.Coste3 = setResultados.Rows[i]["Coste3"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste3"]) : null;
                casilla.Coste4 = setResultados.Rows[i]["Coste4"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste4"]) : null;
                casilla.Coste5 = setResultados.Rows[i]["Coste5"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["Coste5"]) : null;
                casilla.conjunto = setResultados.Rows[i]["conjunto"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["conjunto"]) : null;
                casilla.destino = setResultados.Rows[i]["destino"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["destino"]) : null;
                casilla.nivelEdificacion = setResultados.Rows[i]["nivelEdificacion"] != DBNull.Value ? Convert.ToInt32(setResultados.Rows[i]["nivelEdificacion"]) : null;


                ListaPropiedades.Add(casilla);
            }
            return ListaPropiedades;
        }
        #endregion FIN: Mostrar Propiedades Jugador


        // ------------------- POST: EDIFICAR --------------------
        #region POST: Edificar

        [HttpPost("edificar")]
        public string Edificar(int idJugador, int idCasilla)
        {
            string query = $"edificar '{idJugador}','{idCasilla}'";

            DataTable setResultados = NuevaConexionBD.HazLaConsulta(query);
            return setResultados.Rows[0]["Column2"].ToString();
        }

        #endregion POST: Edificar


        // ------------------- POST: VENDER EDIFICACION --------------------
        #region POST: Vender una Edificacion
        [HttpPost("edificacion/vender")]
        public string VenderEdificacion(int idJugador, int idCasilla)
        {
            string EdificacionaVender = $"venderEdificacion '{idJugador}','{idCasilla}'";
            
            DataTable setResultados = NuevaConexionBD.HazLaConsulta(EdificacionaVender);

            return setResultados.Rows[0]["Column2"].ToString();
        }

        #endregion POST: Vender una Edificacion


        // ------------------- POST: ACTUALIZAR DEUDA --------------------
        #region POST: Actualizar Deuda
        [HttpPost("deuda/actualizar")]
        public string ActualizarDeuda(int idJugador, int idCarta)
        {
            string DeudaActualizada = $"actualizarDeuda '{idJugador}','{idCarta}'";

            return NuevaConexionBD.InsertaLosDatos(DeudaActualizada);

        }

        #endregion POST: Actualizar Deuda

       

    }
}
