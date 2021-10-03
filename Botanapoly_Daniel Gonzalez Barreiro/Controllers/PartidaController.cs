using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;


namespace API_Botanapoly.Controllers
{
    [Route("partida")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        Database database = new Database();

        [HttpPost("crearPartida")]
        public string addPartida([FromBody] Partida partida)
        {
            string query;
            if(partida.maxJugadores == null )
            {
                partida.maxJugadores=6;
            }

            if (string.IsNullOrEmpty(partida.pass)){ 

                query = $"crearPartida'{partida.nombre}','{partida.administrador}','{partida.maxJugadores}','{partida.maxTiempo}',null,'{partida.tablero}'";
            } else { 
                query = $"crearPartida'{partida.nombre}','{partida.administrador}','{partida.maxJugadores}','{partida.maxTiempo}','{partida.pass}','{partida.tablero}'";

            }


            return database.insertQuery(query);
        }

        [HttpPost("unirsePartida")]
        public string addJugador( int idUsuario, int idPartida, string pass)
        {
            string query;

            if (string.IsNullOrEmpty(pass))
            {
                query = $"anadirJugador'{idUsuario}','{idPartida}',null";
            } else
            {
                query = $"anadirJugador'{idUsuario}','{idPartida}','{pass}'";

            }
            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("addBot")]
        public string addBot(int idPartida, string pass)
        {
            string query;
            
            if (string.IsNullOrEmpty(pass))
            {
                query = $"anadirJugador null,'{idPartida}',null";
            }
            else
            {
                query = $"anadirJugador null,'{idPartida}','{pass}'";

            }

            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("comenzarPartida")]
        public string startPartida(int idPartida)
        {
            string query = $"ComenzarPartida'{idPartida}'";

            return database.insertQuery(query);
        }
        
        [HttpPost("mover")]
        public string mover(int idJugador, int tirada)
        {
            string query;
            query = $"mover '{idJugador}','{tirada}'";
            System.Data.DataTable dt = database.selectQuery(query);
            int casillaNova = Convert.ToInt32(dt.Rows[0][0]);

            query = $"getCasillas null,'{casillaNova}'";
            System.Data.DataTable dt2 = database.selectQuery(query);
            int tipoCasilla = Convert.ToInt32(dt2.Rows[0]["tipo"]);

            switch (tipoCasilla)
            {
                case 2:
                case 3:
                case 4:
                case 8:
                    query = $"actualizarDeuda '{idJugador}',null, '{casillaNova}'";

                    return database.insertQuery(query);
                case 1:
                case 6:

                    return "casilla neutra";
                case 7:
                    query = $"castigar '{idJugador}'";

                    return database.insertQuery(query);
                case 5:
                    query = $"getCartaAleatoria '{idJugador}'";
                    System.Data.DataTable dt3 = database.selectQuery(query);
                    int idCarta = Convert.ToInt32(dt3.Rows[0][0]);

                    query = $"getInfoCarta '{idCarta}'";
                    System.Data.DataTable dt4 = database.selectQuery(query);
                    int tipoCarta = Convert.ToInt32(dt4.Rows[0]["tipo"]);
                    int valorCarta = Convert.ToInt32(dt4.Rows[0]["valor"]);

                    if (tipoCarta == 2)
                    {
                        query = $"actualizarDeuda '{idJugador}','{idCarta}','{tirada}'";
                        return database.insertQuery(query);
                    }
                    else
                    {
                        return mover(idJugador, valorCarta);
                    }

            }
            return "";

        }

        [HttpPost("comprar")]
        public string comprar(int idJugador)
        {
            string query = $"comprar '{idJugador}' ";
            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("edificar")]
        public string edificar(int idJugador, int idCasilla)
        {
            string query = $"edificar '{idJugador}','{idCasilla}'";

            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("venderEdificacion")]
        public string venderEdificacion(int idJugador, int idCasilla)
        {
            string query = $"venderEdificacion '{idJugador}','{idCasilla}'";

            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("actualizarNivelEdificacion")]
        public string actualizarNivelEdificacion(int idJugador, int tipo)
        {
            if ( tipo != 2 || tipo != 3 )
            {
                return "Tipo de casilla no valido";
            }

            string query = $"actualizarNivelConstruccion '{idJugador}','{tipo}'";
            return database.insertQuery(query);
        }


        [HttpPost("vender")]
        public string vender(int idJugador, int idCasilla)
        {
            string query = $"vender '{idJugador}','{idCasilla}'";
            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("finalizarTurno")]
        public string finalizarTurno(int idJugador)
        {
            string query = $"pagarDeuda '{idJugador}'";


            return database.insertQuery(query);

        }

        [HttpPost("mostrarTablero")]
        public string mostrarTablero(int idTablero)
        {
            string query = $"'{idTablero}'";
            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpGet("infoJugadores")]
        public List<Jugador> getJugadores(int idPartida)
        {

            string consulta = $"getJugadoresInfo '{idPartida}'";

            System.Data.DataTable dt = database.selectQuery(consulta);

            var lista = new List<Jugador>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Jugador jugador = new Jugador();
                jugador.id = Convert.ToInt32(dt.Rows[i]["id"]);
                jugador.idUsuario =
                dt.Rows[i]["idUsuario"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["idUsuario"]) : null;
                jugador.idPartida = Convert.ToInt32(dt.Rows[i]["idPartida"]);
                jugador.saldo = Convert.ToInt32(dt.Rows[i]["saldo"]);
                jugador.orden = Convert.ToInt32(dt.Rows[i]["orden"]);
                jugador.dobles = Convert.ToInt32(dt.Rows[i]["dobles"]);
                jugador.turnosDeCastigo = Convert.ToInt32(dt.Rows[i]["turnosDeCastigo"]);
                lista.Add(jugador);
            }

            return lista;
        }
        
