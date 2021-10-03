using SQLclient = Microsoft.Data.SqlClient;

namespace Botanapoly.Models
{
    public class ConexionSQL
    {
        public SQLclient.SqlConnection connection;
        private const string config = "Server=localhost;Database=botanapoly;User ID=pruebas;Password=pruebas;Encrypt=True;TrustServerCertificate=true;Connection Timeout=30;";
        public SQLclient.SqlConnection abrirConexion()
        {
            connection = new SQLclient.SqlConnection(config);
            connection.Open();

            return connection;
        }
    }
}
