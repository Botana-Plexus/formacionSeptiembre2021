using Botanapoly.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Botanapoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasillasController : ControllerBase
    {
        QuerysSQL execSQL;

        [HttpGet]
        [Route("/casillas")]
        public IEnumerable<Casillas> getCasillas(int idTablero, int idCasilla)
        {
            string sql = $"getCasillas {idTablero},{idCasilla}";
            execSQL = new QuerysSQL();

            List<object[]> resultadoLista = execSQL.executeStoredProcedureReader(sql);

            return Enumerable.Range(0, resultadoLista.Count).Select(i => new Casillas(resultadoLista[i])).ToArray();
        }
    }
}
