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
    public class PropiedadesController : ControllerBase
    {
        QuerysSQL execSQL;

        [HttpGet]
        [Route("/propiedades")]
        public IEnumerable<Propiedades> getPropiedades(int id)
        {
            string sql = $"getPropiedades {id}";
            execSQL = new QuerysSQL();

            List<object[]> resultadoLista = execSQL.executeStoredProcedureReader(sql);

            return Enumerable.Range(0, resultadoLista.Count).Select(i => new Propiedades(resultadoLista[i])).ToArray();
        }

    }
}
