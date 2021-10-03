using Microsoft.AspNetCore.Http;
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
    public class TableroController : ControllerBase
    {
        readonly BaseDatos NuevaConexionBD = new();

        // ------------------- GET: MOSTRAR TODOS LOS TABLEROS --------------------
        #region GET: Mostrar Todos Los Tableros


        #endregion FIN: Mostrar Tableros


        // ------------------- POST: MOSTRAR UN TABLERO --------------------
        #region POST: Mostrar Tablero

        [HttpGet("lista")]
        public List<TableroModeloDto> Lista()
        {
            string query = $"getTableros";

            DataTable setResultados = NuevaConexionBD.HazLaConsulta(query);

            var ListaTableros = new List<TableroModeloDto>();

            for (int i = 0; i < setResultados.Rows.Count; i++)
            {
                TableroModeloDto Tablero = new();
                Tablero.id = Convert.ToInt32(setResultados.Rows[i]["id"]);
                Tablero.descripcion = Convert.ToString(setResultados.Rows[i]["descripcion"]);
                Tablero.importe = Convert.ToInt32(setResultados.Rows[i]["importe"]);
                Tablero.numCasillas = Convert.ToInt32(setResultados.Rows[i]["numCasillas"]);

                ListaTableros.Add(Tablero);
            }
            return ListaTableros;
        }
        #endregion FIN: Mostrar Tablero

    }
}
