using System;
using System.Collections.Generic;
using System.Linq;
using controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using model;

namespace rest{
    [ApiController]
    [Route("/api/match/{matchId}/execute/")]
    [MatchValidation]
    [UserInMatchValidation]
    [TurnValidation]
    [PlayerIsNotPenalizedValidation]
    public class MatchActionController : ControllerBase{
        [HttpPost]
        [Route("roll")]
        public ObjectResult roll([FromRoute] int matchId, [FromHeader] string apiKey)
        {
            return Ok(new[] {new Random().Next(1, 7), new Random().Next(1, 7)});
        }

        [HttpPost]
        [Route("move")]
        // No need to do this much, frontend can handle the logic
        public ObjectResult move([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] int amount)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
            int squareId = repository.movePlayer(playerId, amount);
            SquareInfo square = repository.getMatchSquares(null, square => square.Id.Equals(squareId)).First();
            /*switch (square.SquareType)
            {
                case SquareType.PROPERTY:
                case SquareType.COMPANY:
                case SquareType.INFRASTRUCTURE:
                case SquareType.PAYMENT:
                    repository.updateDebt(playerId, null, amount);
                    break;
                case SquareType.CARD:
                    int cardId = repository.getRandomCard(playerId);
                    CardInfo card = repository.getCardInfo(cardId);
                    switch (card.Type)
                    {
                        case CardType.BALANCE_DECREASE:
                            repository.updateDebt(playerId, cardId, 0);
                            break;
                        case CardType.MOVEMENT:
                            repository.movePlayer(playerId, card.Value);
                            break;
                    }
                    break;
                case SquareType.PUNISHMENT:
                    repository.punishPlayer(playerId);
                    break;
            }*/
            return Ok(repository.getMatches(match => match.Id.Equals(matchId)).First());
        }

        [HttpPost]
        [Route("edificate")]
        //TODO: validate user owns the property and all those from the property collection
        public ObjectResult edificate([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] int squareId)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
            return Ok(repository.addEdification(playerId, squareId));
        }

        [HttpPost]
        [Route("request_card")]
        public ObjectResult requestCard([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] CardSetType cardSetType)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
            return Ok(repository.getRandomCard(playerId));
        }

        [HttpPost]
        [Route("execute_card")]
        public ObjectResult executeCard([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] int cardId)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
            CardInfo card = repository.getCardInfo(cardId);
            switch (card.Type)
            {
                case CardType.BALANCE_DECREASE:
                    repository.updateDebt(playerId, cardId, 0);
                    break;
                case CardType.MOVEMENT:
                    repository.movePlayer(playerId, card.Value);
                    break;
            }
            return Ok(repository.getMatches(match => match.Id.Equals(matchId)).First());
        }

        [HttpPost]
        [Route("buy_property")]
        //TODO: validate user is in property's square
        public ObjectResult buyProperty([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] int propertyId)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
            return Ok(repository.buyProperty(playerId));
        }

        [HttpPost]
        [Route("sell_property")]
        //TODO: check if player owns square
        public ObjectResult sellProperty([FromRoute] int matchId, [FromHeader] string apiKey, [FromBody] int squareId)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
            return Ok(repository.sellProperty(playerId, squareId));
        }

        [HttpPost]
        [Route("pay_rent")]
        public ObjectResult payRent([FromRoute] int matchId, [FromHeader] string apiKey)
        {
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var repository = Configuration.Instance.MatchRepository;
            int playerId = repository.getFromUser(apiKeyStore.find(apiKey).Value).Id;
            repository.payDebt(playerId);
            return Ok(repository.getMatches(match => match.Id.Equals(matchId)).First());
        }
    }
}