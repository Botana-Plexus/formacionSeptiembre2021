using Microsoft.AspNetCore.Mvc;
using Botanapoly.Models;
using System.Net.Http;
using System.Net;
using System;

namespace Botanapoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        QuerysSQL execSQL;

        [HttpPost]
        [Route("/register")]
        public HttpResponseMessage NewUsuario([FromBody] Usuarios usr)
        {
            string sql = $"registrar '{usr.email}', '{usr.nick}','{usr.pass}','{usr.fechaNacimiento}'";
            HttpResponseMessage response = new();
            execSQL = new QuerysSQL();
            string email = usr.email, nick = usr.nick, pass = usr.pass;
            DateTime fechaNacimiento = usr.fechaNacimiento;

            execSQL.executeStoredProcedure(sql);

            response.StatusCode = HttpStatusCode.Created;
            response.ReasonPhrase = "Usuario creado correctamente.";

            return response;
        }

        [HttpPost]
        [Route("/login")]
        public HttpResponseMessage LoginUsuario([FromBody] Usuarios usr)
        {
            string sql = $"autenticar '{usr.email}','{usr.pass}'";
            HttpResponseMessage response = new();
            execSQL = new QuerysSQL();

            if(execSQL.executeStoredProcedureINT(sql) == 0)
            {
                response.ReasonPhrase = "Autenticado correctamente";
                response.StatusCode = HttpStatusCode.OK;
            } else
            {
                response.ReasonPhrase = "Autenticado incorrectamente";
                response.StatusCode = HttpStatusCode.NoContent;
            }
            
            return response;
        }
    }
}
