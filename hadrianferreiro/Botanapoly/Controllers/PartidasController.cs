using Microsoft.AspNetCore.Mvc;
using Botanapoly.Models;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Botanapoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        QuerysSQL execSQL;
        [HttpPost]
        [Route("/nueva")]
        public HttpResponseMessage NuevaPartida([FromBody] Partidas p)
        {
            execSQL = new();
            HttpResponseMessage response = new();

            string sql;

            if (string.IsNullOrEmpty(p.pass))
            {
                sql = $"crearPartida '{p.nombre}','{p.administrador}','{p.maxJugadores}','{p.maxTiempo}',null,'{p.tablero}'";
            }
            else
            {
                sql = $"crearPartida '{p.nombre}','{p.administrador}','{p.maxJugadores}','{p.maxTiempo}','{p.pass}','{p.tablero}'";
            }

            execSQL.executeStoredProcedure(sql);

            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = "Se ha creado correctamente";

            return response;
        }

        [HttpPost]
        [Route("/iniciar_partida")]
        public HttpResponseMessage comenzarPartida([FromBody] Partidas p)
        {
            string sql = $"ComenzarPartida '{p.id}'";
            HttpResponseMessage response = new();
            execSQL = new QuerysSQL();

            execSQL.executeStoredProcedure(sql);

            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = "Partida iniciada correctamente";

            return response;
        }

        [HttpPost]
        [Route("/edificacion")]
        public HttpResponseMessage actualizarNivelConstruccion([FromBody] Jugadores jug)
        {
            HttpResponseMessage response = new();
            string sql = $"edificar {jug.id},{jug.casillaEspecifica}"; 
            execSQL = new QuerysSQL();

            int code = execSQL.executeStoredProcedureINT(sql);

            switch (code)
            {
                case 0:
                    response.StatusCode = HttpStatusCode.OK;
                    response.ReasonPhrase = "Se ha actualizado el nivel de edificación satisfactoriamente.";
                    break;
                case 1:
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = "El jugador no es propietario de todo el conjunto.";
                    break;
                case 2:
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = "No es edificable.";
                    break;
                case 3:
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = "Saldo insuficiente.";
                    break;
                case 4:
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = "Maximo nivel alcanzado.";
                    break;
            }

            return response;
        }

        [HttpPost]
        [Route("/vender_edificacion")]
        public HttpResponseMessage venderEdificacion([FromBody] Jugadores jug)
        {
            HttpResponseMessage response = new();
            string sql = $"venderEdificacion {jug.id},{jug.casillaEspecifica}";
            execSQL = new QuerysSQL();

            int code = execSQL.executeStoredProcedureINT(sql);

            switch (code)
            {
                case 0:
                    response.StatusCode = HttpStatusCode.OK;
                    response.ReasonPhrase = "Se ha vendido la edificación.";
                    break;
                case 1:
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = "No es posible vender la edificación.";
                    break;
            }

            return response;
        }

        [HttpGet]
        [Route("/partidas")]
        public IEnumerable<Partidas> getPartidas(int id)
        {
            string sql = $"getPartidas {id}";
            execSQL = new QuerysSQL();

            if (id == 0) sql = $"getPartidas null";

            List<object[]> resultadoLista = execSQL.executeStoredProcedureReader(sql);

            return Enumerable.Range(0, resultadoLista.Count).Select(i => new Partidas(resultadoLista[i])).ToArray();
        }

        [HttpPost]
        [Route("/mover")]
        public HttpResponseMessage mover([FromBody] Jugadores jug)
        {
            int code;
            HttpResponseMessage response = new();

            string sql = $"mover {jug.id},{jug.tirada}";
            execSQL = new QuerysSQL();

            int casillaActual = execSQL.executeStoredProcedureINT(sql); //casilla a la que se mueve

            sql = $"getCasillas null, {casillaActual}";

            List<object[]> resultadoLista = execSQL.executeStoredProcedureReader(sql);
            int tipoCasilla = Convert.ToInt32(resultadoLista[0][1]);

            switch (tipoCasilla)
            {
                case 2: case 3: case 4: case 8:     
                    sql = $"actualizarDeudaCompleta {jug.id}, null,{jug.tirada}";
                    code = execSQL.executeStoredProcedureINT(sql);
                    response.ReasonPhrase = "Tipos de casilla 2, 3, 4 y 8. Code: "+Convert.ToString(code);
                    break;
                case 5:     //carta sorpresa
                    sql = $"getCartaAleatoria {jug.id}";
                    int idCarta = execSQL.executeStoredProcedureINT(sql);
                    int tipo;

                    sql = $"getInfoCarta {idCarta}";
                    List<object[]> cartaInfo = execSQL.executeStoredProcedureReader(sql);
                    tipo = Convert.ToInt32(cartaInfo[0][3]);

                    //falta recuperar info de la carta
                    switch (tipo)
                    {
                        case 2:     //decremento
                            sql = $"actualizarDeudaCompleta {jug.id}, {idCarta},0";
                            response.ReasonPhrase = "Tipo de casilla 5 decremento. Code: " + Convert.ToString(execSQL.executeStoredProcedureINT(sql));
                            break;
                        case 3:     //movimiento
                            jug.tirada = (int)cartaInfo[0][2];
                            return mover(jug);
                    }
                    break;
                case 7:     //castigar
                    sql = $"castigar {jug.id}";
                    code = execSQL.executeStoredProcedureINT(sql);
                    response.ReasonPhrase = "Tipo de casilla 7. Code: " + Convert.ToString(code);
                    break;
            }

            return response;
        }

        /*[HttpPost]
        [Route("/actualizardeuda")]
        public HttpResponseMessage actualizarDeuda([FromBody] int[] parametros)
        {
            HttpResponseMessage response = new();

            string sql = $"actualizadDeuda {parametros[0]},{parametros[1]}";
            execSQL = new QuerysSQL();

            execSQL.executeStoredProcedure(sql);

            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = "Deuda iniciada correctamente";

            return response;
        }*/

        [HttpPost]
        [Route("/pagardeuda")]
        public HttpResponseMessage pagarDeuda([FromBody] Jugadores jug)
        {
            HttpResponseMessage response = new();

            string sql = $"pagarDeuda {jug.id}";
            execSQL = new QuerysSQL();

            int codigo = execSQL.executeStoredProcedureINT(sql);

            switch (codigo)
            {
                case 0:
                    response.StatusCode = HttpStatusCode.OK;
                    response.ReasonPhrase = "Pago realizado";
                    break;
                case 1:
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = "Saldo insuficiente";
                    break;
            }

            return response;
        }

        [HttpPost]
        [Route("/finalizarpartida")]
        public HttpResponseMessage finalizarPartida([FromBody] Partidas p)
        {
            HttpResponseMessage response = new();

            string sql = $"finalizarPartida {p.id}";
            execSQL = new QuerysSQL();

            execSQL.executeStoredProcedure(sql);

            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = "Partida finalizada correctamente";

            return response;
        }

        [HttpPost]
        [Route("/finalizarturno")]
        public HttpResponseMessage finalizarTurno([FromBody] Jugadores jug)
        {
            HttpResponseMessage response = new();

            string sql = $"finalizarTurno {jug.id}";
            execSQL = new QuerysSQL();

            execSQL.executeStoredProcedure(sql);

            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = "Turno finalizado correctamente";

            return response;
        }

        [HttpGet]
        [Route("/getcartaaleatoria")]
        public int getCasrtaAleatoria(int id)
        {
            string sql = $"getCartaAletoria {id}";
            execSQL = new QuerysSQL();

            return execSQL.executeStoredProcedureINT(sql);
        }

        [HttpGet]
        [Route("/infocarta")]
        public IEnumerable<Cartas> getInfoCarta(int id)
        {
            string sql = $"getInfoCarta {id}";
            execSQL = new QuerysSQL();

            List<object[]> resultadoLista = execSQL.executeStoredProcedureReader(sql);

            return Enumerable.Range(0, resultadoLista.Count).Select(i => new Cartas(resultadoLista[i])).ToArray();
        }
        
        [HttpPost]
        [Route("/turno")]
        public HttpResponseMessage turno([FromBody] Jugadores jug)
        {
            HttpResponseMessage response = new();

            string sql = $"getTurno {jug.id}";
            execSQL = new QuerysSQL();

            int codigo = execSQL.executeStoredProcedureINT(sql);

            switch (codigo)
            {
                case 0:
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = "No es tu turno";
                    break;
                case 1:
                    response.StatusCode = HttpStatusCode.OK;
                    response.ReasonPhrase = "Es tu turno.";
                    break;
                case 2:
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = "Sigues en la carcel.";
                    break;
            }

            return response;
        }

        [HttpPost]
        [Route("/vendercasilla")]
        public int venderCasilla([FromBody] Jugadores jug)
        {
            int response = 0;
            QuerysSQL execSQL = new QuerysSQL();
            string sql = $"vender {jug.id},{jug.casillaEspecifica}";

            int codAccion = execSQL.executeStoredProcedureINT(sql);

            switch (codAccion)
            {
                case 1:
                    response = 0;
                    break;
                case 0:
                    response = 1;
                    break;
            }

            return response;
        }

        [HttpPost]
        [Route("/comprobartiempo")]
        public int comprobarTiempo(int id)
        {
            execSQL = new QuerysSQL();
            string sql = $"getTiempo {id};";
            int tiempo = execSQL.executeStoredProcedureINT(sql);

            if (tiempo == 0)
            {
                Jugadores jug = determinarGanador(id);
                return jug.id;
            }
            else
                return 0;
        }

        private Jugadores determinarGanador(int id)
        {
            execSQL = new QuerysSQL();
            string sql = $"getJugadoresInfo {id};";
            List<object[]> jugInfoQry = execSQL.executeStoredProcedureReader(sql);
            for (int i = 0; i < jugInfoQry.Count(); i++)
            {
                int idJugador = (int)jugInfoQry[i][0];
                sql = $"getPropiedades {idJugador}";
                List<object[]> propiedadesQry = execSQL.executeStoredProcedureReader(sql);
                for (int j = 0; j < propiedadesQry.Count(); j++)
                {
                    int idPropiedad = (int)propiedadesQry[j][0];
                    int nivelEdificacion = (int)propiedadesQry[j][17];
                    for (int k = 0; k < nivelEdificacion; k++)
                    {
                        sql = $"venderEdificacion {idJugador},{idPropiedad}";
                        execSQL.executeStoredProcedure(sql);
                    }
                    Jugadores player = new();
                    player.id = idJugador;
                    player.casillaEspecifica = idPropiedad;
                    venderCasilla(player);
                }
            }
            sql = $"getMasRico {id}";
            List<object[]> masRico = execSQL.executeStoredProcedureReader(sql);

            Jugadores jug = new Jugadores();
            jug.id = (int)masRico[0][0];
            if (masRico[0][1] != System.DBNull.Value) jug.idUsuario = (int)masRico[0][1];
            jug.idPartida = (int)masRico[0][2];
            jug.saldo = (int)masRico[0][3];
            jug.orden = (int)masRico[0][4];
            if (masRico[0][5] != System.DBNull.Value) jug.posicion = (int)masRico[0][5];
            jug.dobles = (int)masRico[0][6];
            jug.turnosDeCastigo = (int)masRico[0][7];

            return jug;
        }

    }
}
