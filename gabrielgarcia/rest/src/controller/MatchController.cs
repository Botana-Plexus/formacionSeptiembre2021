using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using rest.service;

namespace rest{
    [ApiController]
    [Route("/api/match/")]
    public class MatchController : ControllerBase{
        [HttpGet]
        public IEnumerable<MatchInfo> getMatches()
        {
            return Configuration.Instance.MatchRepository.getMatches(match => true);
        }

        [HttpGet]
        [Route("{matchId}/")]
        [MatchValidation]
        public MatchInfo getMatch([FromRoute] int matchId)
        {
            return Configuration.Instance.MatchRepository.getMatches(match => match.Id.Equals(matchId)).First();
        }

        [HttpPost]
        public ObjectResult createMatch([FromHeader] string apiKey, [FromBody] MatchInfoDto config)
        {
            IEnumerable<BoardInfo> boards;
            IEnumerable<MatchInfo> matches;
            int? userId;
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            userId = apiKeyStore.find(apiKey);
            boards = repository.getBoards(e => e.Id.Equals(config.BoardId));
            if (boards.Any())
            {
                repository.createMatch(config.Name, userId.Value, config.MaxPlayers, config.MaxDuration, config.Password, boards.First().Id);
                int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
                matches = repository.getMatches(match => match.HostId.Equals(playerId));
                if (matches.Any()) return Ok(matches.OrderByDescending(match => match.Id).First());
            }

            return Problem("error creating match", "", 404);
        }

        [HttpGet]
        [Route("{matchId}/start/")]
        [MatchValidation]
        //[UserHostsMatchValidation]
        public ObjectResult startMatch([FromRoute] int matchId)
        {
            var repository = Configuration.Instance.MatchRepository;
            repository.startMatch(matchId);
            return Ok(repository.getMatches(match => match.Id.Equals(matchId)).First());
        }

        [HttpGet]
        [Route("{matchId}/stop/")]
        [MatchValidation]
        //[UserHostsMatchValidation]
        public ObjectResult stopMatch([FromRoute] int matchId)
        {
            var repository = Configuration.Instance.MatchRepository;
            repository.endMatch(matchId);
            return Ok(repository.getMatches(match => match.Id.Equals(matchId)).First());
        }

        [HttpPost]
        [Route("{matchId}/join/")]
        [MatchValidation]
        [UserNotInMatchValidation]
        public ObjectResult joinMatch([FromHeader] string apiKey, [FromBody] UserJoinDto configuration)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            repository.joinMatch(configuration.matchId, apiKeyStore.find(apiKey).Value, configuration.password);
            return Ok(repository.getMatches(match => match.Id.Equals(configuration.matchId)).First());
        }

        [HttpGet]
        [Route("{matchId}/end_turn/")]
        [MatchValidation]
        [UserInMatchValidation]
        [TurnValidation]
        public ObjectResult endTurn([FromHeader] string apiKey, [FromRoute] int matchId)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
            repository.endTurn(playerId);
            return Ok(repository.getMatches(match => match.Id.Equals(matchId)).First());
        }

        [HttpPost]
        [Route("leave_game")]
        [MatchValidation]
        [UserInMatchValidation]
        public ObjectResult leaveGame([FromHeader] string apiKey, [FromRoute] int matchId, [FromBody] bool watch)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
            repository.leaveMatch(playerId);
            return Ok(repository.getMatches(match => match.Id.Equals(matchId)).First());
        }
    }
}