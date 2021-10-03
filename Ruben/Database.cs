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
                "Database=botanapoly;User ID=pruebas;" +
                "Password=pruebas;Encrypt=False;" +
                "TrustServerCertificate=True;Connection Timeout=30;");
        }

        public string ejecutarConsultaInsert(string consulta)
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

