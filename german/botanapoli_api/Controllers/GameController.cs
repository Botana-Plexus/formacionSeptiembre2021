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

        // Get turno de jugador en una partida
        [HttpGet]
        [ActionName("GetTurnoJugador")]
        public object[] GetTurnoJugador(int idJugador, int idPartida)
        {
            object[] resTurno = new object[2];
            DbController conexion = new DbController();

            try
            {
                DataTable res = conexion.DbRetrieveQuery($"getTurno {idPartida}, {idJugador}");
                resTurno[0] = res.Rows[0][0];
                resTurno[1] = res.Rows[0][1];
                return resTurno;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post edificar en una casilla
        [HttpPost]
        [ActionName("Edificar")]
        public object[] Edificar(int idJugador, int idCasilla)
        {
            object[] resEdificar = new object[2];
            DbController conexion = new DbController();

            try
            {
                DataTable res = conexion.DbRetrieveQuery($"edificar {idJugador}, {idCasilla}");
                resEdificar[0] = res.Rows[0][0];
                resEdificar[1] = res.Rows[0][1];
                return resEdificar;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post moverse por el tablero
        [HttpPost]
        [ActionName("MoverJugador")]
        public string MoverJugador(int idJugador, int tirada)
        {
            DbController conexion = new DbController();

            try
            {
                DataTable res = conexion.DbRetrieveQuery($"mover {idJugador}, {tirada}");
                return (string)res.Rows[0][0];
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post vender propiedad
        [HttpPost]
        [ActionName("VenderPropiedad")]
        public object[] VenderPropiedad(int idJugador, int idCasilla)
        {
            object[] resVender = new object[2];
            DbController conexion = new DbController();

            try
            {
                DataTable res = conexion.DbRetrieveQuery($"vender {idJugador}, {idCasilla}");
                resVender[0] = res.Rows[0][0];
                resVender[1] = res.Rows[0][1];
                return resVender;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post comprar propiedad
        [HttpPost]
        [ActionName("ComprarPropiedad")]
        public object[] ComprarPropiedad(int idJugador)
        {
            object[] resComprar = new object[2];
            DbController conexion = new DbController();

            try
            {
                DataTable res = conexion.DbRetrieveQuery($"comprar {idJugador}");
                resComprar[0] = res.Rows[0][0];
                resComprar[1] = res.Rows[0][1];
                return resComprar;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post vender nivel de edificacion
        [HttpPost]
        [ActionName("VenderEdificacion")]
        public object[] VenderEdificacion (int idJUgador, int idcasilla)
        {
            object[] resVender = new object[2];
            DbController conexion = new DbController();

            try
            {
                DataTable res = conexion.DbRetrieveQuery($"venderEdificacion {idJUgador}, {idcasilla}");
                resVender[0] = res.Rows[0][0];
                resVender[1] = res.Rows[0][1];
                return resVender;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post pagar deuda
        [HttpPost]
        [ActionName("PagarDeuda")]
        public object[] PagarDeuda(int idJUgador)
        {
            object[] resPagar = new object[2];
            DbController conexion = new DbController();

            try
            {
                DataTable res = conexion.DbRetrieveQuery($"pagarDeuda {idJUgador}");
                resPagar[0] = res.Rows[0][0];
                resPagar[1] = res.Rows[0][1];
                return resPagar;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Get carta
        [HttpGet]
        [ActionName("ObtenerCarta")]
        public Modelos.Carta ObtenerCarta(int idJUgador)
        {
            Modelos.Carta carta = new Modelos.Carta();
            DbController conexion = new DbController();

            try
            {
                DataTable res = conexion.DbRetrieveQuery($"getCartaAleatoria {idJUgador}");
                int idCarta = (int)res.Rows[0][0];
                
                DataTable info = conexion.DbRetrieveQuery("getInfoCarta");
                carta.Id = (int)info.Rows[0]["id"];
                carta.Texto = (string)info.Rows[0]["texto"];
                carta.Valor = (int)info.Rows[0]["valor"];
                carta.Tipo = (int)info.Rows[0]["tipo"];

                return carta;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post retirar Jugador
        [HttpPost]
        [ActionName("RetirarJugador")]
        public int RetirarJugador(int idJugador)
        {
            DbController conexion = new DbController();

            try
            {
                int res = conexion.DbInsertQuery($"retirarJugador {idJugador}");
                return res;
            }
            catch(Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post Abandonar Jugador
        [HttpPost]
        [ActionName("AbandonarJugador")]
        public int AbandonarPartida(int idJugador)
        {
            DbController conexion = new DbController();

            try
            {
                int res = conexion.DbInsertQuery($"abandonarPartida {idJugador}");
                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post Finalizar turno
        [HttpPost]
        [ActionName("FinalizarTurno")]
        public int FinalizarTurno([FromBody] int idPartida, int idJugador)
        {
            DbController conexion = new DbController();

            try
            {
                int res = conexion.DbInsertQuery($"finalizarTurno {idJugador}, {idPartida}");
                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.GetType() + ": " + e.Message);
            }
        }

        // Post Hacer Tirada
        [HttpPost]
        [ActionName("HacerTirada")]

    }
}
