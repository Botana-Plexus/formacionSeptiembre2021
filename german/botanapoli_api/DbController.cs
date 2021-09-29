using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QC = Microsoft.Data.SqlClient;
using DT = System.Data;

namespace botanapoli_api
{
    public class DbController
    {
        string serverName;
        string dbName;
        string userId;
        string password;
        QC.SqlConnection connection;

        public DbController()
        {
            this.serverName = "localhost";
            this.dbName = "botanapoly";
            this.userId = "pruebas";
            this.password = "pruebas";
            this.connection = DbConnect();
        }

        public QC.SqlConnection DbConnect()
        {
            return new QC.SqlConnection(
                    $"Server=tcp:{serverName};" +
                    $"Database={dbName};User ID={userId};" +
                    $"Password={password};Encrypt=True;" +
                    "TrustServerCertificate=True;Connection Timeout=30;"
                );
        }

        public DT.DataTable DbRetrieveQuery(string query)
        {
            this.connection.Open();
            var command = new QC.SqlCommand();

            command.Connection = connection;
            command.CommandType = DT.CommandType.Text;
            command.CommandText = query;

            DT.DataTable dt = new DT.DataTable();

            QC.SqlDataReader reader = command.ExecuteReader();


            dt.Load(reader);

            this.connection.Close();
            return dt;
        }

        public int DbInsertQuery(string query)
        {
            this.connection.Open();
            var command = new QC.SqlCommand();

            command.Connection = connection;
            command.CommandType = DT.CommandType.Text;
            command.CommandText = query;

            //QC.SqlDataReader reader = command.ExecuteReader();

            int affectedRows = command.ExecuteNonQuery();
            this.connection.Close();
            return affectedRows;
        }

    }
}
