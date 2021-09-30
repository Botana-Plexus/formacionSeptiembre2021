using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QC = Microsoft.Data.SqlClient;
using DT = System.Data;
using Microsoft.Data.SqlClient;
using Botanapoly.Models;

namespace Botanapoly.Controllers
{
    public class BDConnection
    {
       static readonly QC.SqlConnection connection = new(
            "Server=localhost;" +
                "Database=botanapoly;User ID=root;" +
                "Password=root;Encrypt=True;" +
                "TrustServerCertificate=True;Connection Timeout=30;"
            );
        
        public static void RegistrarUsuario(Usuarios usuario)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("registrar", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@email", usuario.Email));
                cmd.Parameters.Add(new SqlParameter("@nick", usuario.Nick));
                cmd.Parameters.Add(new SqlParameter("@pass", usuario.Pass));
                cmd.Parameters.Add(new SqlParameter("@fechaNac", usuario.FechaNacimiento));

                cmd.ExecuteReader();
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            } 
        }

        public static List<TiposCartas> MetodoAuxiliarPruebas()
        {
            try
            {
                using var command = new QC.SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandType = DT.CommandType.Text;
                command.CommandText = @"SELECT * FROM tiposCartas";

                QC.SqlDataReader reader = command.ExecuteReader();
                List<TiposCartas> tiposCartas = new();
                while (reader.Read())
                {
                    TiposCartas tc = new()
                    {
                        Id = (int)reader["id"],
                        Descripcion = (string)reader["descripcion"]
                    };

                    tiposCartas.Add(tc);
                }
                return tiposCartas;
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }          
        }

        public static string Autenticar(string email, string pass)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("autenticar", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@pass", pass));

                SqlDataReader reader = cmd.ExecuteReader();
                return reader[0].ToString();
                
                
                
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void CrearPartida(Partidas partida)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("crearPartida", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@nombre", partida.Nombre));
                cmd.Parameters.Add(new SqlParameter("@admin", partida.Administrador));
                cmd.Parameters.Add(new SqlParameter("@maxJugadores", partida.MaxJugadores));
                cmd.Parameters.Add(new SqlParameter("@maxTiempo", partida.MaxTiempo));
                cmd.Parameters.Add(new SqlParameter("@pass", partida.Password));
                cmd.Parameters.Add(new SqlParameter("@tablero", partida.Tablero));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

        public static void AddJugador(int usuario, int partida)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("anadirJugador", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idUsuario", usuario));
                cmd.Parameters.Add(new SqlParameter("@idPartida", partida));
                
                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void ComenzarPartida(int partida)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("ComenzarPartida", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idPartida", partida));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void ActualizarNivelConstruccion(int jugador, int tipo)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("ActualizarNivelConstruccion", connection)
                { 
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idJugador", jugador));
                cmd.Parameters.Add(new SqlParameter("@tipo", tipo));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void Comprar(int jugador)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("Comprar", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idJugador", jugador));
                

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void Vender(int jugador, int casilla)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("vender", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idJugador", jugador));
                cmd.Parameters.Add(new SqlParameter("@casilla", casilla));
                
                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static List<Partidas> GetPartidas(int id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("getPartidas", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@id", id));           

                SqlDataReader reader = cmd.ExecuteReader();
                List<Partidas> partidas= new();
                while (reader.Read())
                {
                    Partidas partida = new()
                    {
                        Id = (int)reader["id"],
                        Nombre = (string)reader["nombre"],
                        MaxJugadores = (int)reader["maxJugadores"],
                        MaxTiempo = (int)reader["maxTiempo"],
                        TiempoTranscurrido = (DateTime)reader["tiempoTranscurrido"],
                        NumJugadores = (int)reader["numJugadores"],
                        Turno = (int)reader["turno"],
                        Estado = (int)reader["estado"],
                        Tablero = (int)reader["tablero"]
                    };

                    partidas.Add(partida);
                }
                return partidas;


            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static List<Tableros> GetTableros()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("getTableros", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };

                List<Tableros> tableros = new();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tableros tablero = new();
                    tablero.Id = (int)reader["id"];
                    tablero.Descripcion = (string)reader["descripcion"];
                    tableros.Add(tablero);
                }
                return tableros;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static List<Casillas> GetCasillas(int id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("getCasillas", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idTablero", id));

                SqlDataReader reader = cmd.ExecuteReader();
                List<Casillas> casillas = new();
                
                while (reader.Read())
                {
                    Casillas casilla = new();

                    casilla.Id = (int)reader["id"];
                    casilla.Nombre = (string)reader["nombre"];
                    casilla.Orden = (int)reader["orden"];
                    if (reader["precioCompra"] != System.DBNull.Value)
                        casilla.PrecioCompra = (int)reader["precioCompra"];
                    if (reader["precioVenta"] != System.DBNull.Value)
                        casilla.PrecioVenta = (int)reader["precioVenta"];
                    if (reader["costeEdificacion"] != System.DBNull.Value)
                        casilla.CosteEdificacion = (int)reader["costeEdificacion"];
                    if (reader["precioVentaEdificacion"] != System.DBNull.Value)
                        casilla.PrecioVentaEdificacion = (int)reader["precioVentaEdificacion"];
                    if (reader["coste1"] != System.DBNull.Value)
                        casilla.Coste1 = (int)reader["coste1"];
                    if (reader["coste2"] != System.DBNull.Value)
                        casilla.Coste2 = (int)reader["coste2"];
                    if (reader["coste3"] != System.DBNull.Value)
                        casilla.Coste3 = (int)reader["coste3"];
                    if (reader["coste4"] != System.DBNull.Value)
                        casilla.Coste4 = (int)reader["coste4"];
                    if (reader["coste5"] != System.DBNull.Value)
                        casilla.Coste5 = (int)reader["coste5"];
                    if (reader["conjunto"] != System.DBNull.Value)
                        casilla.Conjunto = (int)reader["conjunto"];
                    if (reader["destino"] != System.DBNull.Value)
                        casilla.Destino = (int)reader["destino"];
                    

                  //  AcceptanceActID = !Convert.IsDBNull(reader["AcceptanceActID"]) ? (int?)reader["AcceptanceActID"] : null

                    casillas.Add(casilla);
                }

                return casillas;

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void GetJugadoresInfo(int id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("getJugadoresInfo", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idPartida", id));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void RetirarJugador(int id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("retirarJugador", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idJugador", id));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void AbandonarPartida(int id)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("abandonarPartida", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idJugador", id));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void Mover(int jugador, int tirada)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("mover", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idJugador", jugador));
                cmd.Parameters.Add(new SqlParameter("@tirada", tirada));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void Edificar(int jugador, int casilla)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("edificar", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idJugador", jugador));
                cmd.Parameters.Add(new SqlParameter("@idCasilla", casilla));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void VenderEdificacion(int jugador, int casilla)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("venderEdificacion", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idJugador", jugador));
                cmd.Parameters.Add(new SqlParameter("@idCasilla", casilla));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public static void SetDobles(int jugador, int reset)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new("getJugadoresInfo", connection)
                {
                    CommandType = DT.CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idJugador", jugador));
                cmd.Parameters.Add(new SqlParameter("@reset", reset));

                cmd.ExecuteReader();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
