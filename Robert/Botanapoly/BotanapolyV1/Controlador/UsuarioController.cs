using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotanapolyV1.Modelos.Dao;
using BotanapolyV1.Modelos.Dto;
using System.Net.Http;
using System.Net;
using System.Data;

namespace BotanapolyV1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly BaseDatos NuevaConexionBD = new();
        // ------------------- POST: REGISTRO --------------------
        #region POST: Registro Usuario
        [HttpPost("registro")]
        public string Registro([FromBody] UsuarioModeloDto Usuario )
        {
            string NuevoUsuario = 
                $"exec registrar '{Usuario.email}','{Usuario.nick}', '{Usuario.password}', '{Usuario.fechaNacimiento}'";

            return NuevaConexionBD.InsertaLosDatos(NuevoUsuario);
        }

        #endregion FIN: Registro Usuario

        // ------------------- GET: INICIAR SESION --------------------
        #region GET: Autenticacion Usuario
        [HttpGet("login")]
        public string Get(string email, string pass)
        {
           string AutenticacionUsuario = $"exec autenticar '{email}','{pass}'";

           DataTable setResultados =  NuevaConexionBD.HazLaConsulta(AutenticacionUsuario);

            return setResultados.Rows[0]["Column2"].ToString();
        }
        #endregion FIN: Autenticacion Usuario
    }
}
