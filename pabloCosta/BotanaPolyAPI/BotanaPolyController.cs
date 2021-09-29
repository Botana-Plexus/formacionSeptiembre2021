using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BotanaPolyAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BotanaPolyController : ControllerBase
    {

        [ActionName("autenticar")]
        [HttpGet]
        public object[] autenticar(string email, string pass)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec autenticar '" + email + "','" + pass + "'");
            baseDatos.cerrarConexion();
            return listaObjetos[0];
        }

        [ActionName("comprar")]
        [HttpGet]
        public object[] comprar(int idJugador)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec comprar "+ idJugador + "");
            baseDatos.cerrarConexion();
            return listaObjetos[0];
        }

        [ActionName("vender")]
        [HttpGet]
        public object[] vender(int idJugador,int casilla)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec comprar "+ idJugador + ","+casilla+"");
            baseDatos.cerrarConexion();
            return listaObjetos[0];
        }

        [ActionName("mostrarListaTableros")]
        [HttpGet]
        public IEnumerable<Tablero> mostrarListaTableros(int idTablero)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getTableros "+ idTablero +"");
            baseDatos.cerrarConexion();
            return Enumerable.Range(0, listaObjetos.Count).Select(index => new Tablero(listaObjetos[index])).ToArray();
        }

        [ActionName("mostrarTablero")]
        [HttpGet]
        public IEnumerable<TableroCasillas> mostrarTablero(int idTablero)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getTableros " + idTablero+ "");
            baseDatos.cerrarConexion();
            return Enumerable.Range(0, listaObjetos.Count).Select(index => new TableroCasillas(listaObjetos[index])).ToArray();
        }

        [HttpPost]
        [ActionName("registro")]
        public int registro([FromBody] Usuario usuario)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            //int result = baseDatos.insertDatos("insert into usuarios(nombre,telefono,email,fechaNacimiento,nick) values ('" + usuario.nombre + "','" + usuario.telefono + "','" + usuario.email + "'," + usuario.fechaNacimiento + ",'" + usuario.nick + "')");
            int result = baseDatos.insertDatos("exec registrar '" + usuario.email + "','" + usuario.nick + "','" + usuario.pass + "','" + usuario.fechaNacimiento+"'");
            baseDatos.cerrarConexion();
            return result;
        }

        [HttpPost]
        [ActionName("crearPartida")]
        public int crearPartida(Partida partida)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            int result = baseDatos.insertDatos("exec crearPartida '" +  partida.nombre + "', " + partida.admin + ", " + partida.maxJugadores + ", " + partida.maxTiempo + ","+partida.pass +","+partida.tablero+ "");
            baseDatos.cerrarConexion();
            return result;
        }

        [HttpPost]
        [ActionName("anadirJugador")]
        public int anadirJugador(JugadorPartida jugadorPartida)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            int result = baseDatos.insertDatos("exec anadirJugador " + jugadorPartida.idUsuario + ", " + jugadorPartida.idPartida + "");
            baseDatos.cerrarConexion();
            return result;
        }

        [HttpPost]
        [ActionName("comenzarPartida")]
        public int comenzarPartida(int idPartida)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            int result = baseDatos.insertDatos("exec comenzarPartida " + idPartida + "");
            baseDatos.cerrarConexion();
            return result;
        }

        [HttpPost]
        [ActionName("crearBots")]
        public int crearBots(int nBots, int idPartida)
        {
            BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "usuario1", "abc123.");
            baseDatos.conectar();
            int result = 0;
            for (int i = 0; i < nBots; i++)
            {
                result = baseDatos.insertDatos("exec anadirJugador NULL" + "," + idPartida + "");
            }
            baseDatos.cerrarConexion();
            return result;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
