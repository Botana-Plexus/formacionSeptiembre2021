using System;
using database;
using Microsoft.AspNetCore.Mvc;
using model;
using rest.service;

namespace rest{
    [ApiController]
    [Route("/api/user/")]
    public class UserController : ControllerBase{
        [HttpPost]
        public ObjectResult createUser([FromBody] CreateUserDto configuration)
        {
            return Ok(Configuration.Instance.MatchRepository.registerUser(new UserInfo(
                -1, 
                configuration.email,
                configuration.username,
                configuration.password,
                configuration.birthDate
            )));
        }

        [HttpPost]
        [Route("auth/")]
        public ObjectResult authenticateUser([FromBody] UserAndPasswordDto login)
        {
            IApiKeyStore apiKeyStore = Configuration.Instance.ApiKeyStore;
            IMatchRepository repository = Configuration.Instance.MatchRepository;
            int? userId = repository.authenticate(login.Username, login.Password);
            if (userId.HasValue)
            {
                string apiKey = String.Format("asda1sda{0}sd", userId.Value);
                apiKeyStore.register(apiKey, userId.Value);
                return Ok(apiKey);
            }

            return Problem("login details are not valid", "", 404);
        }
    }
}