using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace database.model{
    public class QuerysSQL{
        private readonly SqlConnection _connection;

        public QuerysSQL(SqlConnection connection)
        {
            _connection = connection;
        }

        public int executeStoredProcedureINT(string sql)
        {
            var resultado = 1;

            SqlCommand cmd = new(sql, _connection);

            var reader = cmd.ExecuteReader();

            while (reader.Read()) resultado = reader.GetInt32(0);

            return resultado;
        }

        public void executeStoredProcedure(string sql)
        {
            SqlCommand cmd = new(sql, _connection);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            
        }

        public List<object[]> executeStoredProcedureReader(string sql)
        {
            List<object[]> resultado = new();

            SqlCommand cmd = new(sql, _connection);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var values = new object[reader.FieldCount];
                reader.GetValues(values);

                resultado.Add(values);
            }

            return resultado;
        }

        public void close()
        {
            this._connection.Close();
        }
    }
}