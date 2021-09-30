using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using model;

namespace rest{
    [ApiController]
    [Route("/api/match/")]
    public class MatchController : ControllerBase {
        
        [HttpGet]
        public List<MatchInfo> getMatches([FromHeader] string apiKey)
        {
            return null;
        }
        
        [HttpGet]
        [Route("{matchId}/")]
        public MatchInfo getMatch([FromHeader] string apiKey, [FromRoute] int matchId)
        {
            return null;
        }

        [HttpPost]
        public MatchInfo createMatch([FromHeader] string apiKey, [FromBody] MatchInfoDto configuration)
        {
            return null;
        }
        
        [HttpGet]
        [Route("{matchId}/start/")]
        public MatchInfo startMatch([FromHeader] string apiKey, [FromRoute] int matchId)
        {
            return null;
        }
        
        [HttpGet]
        [Route("{matchId}/stop/")]
        public MatchInfo stopMatch([FromHeader] string apiKey, [FromRoute] int matchId)
        {
            return null;
        }
        
        [HttpPost]
        [Route("{matchId}/join/")]
        public MatchInfo joinMatch([FromHeader] string apiKey, [FromBody] UserJoinDto configuration)
        {
            return null;
        }
        
        [HttpGet]
        [Route("{matchId}/end_turn/")]
        public MatchInfo endTurn([FromHeader] string apiKey, [FromRoute] int matchId)
        {
            return null;
        }
        
        [HttpPost]
        [Route("leave_game")]
        public MatchInfo leaveGame([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] bool watch)
        {
            return null;
        }
    }
}