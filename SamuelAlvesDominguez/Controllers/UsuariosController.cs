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
    public class UsuariosController : ControllerBase
    {
        // GET: api/<UsuairosController>
        

        // GET api/<UsuairosController>/5
        [HttpGet("{email}, {pass}")]
        public string Autenticar(string email, string pass)
        {

            return BDConnection.Autenticar(email, pass);

        }

        // POST api/<UsuairosController>
       [HttpPost]
        public void PostUsuario(Usuarios usuario)
        {
            BDConnection.RegistrarUsuario(usuario);
        }


        // PUT api/<UsuairosController>/5


        // DELETE api/<UsuairosController>/5

    }
}
