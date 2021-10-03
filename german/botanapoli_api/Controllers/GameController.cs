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
            var listaPropiedadesJugador = new List<Modelos.PropiedadesJugador>();

            DataTable dt = conexion.DbRetrieveQuery(query);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Modelos.PropiedadesJugador propiedad = new Modelos.PropiedadesJugador();
                propiedad.Id = (int)dt.Rows[i]["id"];
                propiedad.Tipo = (int)dt.Rows[i]["tipo"];
                propiedad.Tablero = (int)dt.Rows[i]["tablero"];
                propiedad.Nombre = (string)dt.Rows[i]["nombre"];
                propiedad.NivelEdificacion = (int)dt.Rows[i]["nivelEdificacion"];
                propiedad.Coste1 = System.DBNull.Value != dt.Rows[i]["coste1"] ? (int)dt.Rows[i]["coste1"] : null;
                propiedad.Coste2 = System.DBNull.Value != dt.Rows[i]["coste2"] ? (int)dt.Rows[i]["coste2"] : null;
                propiedad.Coste3 = System.DBNull.Value != dt.Rows[i]["coste3"] ? (int)dt.Rows[i]["coste3"] : null;
                propiedad.Coste4 = System.DBNull.Value != dt.Rows[i]["coste4"] ? (int)dt.Rows[i]["coste4"] : null;
                propiedad.Coste5 = System.DBNull.Value != dt.Rows[i]["coste5"] ? (int)dt.Rows[i]["coste5"] : null;
                propiedad.Coste6 = System.DBNull.Value != dt.Rows[i]["coste6"] ? (int)dt.Rows[i]["coste6"] : null;
                propiedad.Coste6 = System.DBNull.Value != dt.Rows[i]["conjunto"] ? (int)dt.Rows[i]["conjunto"] : null;
                propiedad.PrecioCompra = System.DBNull.Value != dt.Rows[i]["precioCompra"] ? (int)dt.Rows[i]["precioCompra"] : null;
                propiedad.PrecioVenta = System.DBNull.Value != dt.Rows[i]["precioVenta"] ? (int)dt.Rows[i]["precioVenta"] : null;
                propiedad.PrecioVentaEdificacion = System.DBNull.Value != dt.Rows[i]["precioVentaEdificacion"] ? (int)dt.Rows[i]["precioVentaEdificacion"] : null;
                propiedad.Conjunto = System.DBNull.Value != dt.Rows[i]["conjunto"] ? (int)dt.Rows[i]["conjunto"] : null;
                listaPropiedadesJugador.Add(propiedad);
            }
            return listaPropiedadesJugador;
        }

        // Get turno de jugador en una partida
        [HttpPost]
        [ActionName("GetTurnoJugador")]
        public object[] GetTurnoJugador(int idJugador)
        {
            object[] resTurno = new object[2];
            DbController conexion = new DbController();

            DataTable res = conexion.DbRetrieveQuery($"getTurno {idJugador}");
            resTurno[0] = res.Rows[0][0];
            resTurno[1] = res.Rows[0][1];
            return resTurno;
        }

        // Post edificar en una casilla
        [HttpPost("Edificar")]
        [ActionName("Edificar")]
        public object[] Edificar([FromBody] int idJugador, int idCasilla)
        {
            object[] resEdificar = new object[2];
            DbController conexion = new DbController();

            DataTable res = conexion.DbRetrieveQuery($"edificar {idJugador}, {idCasilla}");
            resEdificar[0] = res.Rows[0][0];
            resEdificar[1] = res.Rows[0][1];
            return resEdificar;
        }

        // Post vender propiedad
        [HttpPost("VenderPropiedad")]
        [ActionName("VenderPropiedad")]
        public object[] VenderPropiedad(int idJugador, int idCasilla)
        {
            DbController conexion = new DbController();
            DataTable res = conexion.DbRetrieveQuery($"vender {idJugador}, {idCasilla}");
            return new object[] { res.Rows[0][0], res.Rows[0][1] };
        }

        // Post comprar propiedad
        [HttpPost("ComprarPropiedad")]
        [ActionName("ComprarPropiedad")]
        public object[] ComprarPropiedad(int idJugador)
        {
            DbController conexion = new DbController();

            DataTable res = conexion.DbRetrieveQuery($"comprar {idJugador}");
            return new object[] { res.Rows[0][0], res.Rows[0][1] };
        }

        // Post vender nivel de edificacion
        [HttpPost("VenderEdificacion")]
        [ActionName("VenderEdificacion")]
        public object[] VenderEdificacion(int idJUgador, int idcasilla)
        {
            DbController conexion = new DbController();

            DataTable res = conexion.DbRetrieveQuery($"venderEdificacion {idJUgador}, {idcasilla}");
            return new object[] { res.Rows[0][0], res.Rows[0][1] };
        }

        // Post pagar deuda
        [HttpPost("PagarDeuda")]
        [ActionName("PagarDeuda")]
        public object[] PagarDeuda(int idJUgador)
        {
            DbController conexion = new DbController();

            DataTable res = conexion.DbRetrieveQuery($"pagarDeuda {idJUgador}");
            return new object[] { res.Rows[0][0], res.Rows[0][1] };
        }

        // Post Finalizar turno
        [HttpPost("FinalizarTurno")]
        [ActionName("FinalizarTurno")]
        public int FinalizarTurno([FromBody] int idPartida, int idJugador)
        {
            DbController conexion = new DbController();

            return conexion.DbInsertQuery($"finalizarTurno {idJugador}, {idPartida}");
        }

        // Post retirar Jugador
        [HttpPost("RetirarJugador")]
        [ActionName("RetirarJugador")]
        public int RetirarJugador(int idJugador)
        {
            DbController conexion = new DbController();

            int res = conexion.DbInsertQuery($"retirarJugador {idJugador}");
            conexion.DbInsertQuery($"finalizarTurno {idJugador}");
            return res;
        }

        // Post Abandonar Jugador
        [HttpPost("AbandonarJugador")]
        [ActionName("AbandonarJugador")]
        public int AbandonarPartida(int idJugador)
        {
            DbController conexion = new DbController();

            return conexion.DbInsertQuery($"abandonarPartida {idJugador}");
        }

        // establecer dobles
        [HttpPost("SetDobles")]
        [ActionName("SetDobles")]
        public string SetDobles(int idJugador, bool dobles)
        {
            DbController conexion = new DbController();
            string query = dobles ?
                $"setDobles {idJugador}, 0"
                : $"setDobles {idJugador}, 1";

            DataTable dt = conexion.DbRetrieveQuery(query);
            return dt.Rows[0]["Column2"].ToString() + dt.Rows[0]["Column3"].ToString();
        }

        // Comprobar si queda tiempo restante de la partida
        [HttpPost("ComprobarTiempo")]
        [ActionName("ComprobarTiempo")]
        public int ComprobarTiempo(int idPartida)
        {
            var conexion = new DbController();
            DataTable dt = conexion.DbRetrieveQuery($"getTiempo {idPartida}");
            if ((int)dt.Rows[0][0] == 0)
            {
                return ObtenerMasRico(idPartida).Id;
            }
            else
            {
                return 0;
            }
        }

        // Obtener jugador mas rico
        private Modelos.Jugador ObtenerMasRico(int idPartida)
        {
            var conexion = new DbController();
            string query = $"getJugadoresInfo {idPartida}";
            DataTable dt = conexion.DbRetrieveQuery(query);

            var ganador = new Modelos.Jugador();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int idJugador = (int)dt.Rows[i]["id"];
                DataTable props = conexion.DbRetrieveQuery($"getPropiedades {idJugador}");

                for (int j = 0; j < props.Rows.Count; j++)
                {
                    int propiedad = (int)props.Rows[j]["id"];
                    int nivelEdificacion = (int)props.Rows[j]["nivelEdificacion"];

                    for (int k = 0; k < nivelEdificacion; k++)
                    {
                        VenderEdificacion(idJugador, propiedad);
                    }
                    VenderPropiedad(idJugador, propiedad);
                }
            }

            DataTable dt2 = conexion.DbRetrieveQuery($"getMasRico {idPartida}");
            ganador.Id = (int)dt2.Rows[0]["id"];
            ganador.IdPartida = (int)dt2.Rows[0]["idPartida"];
            ganador.Orden = (int)dt2.Rows[0]["orden"];
            ganador.Saldo = (int)dt2.Rows[0]["saldo"];
            ganador.Dobles = (int)dt2.Rows[0]["dobles"];
            ganador.TurnosDeCastigo = (int)dt2.Rows[0]["turnosDeCastigo"];
            ganador.IdUsuario = System.DBNull.Value != dt2.Rows[0]["idUsuario"] ? (int)dt2.Rows[0]["idUsuario"] : null;
            ganador.Posicion = System.DBNull.Value != dt2.Rows[0]["posicion"] ? (int)dt2.Rows[0]["posicion"] : null;

            return ganador;
        }

        // Flujo de turno
        [HttpPost("MoverJugador")]
        [ActionName("MoverJugador")]
        public string MoverJugador(int idJugador, int numMovs)
        {
            var conexion = new DbController();
            string query = $"mover {idJugador}, {numMovs}";
            DataTable dt = conexion.DbRetrieveQuery(query);

            int newPosition = (int)dt.Rows[0][0];
            DataTable casilla = conexion.DbRetrieveQuery($"getCasillas null, {newPosition}");
            int tipoCasilla = (int)(casilla.Rows[0]["tipo"]);

            switch(tipoCasilla)
            {
                case 1: case 6:
                    return "casilla neutra";

                case 2: case 3: case 4: case 8:
                    return (string)conexion.DbRetrieveQuery($"actualizarDeuda {idJugador}, null, {newPosition}").Rows[0][1];

                case 7:
                    return (string)conexion.DbRetrieveQuery($"castigar {idJugador}").Rows[0][1];

                case 5:
                    DataTable carta = conexion.DbRetrieveQuery($"getCartaAleatoria {idJugador}");
                    int cartaId = (int)carta.Rows[0][0];

                    DataTable infoCarta = conexion.DbRetrieveQuery($"getInfocarta {cartaId}");
                    int tipoCarta = (int)infoCarta.Rows[0]["tipo"];
                    int valorCarta = (int)infoCarta.Rows[0]["valor"];

                    if(tipoCarta == 2)
                    {
                        return (string)conexion.DbRetrieveQuery($"actualizarDeuda {idJugador}, {cartaId}, {numMovs}").Rows[0][1];
                    }
                    else
                    {
                            return MoverJugador(idJugador, valorCarta);
                    }
            }
                return "";
        }
    }
}
