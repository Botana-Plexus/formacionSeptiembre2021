using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanaPolyAPI.Models;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BotanaPolyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BotanaPolyController : ControllerBase
    {
        private BaseDatos BD = new BaseDatos("localhost", "botanapoly", "pruebas", "pruebas");


        [HttpPost]
        public string Registrarse([FromBody] Modelos.Usuario usuario) 
        {
            string consulta = $"registrar '{usuario.Email}', '{usuario.Nick}', '{usuario.Pass}', '{usuario.FechaNacimiento}';";

            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpPost]
        public string CrearPartida([FromBody] Modelos.Partida partida)
        {

            string consulta = $"CrearPartida '{partida.Administrador}', '{partida.Nombre}', '{partida.Pass}', '{partida.Tablero}', '{partida.MaxJugadores}', {partida.MaxTiempo};";

            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpPost]
        public string ComenzarPartida([FromBody] int partida)
        {
            string consulta = $"ComenzarPartida {partida};";

            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
        public string UnirsePartida([FromBody] int usuario, int partida)
        {
          string consulta = $"anadirJugador '{usuario}', '{partida}'";

          return BD.ejecutarConsultaMod(consulta);
        }
        

        [HttpGet]
        public string autenticar(string email, string pass)
        {
            
            string consulta = $"autenticar '{email}', '{pass}'";

            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            if(dt.Rows[0]["Column1"].Equals(0))
            {
                return "Autenticación realizada con éxito";
            }
            else
            {
                return "Error en la autenticación";
            }
        }

        [HttpPost]
        public string comprar(int usuario)
        {
            string consulta = $"comprar {usuario};";

            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpPost]
        public string vender(int usuario, int casilla)
        {
            string consulta = $"comprar {usuario}, {casilla};";

            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
        public string crearBot(int partida, int numero)
        {
            StringBuilder toret = new StringBuilder();
            string consulta = $"anadirJugador NULL, '{partida}'";
            for (int i = 0; i < numero; i++)
            {
                string msg = BD.ejecutarConsultaMod(consulta);
                toret.Append("Bot #" + i + "\n" + msg + "\n");
            }

            return toret.ToString();
        }

        [HttpGet]
        public List<Modelos.Tablero> mostrarListadoPlantillas()
        {
            string consulta = $"procedimiento";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            List<Modelos.Tablero> lista = new List<Modelos.Tablero>();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Modelos.Tablero plantilla = new Modelos.Tablero();
                plantilla.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                plantilla.Importe = Convert.ToInt32(dt.Rows[i]["importe"]);
                plantilla.NumCasillas = Convert.ToInt32(dt.Rows[i]["numCasillas"]);
                plantilla.Descripcion = dt.Rows[i]["descripcion"].ToString();
                lista.Add(plantilla);
            }

            return lista;
        }

        [HttpGet]
        public List<Modelos.Partida> mostrarListadoPartidasCreadas()
        {
            string consulta = $"procedimiento2";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            List<Modelos.Partida> lista = new List<Modelos.Partida>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Modelos.Partida partida = new Modelos.Partida();
                partida.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                partida.Administrador = Convert.ToInt32(dt.Rows[i]["administrador"]);
                partida.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                if(dt.Rows[i]["maxJugadores"] != System.DBNull.Value)
                    partida.MaxJugadores = Convert.ToInt32(dt.Rows[i]["maxJugadores"]);
                if(dt.Rows[i]["maxTiempo"] != System.DBNull.Value)
                    partida.MaxTiempo = Convert.ToInt32(dt.Rows[i]["maxTiempo"]);
                partida.Nombre = dt.Rows[i]["nombre"].ToString();
                if (dt.Rows[i]["pass"] != System.DBNull.Value)
                    partida.Pass = dt.Rows[i]["pass"].ToString();
                partida.NumJugadores = Convert.ToInt32(dt.Rows[i]["numJugadores"]);
                partida.Tablero = Convert.ToInt32(dt.Rows[i]["tablero"]);
                partida.Turno = Convert.ToInt32(dt.Rows[i]["turno"]);
                lista.Add(partida);
            }

            return lista;

        }




    } 
}
