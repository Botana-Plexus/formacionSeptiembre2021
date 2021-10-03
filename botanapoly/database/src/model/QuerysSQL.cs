using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace database.model{
    public class QuerysSQL {

        private readonly SqlConnection _connection;

        public QuerysSQL(SqlConnection connection)
        {
            _connection = connection;
        }

        public int executeStoredProcedureINT(string sql)
        {
            int resultado = 1;

            SqlCommand cmd = new(sql, _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                resultado = reader.GetInt32(0);
            }

            _connection.Close();

            return resultado;
        }

        public void executeStoredProcedure(string sql)
        {
            SqlCommand cmd = new(sql, _connection);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            _connection.Close();
        }

        public List<object[]> executeStoredProcedureReader(string sql)
        {
            List<object[]> resultado = new();

            SqlCommand cmd = new(sql, _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                reader.GetValues(values);

                resultado.Add(values);
            }

            _connection.Close();

            return resultado;
        }
    }
}