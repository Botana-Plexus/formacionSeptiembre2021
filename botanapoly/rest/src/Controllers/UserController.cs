using Microsoft.AspNetCore.Mvc;
using model;

namespace rest {
    [ApiController]
    [Route("/api/user/")]
    public class UserController : ControllerBase {

        [HttpPost]
        public UserInfo createUser([FromBody] CreateUserDto configuration)
        {
            return null;
        }
        
        [HttpPost]
        [Route("auth/")]
        public string authenticateUser([FromBody] string userHash)
        {
            return null; //apiKey
        }
        
    }
}