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
        private BaseDatos BD = new BaseDatos("localhost", "botanapoly_Botana", "pruebas", "pruebas");


        [HttpPost]
        public string Registrarse([FromBody] Modelos.Usuario usuario) 
        {
            string consulta = $"registrar '{usuario.Email}', '{usuario.Nick}', '{usuario.Pass}', '{usuario.FechaNacimiento}';";
            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpPost]
        public string CrearPartida([FromBody] Modelos.Partida partida)
        {
            if (String.IsNullOrEmpty(partida.Pass))
            {
                string consulta = $"CrearPartida '{partida.Nombre}', '{partida.Administrador}', '{partida.MaxJugadores}', {partida.MaxTiempo},'{partida.Pass}', '{partida.Tablero}';";
                return BD.ejecutarConsultaMod(consulta);
            }
            else
            {
                string consulta = $"CrearPartida '{partida.Nombre}', '{partida.Administrador}', '{partida.MaxJugadores}', {partida.MaxTiempo},'{partida.Pass}', '{partida.Tablero}';";
                return BD.ejecutarConsultaMod(consulta);
            } 
        }

        [HttpPost("idPartida")]
        public string ComenzarPartida(int idPartida)
        {
            string consulta = $"ComenzarPartida {idPartida};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost("idUsuario, idPartida, pass")]
        public string UnirsePartida(int idUsuario, int idPartida, string pass)
        {
            if (String.IsNullOrEmpty(pass))
            {
                string consulta = $"anadirJugador {idUsuario}, {idPartida}, NULL";
                return BD.ejecutarConsulta(consulta).Rows[0]["Column1"].ToString();
            }
            else
            {
                string consulta = $"anadirJugador {idUsuario}, {idPartida}, '{pass}'";
                return BD.ejecutarConsulta(consulta).Rows[0]["Column1"].ToString();
            }
        }
        

        [HttpGet("email,pass")]
        public string autenticar(string email, string pass)
        {
            
            string consulta = $"autenticar '{email}', '{pass}'";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            return dt.Rows[0]["Column2"].ToString();
            
        }

        [HttpPost("idJugador")]
        public string comprar(int idJugador)
        {
            string consulta = $"comprar {idJugador};";
            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpPost]
        public string vender(int usuario, int casilla)
        {
            string consulta = $"comprar {usuario}, {casilla};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
        public string crearBot(int partida,string pass)
        {
            string consulta = $"anadirJugador NULL, {partida}, '{pass}'";
            return BD.ejecutarConsulta(consulta).ToString();
        }


        [HttpPost("{idJugador}")]
        public string retirarse(int idJugador)
        {
            string consulta = $"retirarJugador {idJugador};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost("{idJugador}")]
        public string abandonar(int idJugador)
        {
            string consulta = $"abandonarPartida {idJugador};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost("{idJugador}, {tirada}")]
        public string mover(int idJugador, int tirada)
        {
            string consulta = $"mover {idJugador}, {tirada};";
            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpPost("{idJugador}, {idCasilla}")]
        public string edificar(int idJugador, int idCasilla)
        {
            string consulta = $"edificar {idJugador}, {idCasilla};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost("{idJugador}, {idCasilla}")]
        public string venderEdificacion(int idJugador, int idCasilla)
        {
            string consulta = $"venderEdificacion {idJugador}, {idCasilla};";
            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpGet]
        public List<Modelos.Tablero> getTableros()
        {
            string consulta = $"getTableros";
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
        public List<Modelos.Partida> getPartidas()
        {
            string consulta = $"getPartidas";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            List<Modelos.Partida> lista = new List<Modelos.Partida>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Modelos.Partida partida = new Modelos.Partida();
                partida.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                partida.Estado = Convert.ToInt32(dt.Rows[i]["Estado"]);
                if(dt.Rows[i]["maxJugadores"] != System.DBNull.Value)
                    partida.MaxJugadores = Convert.ToInt32(dt.Rows[i]["maxJugadores"]);
                if(dt.Rows[i]["maxTiempo"] != System.DBNull.Value)
                    partida.MaxTiempo = Convert.ToInt32(dt.Rows[i]["maxTiempo"]);
                if (dt.Rows[i]["tiempoTranscurrido"] != System.DBNull.Value)
                    partida.TiempoTranscurrido = Convert.ToInt32(dt.Rows[i]["tiempoTranscurrido"]);
                partida.Nombre = dt.Rows[i]["nombre"].ToString();
                partida.NumJugadores = Convert.ToInt32(dt.Rows[i]["numJugadores"]);
                partida.Tablero = Convert.ToInt32(dt.Rows[i]["tablero"]);
                partida.Turno = Convert.ToInt32(dt.Rows[i]["turno"]);
                lista.Add(partida);
            }
            return lista;
        }

        [HttpGet("{idPartida}")]
        public Modelos.Partida getPartida(int idPartida)
        {
            string consulta = $"getPartidas {idPartida}";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            Modelos.Partida partida = new Modelos.Partida();
            partida.Id = Convert.ToInt32(dt.Rows[0]["id"]);
            partida.Estado = Convert.ToInt32(dt.Rows[0]["Estado"]);
            if (dt.Rows[0]["maxJugadores"] != System.DBNull.Value)
                partida.MaxJugadores = Convert.ToInt32(dt.Rows[0]["maxJugadores"]);
            if (dt.Rows[0]["maxTiempo"] != System.DBNull.Value)
                partida.MaxTiempo = Convert.ToInt32(dt.Rows[0]["maxTiempo"]);
            partida.Nombre = dt.Rows[0]["nombre"].ToString();
            partida.NumJugadores = Convert.ToInt32(dt.Rows[0]["numJugadores"]);
            partida.Tablero = Convert.ToInt32(dt.Rows[0]["tablero"]);
            partida.Turno = Convert.ToInt32(dt.Rows[0]["turno"]);

            return partida;
        }


        [HttpGet("{idTablero}")]
        public List<Modelos.Casilla> getTablero(int idTablero)
        {
            string consulta = $"getCasillas {idTablero}";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            List<Modelos.Casilla> lista = new List<Modelos.Casilla>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Modelos.Casilla tablero = new Modelos.Casilla();
                tablero.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                if (dt.Rows[i]["conjunto"] != System.DBNull.Value)
                    tablero.Conjunto = Convert.ToInt32(dt.Rows[i]["conjunto"]);
                if (dt.Rows[i]["coste1"] != System.DBNull.Value)
                    tablero.Coste1 = Convert.ToInt32(dt.Rows[i]["coste1"]);
                if (dt.Rows[i]["coste2"] != System.DBNull.Value)
                tablero.Coste2 = Convert.ToInt32(dt.Rows[i]["coste2"]);
                if (dt.Rows[i]["coste3"] != System.DBNull.Value)
                    tablero.Coste3 = Convert.ToInt32(dt.Rows[i]["coste3"]);
                if (dt.Rows[i]["coste4"] != System.DBNull.Value)
                    tablero.Coste4 = Convert.ToInt32(dt.Rows[i]["coste4"]);
                if (dt.Rows[i]["coste5"] != System.DBNull.Value)
                    tablero.Coste5 = Convert.ToInt32(dt.Rows[i]["coste5"]);
                if (dt.Rows[i]["coste6"] != System.DBNull.Value)
                    tablero.Coste6 = Convert.ToInt32(dt.Rows[i]["coste6"]);
                if (dt.Rows[i]["costeEdificacion"] != System.DBNull.Value)
                    tablero.CosteEdificacion = Convert.ToInt32(dt.Rows[i]["costeEdificacion"]);
                if (dt.Rows[i]["destino"] != System.DBNull.Value)
                    tablero.Destino = Convert.ToInt32(dt.Rows[i]["destino"]);
                tablero.Orden = Convert.ToInt32(dt.Rows[i]["orden"]);
                if (dt.Rows[i]["precioCompra"] != System.DBNull.Value)
                    tablero.PrecioCompra = Convert.ToInt32(dt.Rows[i]["precioCompra"]);
                if (dt.Rows[i]["precioVenta"] != System.DBNull.Value)
                    tablero.PrecioVenta = Convert.ToInt32(dt.Rows[i]["precioVenta"]);
                if (dt.Rows[i]["precioVentaEdificacion"] != System.DBNull.Value)
                    tablero.PrecioVentaEdificacion = Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]);
                tablero.Tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                tablero.Nombre = dt.Rows[i]["nombre"].ToString();
                lista.Add(tablero);
            }
            return lista;
        }

        [HttpGet("{idPartida}")]
        public List<Modelos.Jugador> getJugadoresPartida(int idPartida)
        {
            string consulta = $"getJugadoresInfo {idPartida}";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            List<Modelos.Jugador> lista = new List<Modelos.Jugador>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Modelos.Jugador jugador = new Modelos.Jugador();
                jugador.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                if (dt.Rows[i]["idUsuario"] != System.DBNull.Value)
                    jugador.IdUsuario = Convert.ToInt32(dt.Rows[i]["idUsuario"]);
                jugador.IdPartida = Convert.ToInt32(dt.Rows[i]["idPartida"]);
                jugador.Saldo = Convert.ToInt32(dt.Rows[i]["saldo"]);
                jugador.Orden = Convert.ToInt32(dt.Rows[i]["orden"]);
                if (dt.Rows[i]["posicion"] != System.DBNull.Value)
                    jugador.Posicion = Convert.ToInt32(dt.Rows[i]["posicion"]);
                jugador.Dobles = Convert.ToInt32(dt.Rows[i]["dobles"]);
                jugador.TurnosDeCastigo = Convert.ToInt32(dt.Rows[i]["turnosDeCastigo"]);
                lista.Add(jugador);
            }
            return lista;
        }

        [HttpGet("{idJugador}")]
        public List<Modelos.PropiedadesJugador> getPropiedades(int idJugador)
        {
            string consulta = $"getPropiedades {idJugador}";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            List<Modelos.PropiedadesJugador> lista = new List<Modelos.PropiedadesJugador>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Modelos.PropiedadesJugador propiedad = new Modelos.PropiedadesJugador();
                propiedad.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                if (dt.Rows[i]["conjunto"] != System.DBNull.Value)
                    propiedad.Conjunto = Convert.ToInt32(dt.Rows[i]["conjunto"]);
                if (dt.Rows[i]["coste1"] != System.DBNull.Value)
                    propiedad.Coste1 = Convert.ToInt32(dt.Rows[i]["coste1"]);
                if (dt.Rows[i]["coste2"] != System.DBNull.Value)
                    propiedad.Coste2 = Convert.ToInt32(dt.Rows[i]["coste2"]);
                if (dt.Rows[i]["coste3"] != System.DBNull.Value)
                    propiedad.Coste3 = Convert.ToInt32(dt.Rows[i]["coste3"]);
                if (dt.Rows[i]["coste4"] != System.DBNull.Value)
                    propiedad.Coste4 = Convert.ToInt32(dt.Rows[i]["coste4"]);
                if (dt.Rows[i]["coste5"] != System.DBNull.Value)
                    propiedad.Coste5 = Convert.ToInt32(dt.Rows[i]["coste5"]);
                if (dt.Rows[i]["coste6"] != System.DBNull.Value)
                    propiedad.Coste6 = Convert.ToInt32(dt.Rows[i]["coste6"]);
                if (dt.Rows[i]["costeEdificacion"] != System.DBNull.Value)
                    propiedad.CosteEdificacion = Convert.ToInt32(dt.Rows[i]["costeEdificacion"]);
                if (dt.Rows[i]["destino"] != System.DBNull.Value)
                    propiedad.Destino = Convert.ToInt32(dt.Rows[i]["destino"]); // NECESARIO?
                propiedad.Orden = Convert.ToInt32(dt.Rows[i]["orden"]);
                if (dt.Rows[i]["precioCompra"] != System.DBNull.Value)
                    propiedad.PrecioCompra = Convert.ToInt32(dt.Rows[i]["precioCompra"]);
                if (dt.Rows[i]["precioVenta"] != System.DBNull.Value)
                    propiedad.PrecioVenta = Convert.ToInt32(dt.Rows[i]["precioVenta"]);
                if (dt.Rows[i]["precioVentaEdificacion"] != System.DBNull.Value)
                    propiedad.PrecioVentaEdificacion = Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]);
                propiedad.Tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                propiedad.Tablero = Convert.ToInt32(dt.Rows[i]["tablero"]);
                propiedad.NivelEdificacion = Convert.ToInt32(dt.Rows[i]["nivelEdificacion"]);
                propiedad.Nombre = dt.Rows[i]["nombre"].ToString();
                lista.Add(propiedad);
            }
            return lista;
        }

        [HttpGet("{idPartida}, {idJugador}")]
        public string getTurno(int idPartida, int idJugador)
        {
            string consulta = $"getTurno {idPartida}, {idJugador}";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            return dt.Rows[0]["Column2"].ToString();
        }


        [HttpPost("{idJugador}, {dobles}")]
        public string setDobles(int idJugador, int dobles)
        {
            string consulta = $"setDobles {idJugador}, {dobles};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost("{idJugador}")]
        public string pagar(int idJugador)
        {
            string consulta = $"pagarDeuda {idJugador};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost("{idPartida}")]
        public string finalizarPartida(int idPartida)
        {
            string consulta = $"finalizarPartida {idPartida};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost("{idPartida}, {idJugador}")]
        public string finalizarTurno(int idPartida, int idJugador)
        {
            string consulta = $"finalizarTurno {idPartida}, {idJugador};";
            return BD.ejecutarConsultaMod(consulta);
        }

    } 
}
