using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using botanapoli_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanapoli_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/<ValuesController1>
        [HttpGet]
        [ActionName("GetPropJugadores")]
        public List<Modelos.PropiedadesJugador> GetPropJugadores(int idJugador)
        {
            string query = $"getPropiedades {idJugador}";
            DbController conexion = new DbController();
            List <Modelos.PropiedadesJugador> listaPropiedadesJugador = new List<Modelos.PropiedadesJugador>();

            try
            {
                DataTable dt = conexion.DbRetrieveQuery(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Modelos.PropiedadesJugador propiedad = new Modelos.PropiedadesJugador();
                    propiedad.Id = (int)dt.Rows[i]["id"];
                    propiedad.Tipo = (int)dt.Rows[i]["tipo"];
                    propiedad.Tablero = (int)dt.Rows[i]["tablero"];
                    propiedad.Nombre = (string)dt.Rows[i]["nombre"];
                    propiedad.Orden = (int)dt.Rows[i]["orden"];
                    propiedad.PrecioCompra = (int)dt.Rows[i]["precioCompra"];
                    propiedad.PrecioVenta = (int)dt.Rows[i]["precioVenta"];
                    propiedad.PrecioVentaEdificacion= (int)dt.Rows[i]["precioVentaEdificacion"];
                    propiedad.Coste1 = (int)dt.Rows[i]["coste1"];
                    propiedad.Coste2 = (int)dt.Rows[i]["coste2"];
                    propiedad.Coste3 = (int)dt.Rows[i]["coste3"];
                    propiedad.Coste4 = (int)dt.Rows[i]["coste4"];
                    propiedad.Coste5 = (int)dt.Rows[i]["coste5"];
                    propiedad.Coste6 = (int)dt.Rows[i]["coste6"];
                    propiedad.Conjunto = (int)dt.Rows[i]["conjunto"];
                    propiedad.Destino = (int)dt.Rows[i]["destino"];
                    propiedad.NivelEdificacion = (int)dt.Rows[i]["nivelEdificacion"];
                    listaPropiedadesJugador.Add(propiedad);
                }
                return listaPropiedadesJugador;
            }
            catch(Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
