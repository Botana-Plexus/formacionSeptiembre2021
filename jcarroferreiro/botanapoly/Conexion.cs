using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;

namespace ProofOfConcept_SQL_CSharp
{
    public class Conexion
    {

        QC.SqlConnection connection;
        public Conexion()
        {
            /*
                Inicializa automaticamente la conexion, sería ideal establecer la conexion con variables 
            para que así el archivo sea exportable, es decir, los valores que sean recojidos.
             */
            connection = new QC.SqlConnection(
               "Server=localhost;" +
               "Database=botanapoly;User ID=jose.carroferreiro;" +
               "Password=JmCf140293;Encrypt=True;" +
               "TrustServerCertificate=True;Connection Timeout=30;"
               );
            connection.Open();
        }
        public DataTable consultas(string consultaSQL)
        {
            DataTable dt = new DataTable();

            using (SqlCommand command = new SqlCommand(consultaSQL, connection))
            {
                //SqlDataReader reader = command.ExecuteReader();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dt.Load(dr);
                }
            }
            return dt;
        }

    }
}
