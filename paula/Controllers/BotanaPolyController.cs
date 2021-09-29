using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanaPolyAPI.Models;

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
            string consulta = $"registrar '{usuario.email}', '{usuario.nick}', '{usuario.passwd}', '{usuario.fecha_nac}';";

            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpPost]
        public string CrearPartida([FromBody] Modelos.Partida partida)
        {

            string consulta = $"CrearPartida '{partida.email_user}', '{partida.nombre}', '{partida.clave}', '{partida.config}', '{partida.no_jugadores}', {partida.no_rondas};";

            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpPost]
        public string ComenzarPartida([FromBody] int partida)
        {

            //recuperar número de jugadores en una partida y número máximo posible
            //hacer un bucle para añadir jugadores (UnirsePartida NULL, @partida) bot

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
        public void turno(int usuario)
        {
            //hacer tres submétodos: preTirada, tirada y postTirada
            //switch case dependiendo del id del usuario (null = bot)

            //JUGADOR:
            //preTirada: switch case con edificar, pasar a tirada o retirarse

            //tirada: se recoge el número de dado, se mueve y se analiza la tarjeta
            //dependiendo del tipo se hace un switch case y se analiza cada accion
            //opción recursiva de vender a la banca al terminar lo anterior

            //postTirada: switch case dependiendo del resultado anterior:
            // comprar, pagar (a jugador o banca), cobrar/pagar tarjeta, retirarse

            //BOT:
            //preTirada: se comprueba si se puede edificar y si sí, se hace

            //tirada: se tiran dados y avanza
            //en caso de vender se va por orden

            //si puede comprar lo hace, si no: accion correspondiente
        }

        [HttpPost]
        public void juego(Modelos.Partida partida)
        {
            //si el tiempo está fijado se pone el temporizador a funcionar
            //si no, número de jugadores actualez
            //while (Temp > 0 || jug > 1) :: turnos
            //llamada al método turno, después actualizar el turno
            //cuando se salga del while:: terminarPartida

        }





    } 
}
