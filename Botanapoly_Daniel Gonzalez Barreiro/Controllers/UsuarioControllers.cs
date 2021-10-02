using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Botanapoly.Controllers
{
    [Route("")]
    [ApiController]
    
    public class UsuarioControllers : ControllerBase
    {
        Database database = new Database();
        // POST /register
        [HttpPost("register")]
        public string addUser([FromBody] Usuario usuario)
        {
            string query = $"registrar'{usuario.email}','{usuario.nick}','{usuario.pass}','{usuario.fechaNacimiento}'";

            return database.insertQuery(query);

        }

        // POST /users
        [HttpPost("login")]
        public string loginUser([FromBody] Usuario usuario)
        {

            string query = $"autenticar'{usuario.email}','{usuario.pass}'";

            System.Data.DataTable tempTable = database.selectQuery(query);

            return tempTable.Rows[0]["Column2"].ToString();

        }
        //// GET: /user/id>
        //[HttpGet("user" +
        //    "/{id}")]
        //public List<Usuario> GetUserById(int id)
        //{
        //    database.openDbConnection();
        //    using (var command = new QC.SqlCommand())
        //    {
        //        command.Connection = Database.connection;
        //        command.CommandType = DT.CommandType.Text;

        //        command.CommandText = @"SELECT * FROM users WHERE id = @id";
        //        command.Parameters.AddWithValue("@id", @id);

        //        QC.SqlDataReader reader = command.ExecuteReader();
        //        var list = new List<Usuario>();
        //        while (reader.Read())
        //            list.Add(new Usuario(
        //            reader.GetInt32(0),
        //            reader.GetString(1),
        //            reader.GetString(2),
        //            reader.GetString(3),
        //            reader.GetDateTime(4)
        //            ));
        //        database.closeDbConnection();

        //        return list;

        //    }
        //}

        //// GET: /users>
        //[HttpGet("users")]
        //public List<Usuario> GetUsers()
        //{
        //    database.openDbConnection();
        //    using (var command = new QC.SqlCommand())
        //    {
        //        command.Connection = Database.connection;
        //        command.CommandType = DT.CommandType.Text;

        //        command.CommandText = @"SELECT * FROM users";

        //        QC.SqlDataReader reader = command.ExecuteReader();
        //        var list = new List<Usuario>();
        //        while (reader.Read())
        //            list.Add(new Usuario(
        //            reader.GetInt32(0),
        //            reader.GetString(1),
        //            reader.GetString(2),
        //            reader.GetString(3),
        //            reader.GetDateTime(4)
        //            ));
        //        database.closeDbConnection();

        //        return list;

        //    }
        //}

    }   

}


