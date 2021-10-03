using Microsoft.AspNetCore.Mvc;
using Botanapoly.Models;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Text.Json;
using System.Collections;
using System.Linq;

namespace Botanapoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        QuerysSQL execSQL;

        [HttpPost]
        [Route("/new")]
        public HttpResponseMessage NuevoJugador([FromBody] Jugadores jug)
        {
            string sql;
            HttpResponseMessage response = new HttpResponseMessage();
            execSQL = new QuerysSQL();

            if (jug.idUsuario != 0)
            {
                if (string.IsNullOrEmpty(jug.partidaPass))
                {
                    sql = $"anadirJugador {jug.idUsuario},'{jug.idPartida}',null";
                }
                else
                {
                    sql = $"anadirJugador {jug.idUsuario},'{jug.idPartida}','{jug.partidaPass}'";
                }

            }
            else
            {
                if (string.IsNullOrEmpty(jug.partidaPass))
                {
                    sql = $"anadirJugador null,'{jug.idPartida}',null";
                }
                else
                {
                    sql = $"anadirJugador null,'{jug.idPartida}','{jug.partidaPass}'";
                }

            }

            execSQL.executeStoredProcedure(sql);

            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = "Se ha creado correctamente.";

            return response;
        }

        [HttpPost]
        [Route("/comprar")]
        public HttpResponseMessage comprarCasilla([FromBody] Jugadores jug)
        {
            string sql = $"comprar {jug.id}";
            HttpResponseMessage response = new HttpResponseMessage();

            execSQL = new QuerysSQL();

            int codAccion = execSQL.executeStoredProcedureINT(sql);
            
            switch (codAccion)
            {
                case 1:
                    response.StatusCode = HttpStatusCode.NoContent;
                    response.ReasonPhrase = "La casilla ya está comprada o el saldo es insuficiente.";
                    break;
                case 0:
                    response.StatusCode = HttpStatusCode.OK;
                    response.ReasonPhrase = "Compra exitosa";
                    break;
            }

            return response;
        }

        [HttpGet]
        [Route("/jugadoresinfo")]
        public IEnumerable<Jugadores> getJugadoresInfo(int idPartida)
        {
            string sql = $"getJugadoresInfo {idPartida}";
            execSQL = new QuerysSQL();

            List<object[]> resultadoLista = execSQL.executeStoredProcedureReader(sql);
            
            return Enumerable.Range(0, resultadoLista.Count).Select(i => new Jugadores(resultadoLista[i])).ToArray();
        }

        [HttpPost]
        [Route("/retirar")]
        public void retirarJugador([FromBody] Jugadores jug)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            execSQL = new QuerysSQL();
            string sql = $"retirarJugador {jug.id}";

            execSQL.executeStoredProcedure(sql);
        }

        [HttpPost]
        [Route("/abandonar")]
        public void abandonarPartida([FromBody] Jugadores jug)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            execSQL = new QuerysSQL();
            string sql = $"abandonarPartida {jug.id}";

            execSQL.executeStoredProcedure(sql);
        }

        [HttpPost]
        [Route("/dobles")]
        public void setDobles(int idJugador, int dobles)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            execSQL = new QuerysSQL();
            string sql = $"setDobles {idJugador},{dobles}";

            execSQL.executeStoredProcedure(sql);
        }

    }
}
