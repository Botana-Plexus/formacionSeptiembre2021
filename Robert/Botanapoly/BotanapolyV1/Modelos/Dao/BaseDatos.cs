using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BotanapolyV1.Modelos.Dao
{
    public class BaseDatos
    {
        /* Sumario
         1# - Obtener conexión a la bd
         2# - Cerrar conexión bd
         3# - Insertar datos a la bd
         4# - Hacer consultas a la bd
         
         */
        public SqlConnection conexion;

        #region 1# Obtener Conexion
        public SqlConnection ObtenConexion()
        {
            this.conexion = new SqlConnection("" +
                "Server=tcp:localhost;" +
                "Database=botanapoly;" +
                "User ID=cr7;" +
                "Password=agua;" +
                "Encrypt=True;" +
                "TrustServerCertificate=true;" +
                "Connection Timeout=30;");

            return conexion;
        }
        #endregion FIN Obtener Conexion

     

        #region 3# Insertar Datos 
        public DataTable HazLaConsulta(String query)
        {
            SqlCommand command = new();
            {
                command.Connection = ObtenConexion();
                command.CommandType = CommandType.Text;
                command.CommandText = query;

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new();

                dt.Load(reader);
                command.Connection.Close();
                return dt;
            }
        }

        #endregion FIN Insertar Datos 

        #region 4# Hacer Consulta
        public string InsertaLosDatos(string query)
        {
            SqlCommand command = new();
            {
                command.Connection = ObtenConexion();
                command.CommandType = CommandType.Text;
                command.CommandText = query;

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    return "Acción realizada con éxito.";
                }
                catch (SqlException ex)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                        "Error: " + ex.Errors[i].Message + "\n");
                    }
                    command.Connection.Close();
                    return errorMessages.ToString();
                }
            }
        }
        #endregion FIN Hacer Consulta
    }
}
