using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections;

namespace BotanapolyAPI.Controllers
{
    class BaseDatos
    {
        SqlConnection connection;
        string connetionString;
        public BaseDatos(string server, string database, string user, string pass)
        {
            connetionString =
                "Server=tcp:" + server + ";" +
                "Database=" + database + ";User ID=" + user + ";" +
                "Password=" + pass + ";Encrypt=True;" +
                "TrustServerCertificate=true;Connection Timeout=30;";
            connection = new SqlConnection(connetionString);
        }
        public void openConection()
        {
            connection.Open();
        }
        public void closeConection()
        {
            connection.Close();
        }
        public int generarMod(string consulta)
        {
            this.openConection();
            int filasAfectadas = 0;
            SqlCommand command = new SqlCommand(consulta, connection);
            try
            {
                filasAfectadas = command.ExecuteNonQuery();
            }
            catch (SqlException)
            {

            }
            this.closeConection();
            return filasAfectadas;
        }
        public object[][] generarConsulta(string consulta)
        {
            this.openConection();
            object[][] lista = null;
            SqlCommand command = new SqlCommand(consulta, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    if (lista == null)
                    {
                        lista = new object[1][];
                        lista[0] = new object[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            lista[0][i] = values[i];
                        }
                    }
                    else
                    {
                        object[][] temp = new object[lista.GetLength(0) + 1][];
                        for (int i = 0; i < lista.GetLength(0); i++)
                        {
                            temp[i] = new object[reader.FieldCount];
                            for (int j = 0; j < reader.FieldCount; j++)
                            {
                                temp[i][j] = lista[i][j];
                            }
                        }
                        temp[lista.GetLength(0)] = new object[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            temp[lista.GetLength(0)][i] = values[i];
                        }
                        lista = temp;
                    }
                }
            }
            this.closeConection();
            return lista;
        }
    }
}
