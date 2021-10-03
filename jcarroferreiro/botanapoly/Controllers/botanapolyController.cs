using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ProofOfConcept_SQL_CSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace botanapoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class botanapolyController : ControllerBase
    {
        Conexion cnx = new Conexion();
        //// GET: api/<usuarioController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<usuarioController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<usuarioController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        //AUTENTICARSE
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
        //REGISTRO DE USUARIOS
        [HttpPost("Registro")]
        public string Post([FromBody] Usuarios usuario)
        {
            //DATOS: nombre, telefono, fechaNacimiento, estadoCivil, email, nickname, contraseña

            string mensaje = "";
            string SQL = $"registrar '{usuario.email}', '{usuario.nick}', '{usuario.pass}', '{usuario.fechaNacimiento}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //REGISTRO DE TABLEROS
        [HttpPost("RegistroTablero")]
        public string Post([FromBody] Tablero tablero)
        {
            //DATOS: descripcion, importe, numCasillas

            string mensaje = "";
            string SQL = $"INSERT into tableros (id, descripcion, importe, numCasillas) VALUES ('{tablero.id}','{tablero.descripcion}', '{tablero.importe}', '{tablero.numCasillas}')";
            cnx.consultas(SQL);
            return mensaje;
        }
        //CREAR PARTIDA
        [HttpPost("CrearPartida")]
        public string Post([FromBody] CrearPartida crearPartida)
        {
            //DATOS: nombre,admin, maxJugadores,maxTiempo, pass, tablero 

            string mensaje = "";
            crearPartida.maxJugadores = crearPartida.maxJugadores == 0 ? 6 : crearPartida.maxJugadores;
            string SQL = $"crearPartida '{crearPartida.nombre}', '{crearPartida.admin}', '{crearPartida.maxJugadores}', '{crearPartida.maxTiempo}', '{crearPartida.pass}', '{crearPartida.tablero}'";
            if (string.IsNullOrEmpty(crearPartida.pass))
            {
                SQL = $"crearPartida '{crearPartida.nombre}', '{crearPartida.admin}', '{crearPartida.maxJugadores}', '{crearPartida.maxTiempo}', null, '{crearPartida.tablero}'";
            }
            cnx.consultas(SQL);
            return mensaje;
        }
        //INFO PARTIDA
        [HttpPost("InfoPartida")]
        public List<getPartidas> infoPartida(int idPartida)
        {
            //DATOS: id, descripcion, importe, numCasillas

            string SQL = $"getPartidas '{idPartida}'";
            List<getPartidas> lista = new List<getPartidas>();
            DataTable dt = cnx.consultas(SQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                getPartidas par = new getPartidas();

                par.id = Convert.ToInt32(dt.Rows[i]["id"]);
                par.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                par.maxJugadores = Convert.ToInt32(dt.Rows[i]["maxJugadores"]);
                par.maxTiempo = System.DBNull.Value != dt.Rows[i]["maxTiempo"] ? Convert.ToInt32(dt.Rows[i]["maxTiempo"]) : null;
                par.tiempoTranscurrido = System.DBNull.Value != dt.Rows[i]["tiempoTranscurrido"] ? Convert.ToInt32(dt.Rows[i]["tiempoTranscurrido"]) : null;
                par.numJugadores = Convert.ToInt32(dt.Rows[i]["numJugadores"]);
                par.turno = Convert.ToInt32(dt.Rows[i]["turno"]);
                par.estado = Convert.ToInt32(dt.Rows[i]["estado"]);
                par.tablero = Convert.ToInt32(dt.Rows[i]["tablero"]);
                lista.Add(par);
            }
            return lista;
        }
        //LISTADO PARTIDAS
        [HttpPost("ListadoPartidas")]
        public List<getPartidas> PostListaPartidas()
        {
            //DATOS: id, descripcion, importe, numCasillas

            string SQL = "SELECT * FROM partidas";
            List<getPartidas> lista = new List<getPartidas>();
            DataTable dt = cnx.consultas(SQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                getPartidas par = new getPartidas();

                par.id = Convert.ToInt32(dt.Rows[i]["id"]);
                par.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                par.maxJugadores = Convert.ToInt32(dt.Rows[i]["maxJugadores"]);
                par.maxTiempo = System.DBNull.Value != dt.Rows[i]["maxTiempo"] ? Convert.ToInt32(dt.Rows[i]["maxTiempo"]) : null;
                par.tiempoTranscurrido = System.DBNull.Value != dt.Rows[i]["tiempoTranscurrido"] ? Convert.ToInt32(dt.Rows[i]["tiempoTranscurrido"]) : null;
                par.numJugadores = Convert.ToInt32(dt.Rows[i]["numJugadores"]);
                par.turno = Convert.ToInt32(dt.Rows[i]["turno"]);
                par.estado = Convert.ToInt32(dt.Rows[i]["estado"]);
                par.tablero = Convert.ToInt32(dt.Rows[i]["tablero"]);
                lista.Add(par);
            }
            return lista;
        }
        //AÑADIR JUGADOR
        [HttpPost("AnadirJugador")]
        public string Post([FromBody] AnadirJugador anadirJugador)
        {
            //DATOS: idUsuario, idPartida 

            string mensaje = "";
            string SQL = $"anadirJugador '{anadirJugador.idUsuario}', '{anadirJugador.idPartida}', '{anadirJugador.pass}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //COMENZAR PARTIDA
        [HttpPost("ComenzarPartida")]
        public string Post([FromBody] ComenzarPartida comenzarPartida)
        {
            //DATOS: idPartida 

            string mensaje = "";
            string SQL = $"ComenzarPartida '{comenzarPartida.idPartida}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //LISTAR PLANTILLAS
        [HttpPost("getTableros")]
        public List<getTablero> PostListaTableros()
        {
            //DATOS: id, descripcion, importe, numCasillas

            string SQL = "getTableros";
            List<getTablero> lista = new List<getTablero>();
            DataTable dt = cnx.consultas(SQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                getTablero tab = new getTablero();
                tab.id = Convert.ToInt32(dt.Rows[i]["id"]);
                tab.descripcion = Convert.ToString(dt.Rows[i]["descripcion"]);
                tab.importe = Convert.ToInt32(dt.Rows[i]["importe"]);
                tab.numCasillas = Convert.ToInt32(dt.Rows[i]["numCasillas"]);
                lista.Add(tab);
            }
            return lista;
        }
        //INFO CASILLA
        [HttpPost("InfoCasilla")]
        public List<getCasillas> PostInfoCasilla(int idCasilla)
        {
            //DATOS: idPartida

            string SQL = $"getCasillas null, '{idCasilla}'";
            List<getCasillas> lista = new List<getCasillas>();
            DataTable dt = cnx.consultas(SQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                getCasillas cas = new getCasillas();
                cas.id = Convert.ToInt32(dt.Rows[i]["id"]);
                cas.tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                cas.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                cas.orden = Convert.ToInt32(dt.Rows[i]["orden"]);
                cas.precioCompra = System.DBNull.Value != dt.Rows[i]["precioCompra"] ? Convert.ToInt32(dt.Rows[i]["precioCompra"]) : null;
                cas.precioVenta = System.DBNull.Value != dt.Rows[i]["precioVenta"] ? Convert.ToInt32(dt.Rows[i]["precioVenta"]) : null;
                cas.costeEdificacion = System.DBNull.Value != dt.Rows[i]["costeEdificacion"] ? Convert.ToInt32(dt.Rows[i]["costeEdificacion"]) : null;
                cas.precioVentaEdificacion = System.DBNull.Value != dt.Rows[i]["precioVentaEdificacion"] ? Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]) : null;
                cas.Coste1 = System.DBNull.Value != dt.Rows[i]["Coste1"] ? Convert.ToInt32(dt.Rows[i]["Coste1"]) : null;
                cas.Coste2 = System.DBNull.Value != dt.Rows[i]["Coste2"] ? Convert.ToInt32(dt.Rows[i]["Coste2"]) : null;
                cas.Coste3 = System.DBNull.Value != dt.Rows[i]["Coste3"] ? Convert.ToInt32(dt.Rows[i]["Coste3"]) : null;
                cas.Coste4 = System.DBNull.Value != dt.Rows[i]["Coste4"] ? Convert.ToInt32(dt.Rows[i]["Coste4"]) : null;
                cas.Coste5 = System.DBNull.Value != dt.Rows[i]["Coste5"] ? Convert.ToInt32(dt.Rows[i]["Coste5"]) : null;
                cas.Coste6 = System.DBNull.Value != dt.Rows[i]["Coste6"] ? Convert.ToInt32(dt.Rows[i]["Coste6"]) : null;
                cas.conjunto = System.DBNull.Value != dt.Rows[i]["conjunto"] ? Convert.ToInt32(dt.Rows[i]["conjunto"]) : null;
                cas.destino = System.DBNull.Value != dt.Rows[i]["destino"] ? Convert.ToInt32(dt.Rows[i]["destino"]) : null;
                cas.jugador = System.DBNull.Value != dt.Rows[i]["jugador"] ? Convert.ToInt32(dt.Rows[i]["jugador"]) : null;
                lista.Add(cas);

            }
            return lista;
        }
        //INFO PROPIEDADES
        [HttpPost("infoPropiedadesJugador")]
        public string propiedadesJugador([FromBody] int idJugador)
        {
            //DATOS: idPartida 

            string mensaje = "";
            string SQL = $"getPropiedades '{idJugador}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //LISTAR CASILLAS
        [HttpPost("ListarCasillas")]
        public List<getCasillas> PostListaCasillas(int idTablero)
        {
            //DATOS: idPartida

            string SQL = $"getCasillas '{idTablero}'";
            List<getCasillas> lista = new List<getCasillas>();
            DataTable dt = cnx.consultas(SQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                getCasillas cas = new getCasillas();
                cas.id = Convert.ToInt32(dt.Rows[i]["id"]);
                cas.tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                cas.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                cas.orden = Convert.ToInt32(dt.Rows[i]["orden"]);
                cas.precioCompra = System.DBNull.Value != dt.Rows[i]["precioCompra"] ? Convert.ToInt32(dt.Rows[i]["precioCompra"]) : null;
                cas.precioVenta = System.DBNull.Value != dt.Rows[i]["precioVenta"] ? Convert.ToInt32(dt.Rows[i]["precioVenta"]) : null;
                cas.costeEdificacion = System.DBNull.Value != dt.Rows[i]["costeEdificacion"] ? Convert.ToInt32(dt.Rows[i]["costeEdificacion"]) : null;
                cas.precioVentaEdificacion = System.DBNull.Value != dt.Rows[i]["precioVentaEdificacion"] ? Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]) : null;
                cas.Coste1 = System.DBNull.Value != dt.Rows[i]["Coste1"] ? Convert.ToInt32(dt.Rows[i]["Coste1"]) : null;
                cas.Coste2 = System.DBNull.Value != dt.Rows[i]["Coste2"] ? Convert.ToInt32(dt.Rows[i]["Coste2"]) : null;
                cas.Coste3 = System.DBNull.Value != dt.Rows[i]["Coste3"] ? Convert.ToInt32(dt.Rows[i]["Coste3"]) : null;
                cas.Coste4 = System.DBNull.Value != dt.Rows[i]["Coste4"] ? Convert.ToInt32(dt.Rows[i]["Coste4"]) : null;
                cas.Coste5 = System.DBNull.Value != dt.Rows[i]["Coste5"] ? Convert.ToInt32(dt.Rows[i]["Coste5"]) : null;
                cas.Coste6 = System.DBNull.Value != dt.Rows[i]["Coste6"] ? Convert.ToInt32(dt.Rows[i]["Coste6"]) : null;
                cas.conjunto = System.DBNull.Value != dt.Rows[i]["conjunto"] ? Convert.ToInt32(dt.Rows[i]["conjunto"]) : null;
                cas.destino = System.DBNull.Value != dt.Rows[i]["destino"] ? Convert.ToInt32(dt.Rows[i]["destino"]) : null;
                cas.jugador = System.DBNull.Value != dt.Rows[i]["jugador"] ? Convert.ToInt32(dt.Rows[i]["jugador"]) : null;
                lista.Add(cas);
                }
            return lista;
        }
        
        //LISTAR JUGADORES
        [HttpPost("ListarJugadores")]
        public List<getJugadoresInfo> PostListaJugadores(int idPartida)
        {
            //DATOS: idPartida

            string SQL = $"getJugadoresInfo '{idPartida}'";
            List<getJugadoresInfo> lista = new List<getJugadoresInfo>();
            DataTable dt = cnx.consultas(SQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                getJugadoresInfo par = new getJugadoresInfo();
                par.id = Convert.ToInt32(dt.Rows[i]["id"]);
                par.idUsuario = System.DBNull.Value != dt.Rows[i]["idUsuario"] ? Convert.ToInt32(dt.Rows[i]["idUsuario"]) : null;
                par.idPartida = Convert.ToInt32(dt.Rows[i]["idPartida"]);
                par.saldo = Convert.ToInt32(dt.Rows[i]["saldo"]);
                par.orden = Convert.ToInt32(dt.Rows[i]["orden"]);
                par.posicion = Convert.ToInt32(dt.Rows[i]["posicion"]);
                par.dobles = Convert.ToInt32(dt.Rows[i]["dobles"]);
                par.turnosDeCastigo = Convert.ToInt32(dt.Rows[i]["turnosDeCastigo"]);
                lista.Add(par);
            }
            return lista;
        }
        //RETIRAR JUGADOR
        [HttpPost("RetirarJugador")]
        public string retirarJugador(int idJugadorRetirar)
        {
            //DATOS: idJugadorRetirar 

            string mensaje = "";
            string SQL = $"retirarJugador '{idJugadorRetirar}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //ABANDOONAR JUGADOR
        [HttpPost("AbandonarJugador")]
        public string abandonarJugador(int idJugadorAbandona)
        {
            //DATOS: idJugadorAbandona 

            string mensaje = "";
            string SQL = $"abandonarPartida '{idJugadorAbandona}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //MOSTRAR TURNO
        [HttpPost("MostrarTurno")]
        public string mostrarTurno(int idJugador, int idPartida)
        {
            //DATOS: idJugador, idPartida 

            string mensaje = "";
            string SQL = $"getTurno '{idJugador}', '{idPartida}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //EDIFICAR
        [HttpPost("Edificar")]
        public string edificar(int idJugador, int idCasilla)
        {
            //DATOS: idJugador, idCasilla 

            string mensaje = "";
            string SQL = $"edificar '{idJugador}', '{idCasilla}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //MOVER
        [HttpPost("Mover")]
        public string mover(int idJugador, int tirada)
        {
            //DATOS: idJugador, tirada 

            string mensaje = "";
            string SQL = $"mover '{idJugador}', '{tirada}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //COMPRAR
        [HttpPost("Comprar")]
        public string comprar(int idJugador)
        {
            //DATOS: idJugador 

            string mensaje = "";
            string SQL = $"comprar '{idJugador}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //VENDER
        [HttpPost("Vender")]
        public string vender(int idJugador, int idCasilla)
        {
            //DATOS: idJugador , idCasilla

            string mensaje = "";
            string SQL = $"vender '{idJugador}', '{idCasilla}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //VENDER DIFICACION
        [HttpPost("VenderEdificacion")]
        public string venderEdificacion(int idJugador, int idCasilla)
        {
            //DATOS: idJugador, idCasilla

            string mensaje = "";
            string SQL = $"venderEdificacion '{idJugador}', '{idCasilla}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //PAGAR DEUDA
        [HttpPost("PagarDeuda")]
        public string pagarDeuda(int idJugador)
        {
            //DATOS: idJugador 

            string mensaje = "";
            string SQL = $"pagarDeuda '{idJugador}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //TIRADA
        [HttpPost("Tirada")]
        public string tirada(int idJugador, int reset)
        {
            //DATOS: idJugador, reset

            string mensaje = "";
            string SQL = $"setDobles '{idJugador}', '{reset}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //FINALIZAR TURNO
        [HttpPost("FinalizarTurno")]
        public string finalizarTurno(int idPartida, int idJugador)
        {
            //DATOS: idJugador, idPartida

            string mensaje = "";
            string SQL = $"finalizarTurno '{idPartida}', '{idJugador}'";
            cnx.consultas(SQL);
            return mensaje;
        }
        //FINALIZAR PARTIDA
        [HttpPost("FinalizarPartida")]
        public string finalizarPartida(int idPartida)
        {
            //DATOS: idPartida

            string mensaje = "";
            string SQL = $"finalizarTurno '{idPartida}'";
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

