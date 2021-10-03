using System.Data.SqlClient;

namespace database{
    public interface IConnectionFactory{
        SqlConnection get();
    }
}