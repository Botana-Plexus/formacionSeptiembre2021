using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using model;

namespace rest{
    [ApiController]
    [Route("/api/match/")]
    public class MatchController : ControllerBase {
        
        [HttpGet]
        public List<MatchInfo> getMatches([FromHeader] string apiKey)
        {
            return Configuration.Instance.MatchRepository.getMatches(match => true);
        }
        
        [HttpGet]
        [Route("{matchId}/")]
        [MatchValidation]
        public MatchInfo getMatch([FromHeader] string apiKey, [FromRoute] int matchId)
        {
            return Configuration._instance.MatchRepository.getMatches(match => match.Id.Equals(matchId)).First();
        }

        [HttpPost]
        public MatchInfo createMatch([FromHeader] string apiKey, [FromBody] MatchInfoDto configuration)
        {
            return null;
        }
        
        [HttpGet]
        [Route("{matchId}/start/")]
        [MatchValidation]
        public MatchInfo startMatch([FromHeader] string apiKey, [FromRoute] int matchId)
        {
            return null;
        }
        
        [HttpGet]
        [Route("{matchId}/stop/")]
        [MatchValidation]
        public MatchInfo stopMatch([FromHeader] string apiKey, [FromRoute] int matchId)
        {
            return null;
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