        [HttpPost("retirarJugador")]
        public string retirarJugador(int idJugador)
        {
            string consulta = $"retirarJugador '{idJugador}'";

            return database.insertQuery(consulta);
        }

        [HttpPost("abandonarPartida")]
        public string abandonarPartida(int idJugador)
        {
            string consulta = $"abandonarPartida '{idJugador}'";

            return database.insertQuery(consulta);
        }

        

        [HttpPost("setDobles")]
        public string setDobles(int idJugador, int reset)
        {
            string query = $"setDobles '{idJugador}','{reset}'";

            return database.insertQuery(query);
        }      

        [HttpPost("getTurno")]
        public string getTurno(int idJugador, int idPartida)
        {
            string query = $"getTurno '{idPartida}','{idJugador}'";

            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("cartaAleatoria")]
        public int getCartaAleatoria(int idJugador)
        {
            string query = $"getCartaAleatoria '{idJugador}'";

            System.Data.DataTable dt = database.selectQuery(query);

            return Convert.ToInt32(dt.Rows[0]["id"]);
        }

        [HttpDelete("finalizarPartida")]
        public string finalizarPartida(int idPartida)
        {
            string query = $"finalizarPartida '{idPartida}'";

            return database.insertQuery(query);
        }
        
        [HttpPost("actualizarDeuda")]
        public string actualizarDeuda(int idJugador, int idCarta)
        {
            string query = $"actualizarDeuda '{idJugador}','{idCarta}'";
            return database.insertQuery(query);

        }

        [HttpPost("pagarDeuda")]
        public string pagarDeuda(int idJugador)
        {
            string query = $"pagarDeuda '{idJugador}'";


            System.Data.DataTable dt = database.selectQuery(query);
            return dt.Rows[0]["Column2"].ToString();

        }

        [HttpPost("getInfoCarta")]
        public Cartas getInfoCarta(int idCarta)
        {
            string query = $"getInfoCarta '{idCarta}'";

            System.Data.DataTable dt = database.selectQuery(query);
            Cartas carta = new Cartas();
            carta.id = Convert.ToInt32(dt.Rows[0]["id"]);
            carta.texto = Convert.ToString(dt.Rows[0]["texto"]);
            carta.valor = Convert.ToInt32(dt.Rows[0]["valor"]);
            carta.tipo = Convert.ToInt32(dt.Rows[0]["tipo"]);

            return carta;
        }

