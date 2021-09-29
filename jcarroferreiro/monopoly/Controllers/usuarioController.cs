using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProofOfConcept_SQL_CSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using QC = Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace monopoly.Controllers
{
     
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : ControllerBase
    {
        Conexion cnx = new Conexion();
        // GET: api/<usuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<usuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<usuarioController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        [HttpPost("Autenticar")]
        public string Post([FromBody] Autenticar usuario)
        {
            string mensaje = "";

            String sql = "SELECT email, pass FROM usuarios WHERE email = '" + usuario.email + "'";
            
            DataTable dt = cnx.consultas(sql);

            if (usuario.email.Equals(dt.Rows[0]["email"]) && usuario.pass.Equals(dt.Rows[0]["pass"]))
            {
                mensaje = "Puedes acceder";
            }
            else
            {
                mensaje = "Credenciales incorrectas";
            }
            return mensaje;
        }
        //Registro de usuarios
        [HttpPost("Registro")]
        public string Post([FromBody] Usuarios usuario)
        {
                //DATOS: nombre, telefono, fechaNacimiento, estadoCivil, email, nickname, contraseña

            string mensaje = "";
            string SQL = $"registrar '{usuario.email}', '{usuario.nick}', '{usuario.pass}', '{usuario.fechaNacimiento}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //Registro de tableros
        [HttpPost("RegistroTablero")]
        public string Post([FromBody] Tablero tablero)
        {
            //DATOS: descripcion, importe, numCasillas

            string mensaje = "";
            string SQL = $"INSERT into tableros (descripcion, importe, numCasillas) VALUES ('{tablero.descripcion}', '{tablero.importe}', '{tablero.numCasillas}')";
            cnx.consultas(SQL);
            return mensaje;
        }
        //Crear partida
        [HttpPost("CrearPartida")]
        public string Post([FromBody] CrearPartida crearPartida)
        {
            //DATOS: nombre,admin, maxJugadores,maxTiempo, pass, tablero 

            string mensaje = "";
            string SQL = $"crearPartida '{crearPartida.nombre}', '{crearPartida.admin}', '{crearPartida.maxJugadores}', '{crearPartida.maxTiempo}', '{crearPartida.pass}', '{crearPartida.tablero}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //Unirse a partida
        [HttpPost("UnirsePartida")]
        public string Post([FromBody] UnirsePartida unirsePartida)
        {
            //DATOS: idUsuario, idPartida 

            string mensaje = "";
            string SQL = $"anadirJugador '{unirsePartida.idUsuario}', '{unirsePartida.idPartida}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //Comenzar partida
        [HttpPost("ComenzarPartida")]
        public string Post([FromBody] ComenzarPartida comenzarPartida)
        {
            //DATOS: idUsuario, idPartida 

            string mensaje = "";
            string SQL = $"ComenzarPartida '{comenzarPartida.idPartida}'";
            cnx.consultas(SQL);
            return mensaje;
        }

        // PUT api/<usuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<usuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
