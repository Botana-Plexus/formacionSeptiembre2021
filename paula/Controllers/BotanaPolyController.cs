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

        [HttpPost]
        public string ComenzarPartida(int idPartida)
        {
            string consulta = $"ComenzarPartida {idPartida};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
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
        

        [HttpGet]
        public string autenticar(string email, string pass)
        {
            string consulta = $"autenticar '{email}', '{pass}'";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            return dt.Rows[0]["Column2"].ToString();  
        }

        [HttpPost]
        public string comprar(int idJugador)
        {
            string consulta = $"comprar {idJugador};";
            return BD.ejecutarConsultaMod(consulta);
        }

        [HttpPost]
        public string vender(int usuario, int casilla)
        {
            string consulta = $"vender {usuario}, {casilla};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
        public string crearBot(int partida,string pass)
        {
            string consulta = $"anadirJugador NULL, {partida}, '{pass}'";
            return BD.ejecutarConsulta(consulta).ToString();
        }


        [HttpPost]
        public string retirarse(int idJugador)
        {
            string consulta = $"retirarJugador {idJugador};";
            string toret = BD.ejecutarConsultaMod(consulta);
            string consulta2 = $"finalizarTurno {idJugador};";
            BD.ejecutarConsultaMod(consulta2);
            return toret;
        }


        [HttpPost]
        public string abandonar(int idJugador)
        {
            string consulta = $"abandonarPartida {idJugador};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
        public string moverse(int idJugador, int tirada)
        {
            string consulta = $"mover {idJugador}, {tirada};";
            StringBuilder toret = new StringBuilder();
            System.Data.DataTable mover = BD.ejecutarConsulta(consulta);
            int casilla = Convert.ToInt32(mover.Rows[0]["Column1"]);
            toret.Append(mover.Rows[0]["Column2"].ToString());
            consulta = $"getCasillas NULL, {casilla};";
            System.Data.DataTable infoCasilla = BD.ejecutarConsulta(consulta);
            int tipoCasilla = Convert.ToInt32(infoCasilla.Rows[0]["tipo"]);
            switch (tipoCasilla)
            {
                case 2: case 3: case 4: case 8:
                    consulta = $"actualizarDeudaCompleta {idJugador}, NULL;";
                    toret.Append(BD.ejecutarConsultaMod(consulta));
                    break;
                case 5:
                    consulta = $"getCartaAleatoria {idJugador};";
                    System.Data.DataTable carta = BD.ejecutarConsulta(consulta);
                    int idCarta = Convert.ToInt32(carta.Rows[0]["id"]);
                    consulta = $"getInfoCarta {idCarta}";
                    System.Data.DataTable tipoCarta = BD.ejecutarConsulta(consulta);
                    int tipo = Convert.ToInt32(tipoCarta.Rows[0]["tipo"]);
                    
                    switch (tipo)
                    {
                        case 2:
                            consulta = $"actualizarDeudaCompleta {idJugador}, {idCarta};";
                            toret.Append(BD.ejecutarConsultaMod(consulta));
                            break;
                        case 3:
                            int valor = Convert.ToInt32(tipoCarta.Rows[0]["valor"]);
                            string mover2 = moverse(idJugador, valor);
                            toret.Append(mover2);
                            break;
                    }
                    break;
                case 7:
                    consulta = $"castigar {idJugador}";
                    toret.Append(BD.ejecutarConsultaMod(consulta));
                    break;
            }
            return toret.ToString();
        }

        [HttpPost]
        public string edificar(int idJugador, int idCasilla)
        {
            string consulta = $"edificar {idJugador}, {idCasilla};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
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

        [HttpGet]
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


        [HttpGet]
        public Modelos.Casilla getCasilla(int idCasilla)
        {
            string consulta = $"getCasillas NULL, {idCasilla}";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

                Modelos.Casilla casilla = new Modelos.Casilla();
                casilla.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                if (dt.Rows[0]["conjunto"] != System.DBNull.Value)
                    casilla.Conjunto = Convert.ToInt32(dt.Rows[0]["conjunto"]);
                if (dt.Rows[0]["coste1"] != System.DBNull.Value)
                    casilla.Coste1 = Convert.ToInt32(dt.Rows[0]["coste1"]);
                if (dt.Rows[0]["coste2"] != System.DBNull.Value)
                    casilla.Coste2 = Convert.ToInt32(dt.Rows[0]["coste2"]);
                if (dt.Rows[0]["coste3"] != System.DBNull.Value)
                    casilla.Coste3 = Convert.ToInt32(dt.Rows[0]["coste3"]);
                if (dt.Rows[0]["coste4"] != System.DBNull.Value)
                    casilla.Coste4 = Convert.ToInt32(dt.Rows[0]["coste4"]);
                if (dt.Rows[0]["coste5"] != System.DBNull.Value)
                    casilla.Coste5 = Convert.ToInt32(dt.Rows[0]["coste5"]);
                if (dt.Rows[0]["coste6"] != System.DBNull.Value)
                    casilla.Coste6 = Convert.ToInt32(dt.Rows[0]["coste6"]);
                if (dt.Rows[0]["costeEdificacion"] != System.DBNull.Value)
                    casilla.CosteEdificacion = Convert.ToInt32(dt.Rows[0]["costeEdificacion"]);
                if (dt.Rows[0]["destino"] != System.DBNull.Value)
                    casilla.Destino = Convert.ToInt32(dt.Rows[0]["destino"]);
                casilla.Orden = Convert.ToInt32(dt.Rows[0]["orden"]);
                if (dt.Rows[0]["precioCompra"] != System.DBNull.Value)
                    casilla.PrecioCompra = Convert.ToInt32(dt.Rows[0]["precioCompra"]);
                if (dt.Rows[0]["precioVenta"] != System.DBNull.Value)
                    casilla.PrecioVenta = Convert.ToInt32(dt.Rows[0]["precioVenta"]);
                if (dt.Rows[0]["precioVentaEdificacion"] != System.DBNull.Value)
                    casilla.PrecioVentaEdificacion = Convert.ToInt32(dt.Rows[0]["precioVentaEdificacion"]);
                if (dt.Rows[0]["jugador"] != System.DBNull.Value)
                    casilla.Propietario = Convert.ToInt32(dt.Rows[0]["jugador"]);
                casilla.Tipo = Convert.ToInt32(dt.Rows[0]["tipo"]);
                casilla.Nombre = dt.Rows[0]["nombre"].ToString();

            return casilla;
        }


        [HttpGet]
        public List<Modelos.Casilla> getTablero(int idTablero)
        {
            string consulta = $"getCasillas {idTablero}, NULL";
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
                if (dt.Rows[i]["jugador"] != System.DBNull.Value)
                    tablero.Propietario = Convert.ToInt32(dt.Rows[i]["jugador"]);
                tablero.Tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                tablero.Nombre = dt.Rows[i]["nombre"].ToString();
                lista.Add(tablero);
            }
            return lista;
        }

        [HttpGet]
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

        [HttpGet]
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

        [HttpGet]
        public string getTurno(int idPartida, int idJugador)
        {
            string consulta = $"getTurno {idPartida}, {idJugador}";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

            return dt.Rows[0]["Column2"].ToString();
        }


        [HttpPost]
        public string setDobles(int idJugador, int dobles)
        {
            string consulta = $"setDobles {idJugador}, {dobles};";
            return BD.ejecutarConsulta(consulta).Rows[0]["Column2"].ToString();
        }


        [HttpPost]
        public string pagar(int idJugador)
        {
            string consulta = $"pagarDeuda {idJugador};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
        public string finalizarPartida(int idPartida)
        {
            string consulta = $"finalizarPartida {idPartida};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
        public string finalizarTurno(int idJugador)
        {
            string consulta = $"finalizarTurno {idJugador};";
            return BD.ejecutarConsultaMod(consulta);
        }


        [HttpPost]
        public string comprobarTiempo(int idPartida)
        {
            string consulta = $"getTiempo {idPartida};";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            int tiempoRestante = Convert.ToInt32(dt.Rows[0]["Column1"]);
            if (tiempoRestante == 0)
            {
                Modelos.Jugador ganador = determinarGanador(idPartida);
                return $"Ha ganado el jugador con id = {ganador.Id}";
            }
            else
                return "Aun queda tiempo";
        }

        private Modelos.Jugador determinarGanador(int idPartida)
        {
            string consulta = $"getJugadoresInfo {idPartida};";
            System.Data.DataTable jugadores = BD.ejecutarConsulta(consulta);
            for(int i = 0; i < jugadores.Rows.Count; i++)
            {
                int idJugador = Convert.ToInt32(jugadores.Rows[i]["id"]);
                string consulta2 = $"getPropiedades {idJugador}";
                System.Data.DataTable propiedades = BD.ejecutarConsulta(consulta2);
                for (int j = 0; j < propiedades.Rows.Count; j++)
                {
                    int propiedad = Convert.ToInt32(propiedades.Rows[j]["id"]);
                    int nivelEdificacion = Convert.ToInt32(propiedades.Rows[j]["nivelEdificacion"]);
                    for (int k = 0; k < nivelEdificacion; k++){
                        string consulta3 = $"venderEdificacion {idJugador},{propiedad}";
                        BD.ejecutarConsulta(consulta3);
                    }
                    vender(idJugador, propiedad);
                }
            }

            string ganador = $"getMasRico {idPartida}";
            System.Data.DataTable dt = BD.ejecutarConsulta(ganador);

            Modelos.Jugador jugador = new Modelos.Jugador();
            jugador.Id = Convert.ToInt32(dt.Rows[0]["id"]);
            if (dt.Rows[0]["idUsuario"] != System.DBNull.Value)
                jugador.IdUsuario = Convert.ToInt32(dt.Rows[0]["idUsuario"]);
            jugador.IdPartida = Convert.ToInt32(dt.Rows[0]["idPartida"]);
            jugador.Saldo = Convert.ToInt32(dt.Rows[0]["saldo"]);
            jugador.Orden = Convert.ToInt32(dt.Rows[0]["orden"]);
            if (dt.Rows[0]["posicion"] != System.DBNull.Value)
                jugador.Posicion = Convert.ToInt32(dt.Rows[0]["posicion"]);
            jugador.Dobles = Convert.ToInt32(dt.Rows[0]["dobles"]);
            jugador.TurnosDeCastigo = Convert.ToInt32(dt.Rows[0]["turnosDeCastigo"]);

            return jugador;
        }
    } 
}
