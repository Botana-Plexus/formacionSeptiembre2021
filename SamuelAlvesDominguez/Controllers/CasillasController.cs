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

        // GET api/<CasillasController>/5
        [HttpGet("{id}")]
        public List<Casillas> GetCasillas(int id)
        {
            return BDConnection.GetCasillas(id);
        }
    }
}
