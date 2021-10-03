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
        BaseDatos baseDatos = new BaseDatos("localhost", "botanapoly_Botana", "pruebas", "pruebas");

        [ActionName("autenticar")]
        [HttpGet]
        public object[] autenticar(string email, string pass)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec autenticar '" + email + "','" + pass + "'");
            return listaObjetos[0];
        }

        [ActionName("comprar")]
        [HttpGet]
        public object[] comprar(int idJugador)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec comprar "+ idJugador + "");
            return listaObjetos[0];
        }

        [ActionName("vender")]
        [HttpGet]
        public object[] vender(int idJugador,int casilla)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec vender "+ idJugador + ","+casilla+"");
            return listaObjetos[0];
        }

        [ActionName("getListaTableros")]
        [HttpGet]
        public IEnumerable<Tablero> getListaTableros()
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getTableros");
            return Enumerable.Range(0, listaObjetos.Count).Select(index => new Tablero(listaObjetos[index])).ToArray();
        }

        [ActionName("getTablero")]
        [HttpGet]
        public IEnumerable<TableroCasillas> getTablero(int idTablero)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getCasillas " + idTablero+ "");
            return Enumerable.Range(0, listaObjetos.Count).Select(index => new TableroCasillas(listaObjetos[index])).ToArray();
        }

        [ActionName("getCasilla")]
        [HttpGet]
        public IEnumerable<TableroCasillas> getCasilla(int idCasilla)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getCasillas NULL," +idCasilla+"");
            return Enumerable.Range(0, listaObjetos.Count).Select(index => new TableroCasillas(listaObjetos[index])).ToArray();
        }

        [ActionName("getJugadoresInfo")]
        [HttpGet]
        public IEnumerable<Jugador> getJugadoresInfo(int idPartida)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getJugadoresInfo " + idPartida + "");
            return Enumerable.Range(0, listaObjetos.Count).Select(index => new Jugador(listaObjetos[index])).ToArray();
        }

        [ActionName("getPartida")]
        [HttpGet]
        public IEnumerable<Partida> getPartidas(int idPartida)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getPartidas " + idPartida + "");
            return Enumerable.Range(0, listaObjetos.Count).Select(index => new Partida(listaObjetos[index])).ToArray();
        }

        [ActionName("getPartidas")]
        [HttpGet]
        public IEnumerable<Partida> getPartidas()
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getPartidas");
            return Enumerable.Range(0, listaObjetos.Count).Select(index => new Partida(listaObjetos[index])).ToArray();
        }

        [HttpPost]
        [ActionName("registro")]
        public int registro([FromBody] Usuario usuario)
        {
            int result = baseDatos.insertDatos("exec registrar '" + usuario.email + "','" + usuario.nick + "','" + usuario.pass + "','" + usuario.fechaNacimiento+"'");
            return result;
        }

        [HttpPost]
        [ActionName("crearPartida")]
        public int crearPartida(Partida partida)
        {
            int result = baseDatos.insertDatos("exec crearPartida '" +  partida.nombre + "', " + partida.admin + ", " + partida.maxJugadores + ", " + partida.maxTiempo + ","+partida.pass +","+partida.tablero+ "");
            return result;
        }

        [HttpPost]
        [ActionName("anadirJugador")]
        public int anadirJugador(JugadorPartida jugadorPartida)
        {
            int result = baseDatos.insertDatos("exec anadirJugador " + jugadorPartida.idUsuario + ", " + jugadorPartida.idPartida + "");
            return result;
        }

        [HttpPost]
        [ActionName("comenzarPartida")]
        public int comenzarPartida(int idPartida)
        {
            int result = baseDatos.insertDatos("exec comenzarPartida " + idPartida + "");
            return result;
        }

        //[HttpPost]
        //[ActionName("crearBots")]
        //public int crearBots(int nBots, int idPartida)
        //{
        //    baseDatos.conectar();
        //    int result = 0;
        //    for (int i = 0; i < nBots; i++)
        //    {
        //        result = baseDatos.insertDatos("exec anadirJugador NULL" + "," + idPartida + "");
        //    }
        //    baseDatos.cerrarConexion();
        //    return result;
        //}

        [HttpPost]
        [ActionName("retirarJugador")]
        public int retirarJugador(int idJugador)
        {
            int result = baseDatos.insertDatos("exec retirarJugador " + idJugador + "");
            return result;
        }

        [HttpPost]
        [ActionName("abandonarPartida")]
        public int abandonarPartida(int idJugador)
        {
            int result = baseDatos.insertDatos("exec abandonarPartida " + idJugador + "");
            return result;
        }

        /*
                    VALORES RETORNADOS
            0 =  es que la casilla se puede comprar
            1 = deuda actualizada
            2 = castigo
            3,otro número = Significa que retornó una carta y el segundo valor es el id de la carta
        */

        [HttpGet]
        [ActionName("mover")]
        public int[] mover(int idJugador,int tirada)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec mover " + idJugador + "," + tirada + "");
            int idCasilla = (int) listaObjetos[0][0];
            List<object[]> getCasillas = baseDatos.ejecutarConsulta("exec getCasillas NULL, "+idCasilla + "");
            int tipo = (int)getCasillas[0][1];
            int? propietario = getCasillas[0][15] != System.DBNull.Value ? (int)getCasillas[0][15] : null;
            int[] actualizarDeuda = new int[2];
            actualizarDeuda[0]=0;
            if (tipo==2|tipo==3|tipo==4 && propietario!=null)
            {
                actualizarDeuda[0] = 1;
                baseDatos.insertDatos("exec actualizarDeuda " + idJugador + ", NULL, "+tirada+"");
            }else if(tipo==5)
            {
                List<object[]> cartaSel = baseDatos.ejecutarConsulta("exec getCartaAleatoria " + idJugador + "");
                
                List<object[]> infoCarta = baseDatos.ejecutarConsulta("exec getinfoCarta " + cartaSel[0][0] + "");
                Cartas carta = new Cartas(infoCarta[0]);
                actualizarDeuda[0] = 3;
                actualizarDeuda[1] = (int)infoCarta[0][0];
                if (carta.tipo==2)
                {
                    baseDatos.insertDatos("exec actualizarDeuda " + idJugador + "," + carta.id +"," +tirada+"");
                }else if (carta.tipo == 3)
                {
                    mover(idJugador, carta.valor);
                }
            }
            else if (tipo ==8)
            {
                actualizarDeuda[0] = 1;
                baseDatos.insertDatos("exec actualizarDeuda " + idJugador + "");
            }else if (tipo ==7)
            {
                baseDatos.insertDatos("exec castigar " + idJugador + "");
                actualizarDeuda[0] = 2;
            }

            return actualizarDeuda;
        }

        [HttpGet]
        [ActionName("edificar")]
        public List<object[]> edificar(int idJugador, int idCasilla)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec edificar " + idJugador + "," + idCasilla + "");
            return listaObjetos;
        }

        [HttpGet]
        [ActionName("venderEdificacion")]
        public List<object[]> venderEdificiacion(int idJugador, int idCasilla)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec venderEdificacion " + idJugador + "," + idCasilla + "");
            return listaObjetos;
        }

        [HttpPost]
        [ActionName("resetDobles")]
        public int resetDobles(int idJugador)
        {
            int result = baseDatos.insertDatos("exec setDobles "+idJugador+"," + 1 + "");
            return result;
        }

        [HttpPost]
        [ActionName("setDobles")]
        public int setDobles(int idJugador)
        {
            int result = baseDatos.insertDatos("exec setDobles " +idJugador +"");
            return result;
        }

        [HttpGet]
        [ActionName("getPropiedades")]
        public IEnumerable<Propiedades> getPropiedades(int idJugador)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getPropiedades " + idJugador + "");
            return Enumerable.Range(0, listaObjetos.Count).Select(index => new Propiedades(listaObjetos[index])).ToArray();
        }

        [HttpGet]
        [ActionName("pagarDeuda")]
        public List<object[]> pagarDeuda(int idJugador)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec pagarDeuda " + idJugador  + "");
            return listaObjetos;
        }

        [HttpPost]
        [ActionName("finalizarPartida")]
        public int finalizarPartida(int idPartida)
        {
            int result = baseDatos.insertDatos("exec finalizarPartida " + idPartida + "");
            return result;
        }

        [HttpPost]
        [ActionName("finalizarTurno")]
        public int finalizarTurno(int idJugador)
        {
            int result = baseDatos.insertDatos("exec finalizarTurno " +idJugador+"");
            return result;
        }

        [HttpGet]
        [ActionName("getTurno")]
        public List<object[]> getTurno(int idJugador)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getTurno " +idJugador+"");
            return listaObjetos;
        }

        /*
            Si retorna un JSON vacio significa que todavía queda tiempo o que el tiempo límite ya pasó
            Si el tiempo es = 0 retorna el jugador ganador
         */
        [HttpPost]
        [ActionName("comprobarTiempo")]
        public IEnumerable<Jugador> comprobarTiempo(int idPartida)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getTiempo " + idPartida + "");
            int tiempoRestante = (int)listaObjetos[0][0];
            if (tiempoRestante == 0)
            {
                List<object[]> listJugador = determinarGanador(idPartida);
                return Enumerable.Range(0, listJugador.Count).Select(index => new Jugador(listJugador[index])).ToArray();
            }
            else
                return Enumerable.Range(0,0).Select(index => new Jugador()).ToArray();
        }

        private List<object[]> determinarGanador(int idPartida)
        {
            List<object[]> listaObjetos = baseDatos.ejecutarConsulta("exec getJugadoresInfo " + idPartida + "");
            for (int i = 0; i < listaObjetos.Count; i++)
            {
                int jugador = (int)listaObjetos[i][0];
                List<object[]> listPropiedades = baseDatos.ejecutarConsulta("exec getPropiedades " + jugador + "");
                for (int j = 0; j < listPropiedades.Count; j++)
                {
                    int propiedad = (int)listPropiedades[j][0];
                    int nivelEdificacion = (int)listPropiedades[j][17];
                    for (int k = 0; k < nivelEdificacion; k++)
                    {
                        baseDatos.ejecutarConsulta("exec venderEdificacion " + jugador + ","+propiedad+"");
                    }
                    vender(jugador, propiedad);
                }
            }
            List<object[]> masRico = baseDatos.ejecutarConsulta("exec getMasRico " + idPartida + "");
            return masRico;
        }

    }
}
