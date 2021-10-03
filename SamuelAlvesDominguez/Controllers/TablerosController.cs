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
    public class TablerosController : ControllerBase
    {
        // GET: api/<TablerosController>
        [HttpGet]
        public List<Tableros> GetTableros()
        {
            return BDConnection.GetTableros();
        }

        [HttpGet("{carta}")]
        public Cartas GetInfoCarta(int carta)
        {
            return BDConnection.GetInfoCarta(carta);
        }
    }
}
