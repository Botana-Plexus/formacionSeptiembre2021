using System;
using System.Collections.Generic;
using controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using model;

namespace rest {
    [ApiController]
    [Route("/api/match/{matchId}/execute/")]
    [MatchValidation]
    [UserInMatchValidation]
    [TurnValidation]
    [PlayerIsPenalizedValidation]
    public class MatchActionController : ControllerBase {

        [HttpPost]
        [Route("roll")]
        public int[] roll([FromRoute] int matchId, [FromHeader] string apiKey)
        {
            return new []{new Random().Next(1,7), new Random().Next(1,7)};
        }
        
        [HttpPost]
        [Route("move")]
        public MatchInfo move([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] int amount)
        {
            return null;
        }

        [HttpPost]
        [Route("edificate")]
        public MatchInfo edificate([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] EdificateRequestDto dto)
        {
            return null;
        }
        
        [HttpPost]
        [Route("request_card")]
        public MatchInfo requestCard([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] CardSetType cardSetType)
        {
            return null;
        }
        
        [HttpPost]
        [Route("execute_card")]
        public MatchInfo executeCard([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] int cardId)
        {
            return null;
        }
        
        [HttpPost]
        [Route("buy_property")]
        public MatchInfo buyProperty([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] int propertyId)
        {
            return null;
        }
        
        [HttpPost]
        [Route("sell_property")]
        public MatchInfo sellProperty([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] int propertyId)
        {
            return null;
        }
        
        [HttpPost]
        [Route("pay_rent")]
        public MatchInfo payRent([FromRoute] int matchId, [FromHeader] string apiKey)
        {
            return null;
        }
    }
}