        [HttpGet("listarTableros")]
        public List<Tableros> listarTableros()
        {
            string query = $"getTableros";
            System.Data.DataTable dt = database.selectQuery(query);

            var lista = new List<Tableros>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tableros tablero = new Tableros();
                tablero.id = Convert.ToInt32(dt.Rows[i]["id"]);
                tablero.descripcion = Convert.ToString(dt.Rows[i]["descripcion"]);
                tablero.importe = Convert.ToInt32(dt.Rows[i]["importe"]);
                tablero.numCasillas = Convert.ToInt32(dt.Rows[i]["numCasillas"]);

                lista.Add(tablero);
            }
            return lista;
        }

        [HttpGet("listarCasillas")]
        public List<Casilla> getCasillas(int idTablero, int? idCasilla)
        {

            string query = "getCasillas";
            if (idCasilla != null)
            {
                query += "'" + idTablero + "'" + "," + "'" + idCasilla + "'";
            }
            else
            {
                query += "'" + idTablero + "'";
            }
            System.Data.DataTable dt = database.selectQuery(query);

            var lista = new List<Casilla>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Casilla casilla = new Casilla();
                casilla.id = Convert.ToInt32(dt.Rows[i]["id"]);
                casilla.tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                casilla.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                casilla.precioCompra = dt.Rows[i]["precioCompra"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioCompra"]) : null;
                casilla.precioVenta = dt.Rows[i]["precioVenta"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVenta"]) : null;
                casilla.costeEdificacion = dt.Rows[i]["costeEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["costeEdificacion"]) : null;
                casilla.precioVentaEdificacion = dt.Rows[i]["precioVentaEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]) : null;
                casilla.Coste1 = dt.Rows[i]["Coste1"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste1"]) : null;
                casilla.Coste2 = dt.Rows[i]["Coste2"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste2"]) : null;
                casilla.Coste3 = dt.Rows[i]["Coste3"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste3"]) : null;
                casilla.Coste4 = dt.Rows[i]["Coste4"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste4"]) : null;
                casilla.Coste5 = dt.Rows[i]["Coste5"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste5"]) : null;
                casilla.Coste6 = dt.Rows[i]["Coste6"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste6"]) : null;
                casilla.jugador = dt.Rows[i]["jugador"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["jugador"]) : null;
                casilla.conjunto = dt.Rows[i]["conjunto"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["conjunto"]) : null;
                casilla.destino = dt.Rows[i]["destino"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["destino"]) : null;


                lista.Add(casilla);
            }
            return lista;
        }

        [HttpGet("listarPartidas")]
        public List<Partida> getPartidas(int? idPartida)
        {
            string query = "getPartidas";
            if (idPartida != null)
            {
                query += "'" + idPartida + "'";
            }
            System.Data.DataTable dt = database.selectQuery(query);

            var lista = new List<Partida>();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Partida partida = new Partida();
                partida.id = Convert.ToInt32(dt.Rows[i]["id"]);
                partida.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                partida.maxJugadores = Convert.ToInt32(dt.Rows[i]["maxJugadores"]);
                partida.maxTiempo = dt.Rows[i]["maxTiempo"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["maxTiempo"]) : null;
                partida.tiempoTranscurrido = dt.Rows[i]["tiempoTranscurrido"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["tiempoTranscurrido"]) : null;
                partida.numJugadores = Convert.ToInt32(dt.Rows[i]["numJugadores"]);
                partida.turno = Convert.ToInt32(dt.Rows[i]["turno"]);
                partida.estado = Convert.ToInt32(dt.Rows[i]["estado"]);
                partida.tablero = Convert.ToInt32(dt.Rows[i]["tablero"]);
                partida.tienePass = Convert.ToBoolean(dt.Rows[i]["tienePass"]);

                lista.Add(partida);
            }
            return lista;
        }
        [HttpGet("getPropiedades")]
        public List<Casilla> getPropiedades(int idJugador)
        {
            string query = $"getPropiedades'{idJugador}'";
            System.Data.DataTable dt = database.selectQuery(query);

            var lista = new List<Casilla>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Casilla casilla = new Casilla();
                casilla.id = Convert.ToInt32(dt.Rows[i]["id"]);
                casilla.tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                casilla.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                casilla.precioCompra = dt.Rows[i]["precioCompra"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioCompra"]) : null;
                casilla.precioVenta = dt.Rows[i]["precioVenta"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVenta"]) : null;
                casilla.costeEdificacion = dt.Rows[i]["costeEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["costeEdificacion"]) : null;
                casilla.precioVentaEdificacion = dt.Rows[i]["precioVentaEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]) : null;
                casilla.Coste1 = dt.Rows[i]["Coste1"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste1"]) : null;
                casilla.Coste2 = dt.Rows[i]["Coste2"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste2"]) : null;
                casilla.Coste3 = dt.Rows[i]["Coste3"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste3"]) : null;
                casilla.Coste4 = dt.Rows[i]["Coste4"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste4"]) : null;
                casilla.Coste5 = dt.Rows[i]["Coste5"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste5"]) : null;
                casilla.conjunto = dt.Rows[i]["conjunto"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["conjunto"]) : null;
                casilla.destino = dt.Rows[i]["destino"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["destino"]) : null;
                casilla.nivelEdificacion = dt.Rows[i]["nivelEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["nivelEdificacion"]) : null;


                lista.Add(casilla);
            }
            return lista;
        }


        //Metodo que vende todas las propiedades junto con los edificios de estas y se obtiene el jugador con más saldo(getMasRico)
        private Jugador determinarGanador(int idPartida)
        {
            string query;

            query = $"getJugadoresInfo {idPartida};";
            System.Data.DataTable jugadores = database.selectQuery(query);
            for (int i = 0; i < jugadores.Rows.Count; i++)
            {
                int idJugador = Convert.ToInt32(jugadores.Rows[i]["id"]);
                query = $"getPropiedades {idJugador}";
                System.Data.DataTable propiedades = database.selectQuery(query);
                for (int j = 0; j < propiedades.Rows.Count; j++)
                {
                    int propiedad = Convert.ToInt32(propiedades.Rows[j]["id"]);
                    int nivelEdificacion = Convert.ToInt32(propiedades.Rows[j]["nivelEdificacion"]);
                    for (int k = 0; k < nivelEdificacion; k++)
                    {
                        query = $"venderEdificacion {idJugador},{propiedad}";
                        database.selectQuery(query);
                    }
                    vender(idJugador, propiedad);
                }
            }

            string ganador = $"getMasRico {idPartida}";
            System.Data.DataTable dt = database.selectQuery(ganador);

            Jugador jugador = new Jugador();
            jugador.id = Convert.ToInt32(dt.Rows[0]["id"]);
            if (dt.Rows[0]["idUsuario"] != System.DBNull.Value)
                jugador.idUsuario = Convert.ToInt32(dt.Rows[0]["idUsuario"]);
            jugador.idPartida = Convert.ToInt32(dt.Rows[0]["idPartida"]);
            jugador.saldo = Convert.ToInt32(dt.Rows[0]["saldo"]);
            jugador.orden = Convert.ToInt32(dt.Rows[0]["orden"]);
            if (dt.Rows[0]["posicion"] != System.DBNull.Value)
                jugador.posicion = Convert.ToInt32(dt.Rows[0]["posicion"]);
            jugador.dobles = Convert.ToInt32(dt.Rows[0]["dobles"]);
            jugador.turnosDeCastigo = Convert.ToInt32(dt.Rows[0]["turnosDeCastigo"]);

            return jugador;
        }

        [HttpPost("comprobarTiempoPartida")]
        public string comprobarTiempo(int idPartida)
        {
            string query = $"getTiempo {idPartida};";
            System.Data.DataTable dt = database.selectQuery(query);
            int tiempoRestante = Convert.ToInt32(dt.Rows[0]["Column1"]);
            if (tiempoRestante == 0)
            {
                Jugador ganador = determinarGanador(idPartida);
                return $"Ha ganado el jugador con id = {ganador.id}";
            }
            else
                return "Todavía no se ha acabado el tiempo";
        }

    }
}


