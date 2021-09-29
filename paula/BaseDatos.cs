using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;

namespace BotanaPolyAPI
{
    public class BaseDatos
    {

        private QC.SqlConnection connection;

        public BaseDatos(string server, string bd, string user, string pass) //pasar todos los datos
        {
            this.connection = new QC.SqlConnection(
                @$"Server={server}; Database={bd};
                User ID={user}; Password={pass};
                Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;") ;
        }

        public string ejecutarConsultaMod(string consulta)
        {
            using (var command = new QC.SqlCommand())
            {
                command.Connection = this.connection;
                command.CommandType = DT.CommandType.Text;
                command.CommandText = consulta;

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

        public System.Data.DataTable ejecutarConsulta(string consulta)
        {
            using (var command = new QC.SqlCommand())
            {
                command.Connection = this.connection;
                command.CommandType = DT.CommandType.Text;
                command.CommandText = consulta;

                command.Connection.Open();
                QC.SqlDataReader reader = command.ExecuteReader();
                System.Data.DataTable dt = new DT.DataTable();

                dt.Load(reader);
                command.Connection.Close();
                return dt;
            } 
        }
    }
}
