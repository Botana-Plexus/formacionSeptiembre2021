using System;
using System.Collections.Generic;
using System.Data;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;


namespace BotanaPolyAPI
{
    class BaseDatos
    {
        private string server;
        private string usuario;
        private string password;
        private string database;
        public QC.SqlConnection connection;

        public BaseDatos(string server, string database, string usuario, string password)
        {
            this.server = server;
            this.database = database;
            this.usuario = usuario;
            this.password = password;
        }



        public void conectar()
        {
            connection = new QC.SqlConnection(
               "Server=" + server + ";" +
               "Database=" + database + ";User ID=" + usuario + ";" +
               "Password=" + password + ";Encrypt=True;" +
               "TrustServerCertificate=true;Connection Timeout=30;");

            connection.Open();
        }

        public void cerrarConexion()
        {
            connection.Close();
        }

        public int insertDatos(String comando)
        {
            conectar();
            QC.SqlCommand command;
            using (command = new QC.SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = DT.CommandType.Text;
                command.CommandText = comando;
            }
            int result = command.ExecuteNonQuery();
            cerrarConexion();
            return result;
            
        }

        public List<object[]> ejecutarConsulta(string comando)
        {
            conectar();
            List<object[]> objeto = new List<object[]>();

            using (var command = new QC.SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = DT.CommandType.Text;
                command.CommandText = comando;

                //Coger el contenido del reader y meterlo en un array
                QC.SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);

                    objeto.Add(values);
                }
            }
            cerrarConexion();
            return objeto;
            
        }
    }
}
