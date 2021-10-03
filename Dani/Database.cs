using System;
using System.Collections.Generic;
using System.Linq;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Text;

namespace API_Botanapoly
{
        public class Database
        {
            public QC.SqlConnection connection;

            public Database() 
            {
                this.connection = new QC.SqlConnection(
                    "Server=localhost;" +
                    "Database=botanapoly_master;User ID=pruebas ;" +
                    "Password=pruebas;Encrypt=True;" +
                    "TrustServerCertificate=True;Connection Timeout=30;");
            }
            public System.Data.DataTable selectQuery(string query)
            {
                using (var command = new QC.SqlCommand())
                {
                    command.Connection = this.connection;
                    command.CommandType = DT.CommandType.Text;
                    command.CommandText = query;

                    command.Connection.Open();
                    QC.SqlDataReader reader = command.ExecuteReader();
                    System.Data.DataTable dt = new();

                    dt.Load(reader);
                    command.Connection.Close();
                    return dt;
                }
            }

            public string insertQuery(string query)
            {
                using (var command = new QC.SqlCommand())
                {
                    command.Connection = this.connection;
                    command.CommandType = DT.CommandType.Text;
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

        }
}
