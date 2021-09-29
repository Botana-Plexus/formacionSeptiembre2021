﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Botanapoly.Controllers
{
    [Route("partida")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        public Database BD = new Database();

        [HttpPost("crear")]
        public string crearPartida([FromBody] Partidas partida)
        {
            if ( partida.maxJugadores > 6)
            {
                return "Numero de jugadores nor válido";
            }

            string consulta = $"crearPartida'{partida.nombre}','{partida.administrador}'," +
            $"'{partida.maxJugadores}','{partida.maxTiempo}','{partida.pass}','{partida.tablero}'";

            return BD.ejecutarConsultaInsert(consulta);
        }

        [HttpPost("unirse")]
        public string añadirJugador(int idJugador, int idPartida)
        {
            string consulta = $"anadirJugador  '{idJugador }','{idPartida}'";

            return BD.ejecutarConsultaInsert(consulta);
        }

        [HttpPost("comenzar")]
        public string comenzarPartida(int idPartida)
        {
            string consulta = $"comenzarPartida '{idPartida}'";

            return BD.ejecutarConsultaInsert(consulta);
        }

        [HttpPost("actualizarNivelEdificacion")]
        public string actualizarNivelEdificacion(int idJugador,int tipo)
        {
            if(tipo != 2 || tipo != 3)
            {
                return "Tipo de casilla no valido";
            }

            string consulta = $"actualizarNivelConstruccion '{idJugador}','{tipo}'"; 
            return BD.ejecutarConsultaInsert(consulta);
        }

        [HttpPost("comprar")]
        public string comprar(int idJugador)
        {
            string consulta = $"comprar '{idJugador}' ";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpPost("vender")]
        public string vender(int idJugador,int idCasilla)
        {
            string consulta = $"vender '{idJugador}','{idCasilla}' ";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
            return dt.Rows[0]["Column2"].ToString();
        }

        [HttpGet("mostrartableros")]
        public List<Tableros> mostrartableros()
        {
            string consulta = $"Select * from tableros";
            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

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



    }
}
