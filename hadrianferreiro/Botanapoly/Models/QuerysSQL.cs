using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using SQLclient = Microsoft.Data.SqlClient;
using SysData = System.Data;

namespace Botanapoly.Models
{
    public class QuerysSQL
    {
        ConexionSQL con = new ConexionSQL();

        public int executeStoredProcedureINT(string sql)
        {
            int resultado = 1;

            con.abrirConexion();

            SqlCommand cmd = new(sql, con.connection);

            SQLclient.SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                resultado = reader.GetInt32(0);
            }

            con.connection.Close();

            return resultado;
        }

        public void executeStoredProcedure(string sql)
        {
            con.abrirConexion();

            SqlCommand cmd = new(sql, con.connection);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.connection.Close();
        }

        public List<object[]> executeStoredProcedureReader(string sql)
        {
            List<object[]> resultado = new();

            con.abrirConexion();

            SqlCommand cmd = new(sql, con.connection);

            SQLclient.SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                reader.GetValues(values);

                resultado.Add(values);
            }

            con.connection.Close();

            return resultado;
        }
    }
}
