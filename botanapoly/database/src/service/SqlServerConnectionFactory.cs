using System;
using System.Data.SqlClient;

namespace database{
    public class SqlServerConnectionFactory : IConnectionFactory {
        private readonly string _server;
        private readonly string _database;
        private readonly string _username;
        private readonly string _password;

        public SqlServerConnectionFactory(string server, string database, string username, string password)
        {
            this._server = server;
            this._database = database;
            this._username = username;
            this._password = password;
        }

        public SqlConnection get()
        {
            SqlConnection connection = new SqlConnection(
                String.Format(
                    "Server={0};Database={1};User ID={2};Password={3};Encrypt=True;TrustServerCertificate=true;Connection Timeout=30;",
                    _server,
                    _database,
                    _username,
                    _password
                ));
            connection.Open();
            return connection;
        }

        public string Server => _server;

        public string Database => _database;

        public string Username => _username;

        public string Password => _password;
    }
}