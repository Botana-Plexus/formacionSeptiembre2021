using Botanapoly.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Botanapoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasillasController : ControllerBase
    {
        // GET: api/<CasillasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CasillasController>/5
        [HttpGet("{id}")]
        public List<Casillas> GetCasillas(int id)
        {
            return BDConnection.GetCasillas(id);
        }

        // POST api/<CasillasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CasillasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CasillasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
