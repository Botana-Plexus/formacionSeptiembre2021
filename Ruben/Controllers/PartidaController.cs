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

        //CONSULTAS GET


                        //getPropiedades de jugador 
                        [HttpGet("listaPropiedadesJugador")]
                        public List<Casillas> getPropiedades(int idJugador)
                        {
                            string consulta = $"getPropiedades '{idJugador}'";
                            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

                            var lista = new List<Casillas>();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                Casillas casilla = new Casillas();
                                casilla.id = Convert.ToInt32(dt.Rows[i]["id"]);
                                casilla.tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                                casilla.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                                casilla.precioCompra =
                                    dt.Rows[i]["precioCompra"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioCompra"]) : null;
                                casilla.precioVenta =
                                    dt.Rows[i]["precioVenta"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVenta"]) : null;
                                casilla.costeEdificacion =
                                    dt.Rows[i]["costeEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["costeEdificacion"]) : null;
                                casilla.precioVentaEdificacion =
                                    dt.Rows[i]["precioVentaEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]) : null;
                                casilla.Coste1 =
                                    dt.Rows[i]["Coste1"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste1"]) : null;
                                casilla.Coste2 =
                                    dt.Rows[i]["Coste2"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste2"]) : null;
                                casilla.Coste3 =
                                    dt.Rows[i]["Coste3"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste3"]) : null;
                                casilla.Coste4 =
                                    dt.Rows[i]["Coste4"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste4"]) : null;
                                casilla.Coste5 =
                                    dt.Rows[i]["Coste5"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste5"]) : null;
                                casilla.conjunto =
                                    dt.Rows[i]["conjunto"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["conjunto"]) : null;
                                casilla.destino =
                                    dt.Rows[i]["destino"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["destino"]) : null;
                                casilla.nivelEdificacion =
                                    dt.Rows[i]["nivelEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["nivelEdificacion"]) : null;
                                lista.Add(casilla);
                            }

                            return lista;

                        }



                        //getCasillas - Muestra las casillas de un tablero
                        [HttpGet("listaCasillas")]
                        public List<Casillas> getCasillas(int idTablero,int idCasilla)
                        {
                            string consulta;
                            if(idCasilla != 0)
                            {
                                  consulta = $"getCasillas '{idTablero}','{idCasilla}'";
                            }
                            else {

                                  consulta = $"getCasillas '{idTablero}',null";
                            }
                            
                            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

                            var lista = new List<Casillas>();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                Casillas casilla = new Casillas();
                                casilla.id = Convert.ToInt32(dt.Rows[i]["id"]);
                                casilla.tipo = Convert.ToInt32(dt.Rows[i]["tipo"]);
                                casilla.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                                casilla.precioCompra =
                                    dt.Rows[i]["precioCompra"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioCompra"]) : null;
                                casilla.precioVenta =
                                    dt.Rows[i]["precioVenta"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVenta"]) : null;
                                casilla.costeEdificacion =
                                    dt.Rows[i]["costeEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["costeEdificacion"]) : null;
                                casilla.precioVentaEdificacion =
                                    dt.Rows[i]["precioVentaEdificacion"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["precioVentaEdificacion"]) : null;
                                casilla.Coste1 =
                                    dt.Rows[i]["Coste1"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste1"]) : null;
                                casilla.Coste2 =
                                    dt.Rows[i]["Coste2"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste2"]) : null;
                                casilla.Coste3 =
                                    dt.Rows[i]["Coste3"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste3"]) : null;
                                casilla.Coste4 =
                                    dt.Rows[i]["Coste4"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste4"]) : null;
                                casilla.Coste5 =
                                    dt.Rows[i]["Coste5"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste5"]) : null;
                                casilla.Coste6 =
                                    dt.Rows[i]["Coste6"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["Coste6"]) : null;
                                casilla.conjunto =
                                    dt.Rows[i]["conjunto"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["conjunto"]) : null;
                                casilla.destino =
                                    dt.Rows[i]["destino"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["destino"]) : null;
                                casilla.propietario =
                                    dt.Rows[i]["jugador"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["jugador"]) : null;

                                lista.Add(casilla);
                            }

                            return lista;

                        }



                        //getPartidas - Muestra las partidas disponibles o solo una si le pasa id
                        [HttpGet("listaPartidas")]
                        public List<Partidas> getPartidas(int idPartida)
                        {

                            string consulta = "";
                            if (idPartida != 0)
                            {
                                consulta = $"getPartidas '{idPartida}'";
                            }
                            else
                            {
                                consulta = $"getPartidas";
                            }

                            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

                            var lista = new List<Partidas>();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                Partidas partida = new Partidas();
                                partida.id = Convert.ToInt32(dt.Rows[i]["id"]);
                                partida.nombre = Convert.ToString(dt.Rows[i]["nombre"]);
                                partida.maxJugadores = Convert.ToInt32(dt.Rows[i]["maxJugadores"]);
                                partida.maxTiempo =
                                      dt.Rows[i]["maxTiempo"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["maxTiempo"]) : null;
                                partida.tiempoTranscurrido =
                                      dt.Rows[i]["tiempoTranscurrido"] != System.DBNull.Value ? Convert.ToInt32(dt.Rows[i]["tiempoTranscurrido"]) : null;
                                partida.numJugadores = Convert.ToInt32(dt.Rows[i]["numJugadores"]);
                                partida.turno = Convert.ToInt32(dt.Rows[i]["turno"]);
                                partida.estado = Convert.ToInt32(dt.Rows[i]["estado"]);
                                partida.tablero = Convert.ToInt32(dt.Rows[i]["tablero"]);
                                partida.tienePass = Convert.ToBoolean(dt.Rows[i]["tienePass"]);

                                lista.Add(partida);
                            }

                            return lista;

                        }



                        //getTableros - Muestra los tableros disponibles
                        [HttpGet("listaTableros")]
                        public List<Tableros> getTableros()
                        {
                            string consulta = $"getTableros";
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



                        //getJugadores - Muestra informacion de los jugadores de una partida
                        [HttpGet("infoJugadores")]
                        public List<Jugadores> getJugadores(int idPartida)
                        {

                            string consulta = $"getJugadoresInfo '{idPartida}'";

                            System.Data.DataTable dt = BD.ejecutarConsulta(consulta);

                            var lista = new List<Jugadores>();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                Jugadores jugador = new Jugadores();
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



                        //GetTurno - Muestra si es mi turno, si estoy en castigo o si NO es mi turno
                        [HttpPost("getTurno")]
                        public string getTurno(int idJugador, int idPartida)
                        {
                            string query = $"getTurno '{idPartida}','{idJugador}'";

                            System.Data.DataTable dt = BD.ejecutarConsulta(query);
                            return dt.Rows[0]["Column2"].ToString();
                        }



                        //GetCartaAleatoria - Muestra el id de la carta que nos ha tocado aleatoriamente
                        [HttpPost("cartaAleatoria")]
                        public int getCartaAleatoria(int idJugador)
                        {
                            string query = $"getCartaAleatoria '{idJugador}'";

                            System.Data.DataTable dt = BD.ejecutarConsulta(query);

                            return Convert.ToInt32(dt.Rows[0]["id"]);
                        }



                        //GetInfoCarta - Muestra los campos de la tarjeta aleatoria pasandole el id
                        [HttpPost("getInfoCarta")]
                        public Cartas getInfoCarta(int idCarta)
                        {
                            string query = $"getInfoCarta '{idCarta}'";

                            System.Data.DataTable dt = BD.ejecutarConsulta(query);
                            Cartas carta = new Cartas();
                            carta.id = Convert.ToInt32(dt.Rows[0]["id"]);
                            carta.texto = Convert.ToString(dt.Rows[0]["texto"]);
                            carta.valor = Convert.ToInt32(dt.Rows[0]["valor"]);
                            carta.tipo = Convert.ToInt32(dt.Rows[0]["tipo"]);

                            return carta;
                        }


        //CONSULTAS POST

                    //Crear Partida
                    [HttpPost("crear")]
                    public string crearPartida([FromBody] Partidas partida)
                    {
                        string consulta;


                        if (partida.maxJugadores == null)
                        {
                            partida.maxJugadores = 6;
                        }
                        if (string.IsNullOrEmpty(partida.pass))
                        {

                            consulta = $"crearPartida'{partida.nombre}','{partida.administrador}'," +
                           $"'{partida.maxJugadores}','{partida.maxTiempo}',null,'{partida.tablero}'";
                        }
                        else
                        {
                            consulta = $"crearPartida'{partida.nombre}','{partida.administrador}'," +
                           $"'{partida.maxJugadores}','{partida.maxTiempo}','{partida.pass}','{partida.tablero}'";
                        }




                        return BD.ejecutarConsultaInsert(consulta);
                    }



                    //Unirse Partida
                    [HttpPost("unirse")]
                    public string añadirJugador(int idJugador, int idPartida, string pass)
                    {
                        string consulta;
                        if (string.IsNullOrEmpty(pass))
                        {
                            consulta = $"anadirJugador  '{idJugador }','{idPartida}',null";
                        }
                        else
                        {
                            consulta = $"anadirJugador '{idJugador}','{idPartida}','{pass}'";
                        }

                        System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
                        return dt.Rows[0]["Column2"].ToString();

                    }



                    //Comenzar Partida
                    [HttpPost("comenzar")]
                    public string comenzarPartida(int idPartida)
                    {
                        string consulta = $"comenzarPartida '{idPartida}'";

                        return BD.ejecutarConsultaInsert(consulta);
                    }



                    //Abandonar Partida - Se elimina al jugador de la partida
                    [HttpPost("abandonarPartida")]
                    public string abandonarPartida(int idJugador)
                    {
                        string consulta = $"abandonarPartida '{idJugador}'";

                        return BD.ejecutarConsultaInsert(consulta);
                    }



                    //Finalizar partida 
                    [HttpPost("finalizar")]
                    public string finalizarPartida(int idPartida)
                    {
                        string consulta = $"finalizarPartida '{idPartida}'";

                        return BD.ejecutarConsultaInsert(consulta);
                    }



                    //Retirar Jugador (deja de jugar pero sigue en partida)
                    [HttpPost("retirarJugador")]
                    public string retirarJugador(int idJugador)
                    {
                        string consulta = $"retirarJugador '{idJugador}'";

                        return BD.ejecutarConsultaInsert(consulta);
                    }



                    //Comprar casilla
                    [HttpPost("comprar")]
                    public string comprar(int idJugador)
                    {
                        string consulta = $"comprar '{idJugador}' ";
                        System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
                        return dt.Rows[0]["Column2"].ToString();
                    }



                    //Vender casilla
                    [HttpPost("vender")]
                    public string vender(int idJugador, int idCasilla)
                    {
                        string consulta = $"vender '{idJugador}','{idCasilla}' ";
                        System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
                        return dt.Rows[0]["Column2"].ToString();
                    }



                    //Edificar
                    [HttpPost("edificar")]
                    public string edificar(int idJugador, int idPartida)
                    {
                        string query = $"edificar '{idJugador}','{idPartida}'";

                        System.Data.DataTable dt = BD.ejecutarConsulta(query);
                        return dt.Rows[0]["Column2"].ToString();
                    }



                    //Crear Bots
                    [HttpPost("crearBot")]
                    public string crearBot(int idPartida, string pass)
                    {
                        string consulta;
                        if (string.IsNullOrEmpty(pass))
                        {
                            consulta = $"anadirJugador null,'{idPartida}',null";
                        }
                        else
                        {
                            consulta = $"anadirJugador null,'{idPartida}','{pass}'";
                        }

                        System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
                        return dt.Rows[0]["Column2"].ToString();
                    }




                    //Vender Edificación
                    [HttpPost("venderEdificacion")]
                    public string venderEdificacion(int idJugador, int idCasilla)
                    {
                        string consulta = $"venderEdificacion '{idJugador}','{idCasilla}'";

                        System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
                        return dt.Rows[0]["Column2"].ToString();
                    }




                    //Mover Jugador
                    [HttpPost("moverJugador")]
                    public string moverJudador(int idJugador, int tirada)
                    {
                        string consulta = $"mover '{idJugador}','{tirada}'";

                        System.Data.DataTable dt = BD.ejecutarConsulta(consulta);
                        return dt.Rows[0]["Column2"].ToString();
                    }




                    //SetDobles - Actualiza el campo dobles en jugador y reseteo
                    [HttpPost("dobles")]
                    public string setDobles(int idJugador, int reseteo)
                    {
                        string consulta = $"setDobles '{idJugador}','{reseteo}'";
                        return BD.ejecutarConsultaInsert(consulta);

                    }



                    //Actualizar deuda - Actualiza el campo deuda del jugador segun la casilla en la que estea
                    [HttpPost("actualizarDeuda")]
                    public string actualizarDeuda(int idJugador, int idCarta)
                    {
                        string consulta = $"actualizarDeuda '{idJugador}','{idCarta}'";
                        return BD.ejecutarConsultaInsert(consulta);

                    }



                    //Pagar deuda - Se paga la deuda si el jugador tiene suficiente salario
                    [HttpPost("pagarDeuda")]
                    public string pagarDeuda(int idJugador)
                    {
                        string query = $"pagarDeuda '{idJugador}'";

                        System.Data.DataTable dt = BD.ejecutarConsulta(query);
                        return dt.Rows[0]["Column2"].ToString();


                    }



                    //Finalizar turno - Cambia el campo turno de partida
                    [HttpPost("finalizarTurno")]
                    public string finalizarTurno(int idPartida,int idJugador)
                    {
                        string consulta = $"pagarDeuda '{idPartida}','{idJugador}'";
                        return BD.ejecutarConsultaInsert(consulta);

                    }


    } 
}
