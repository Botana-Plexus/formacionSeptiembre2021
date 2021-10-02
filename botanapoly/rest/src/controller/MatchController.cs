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
    public class MatchController : ControllerBase {
        
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
            UserInfo user;
            IApiKeyStore apiKeyStore = Configuration.Instance.ApiKeyStore;
            IMatchRepository repository = Configuration.Instance.MatchRepository;
            user = apiKeyStore.find(apiKey);
            boards = repository.getBoards(e => e.Id.Equals(config.BoardId));
            if (boards.Any())
            {
                repository.createMatch(config.Name, user.Id, config.MaxPlayers, config.MaxDuration, config.Password, boards.First().Id);
                matches = repository.getMatches(match => match.HostId.Equals(user.Id));
                if (matches.Any())
                {
                    return Ok(matches.OrderByDescending(match => match.Id).First());
                }
            }
            return Problem("error creating match", "", 404);
        }
        
        [HttpGet]
        [Route("{matchId}/start/")]
        [MatchValidation]
        [UserHostsMatchValidation]
        public ObjectResult startMatch([FromRoute] int matchId)
        {
            IMatchRepository repository = Configuration.Instance.MatchRepository;
            repository.startMatch(matchId);
            return Ok(repository.getMatches(match => match.Id.Equals(matchId)).First());
        }
        
        [HttpGet]
        [Route("{matchId}/stop/")]
        [MatchValidation]
        [UserHostsMatchValidation]
        public ObjectResult stopMatch([FromRoute] int matchId)
        {
            IMatchRepository repository = Configuration.Instance.MatchRepository;
            repository.endMatch(matchId);
            return Ok(repository.getMatches(match => match.Id.Equals(matchId)).First());
        }
        
        [HttpPost]
        [Route("{matchId}/join/")]
        [MatchValidation]
        public MatchInfo joinMatch([FromHeader] string apiKey, [FromBody] UserJoinDto configuration)
        {
            return null;
        }
        
        [HttpGet]
        [Route("{matchId}/end_turn/")]
        [MatchValidation]
        public MatchInfo endTurn([FromHeader] string apiKey, [FromRoute] int matchId)
        {
            return null;
        }
        
        [HttpPost]
        [Route("leave_game")]
        [MatchValidation]
        public MatchInfo leaveGame([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] bool watch)
        {
            return null;
        }
    }
}