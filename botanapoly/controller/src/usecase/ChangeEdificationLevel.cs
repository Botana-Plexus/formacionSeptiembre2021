using System;
using System.Collections.Generic;
using System.Linq;
using database;
using model;
using util;

namespace controller{
    public class ChangeEdificationLevel : IUseCaseFunctionality<SquareInfo>{
        private readonly IPlayerRepository playerRepository;
        private readonly IMatchRepository matchRepository;
        private readonly List<IStateCommand<EdificationLevel, EdificationLevelAction>> commands;

        private readonly PlayerInfo playerInfo;
        private readonly MatchInfo matchInfo;
        private readonly SquareInfo squareInfo;
        private readonly EdificationLevelAction action;

        public ChangeEdificationLevel(IPlayerRepository playerRepository, IMatchRepository matchRepository, List<IStateCommand<EdificationLevel, EdificationLevelAction>> commands, PlayerInfo playerInfo, MatchInfo matchInfo, SquareInfo squareInfo, EdificationLevelAction action)
        {
            this.playerRepository = playerRepository;
            this.matchRepository = matchRepository;
            this.commands = commands;
            this.playerInfo = playerInfo;
            this.matchInfo = matchInfo;
            this.squareInfo = squareInfo;
            this.action = action;
        }

        public SquareInfo execute()
        {
            BoardInfo boardInfo;
            SquareInfo square;
            PlayerInfo playerInfo;
            List<SquareInfo> squares;
            CollectionInfo collection;
            IStateCommand<EdificationLevel, EdificationLevelAction> command = null;

            if (!playerRepository.exists(this.playerInfo) ||
                !matchRepository.exists(matchInfo) ||
                !matchRepository.existsSquare(matchInfo.getId(), squareInfo)
            ) {
                throw new NullReferenceException();
            }

            /*if (squareInfo.concepts.ContainsKey(PropertyConcept.INCREASE_EDIFICATION_LEVEL) && this.playerInfo.balance >= squareInfo.concepts[PropertyConcept.INCREASE_EDIFICATION_LEVEL].value)
            {
                square = this.modifyEdificationlevel(this.squareInfo, this.action);
                // TODO: update square info in board info
                // TODO: reduce player's balance
            }
            else if (squareInfo.concepts.ContainsKey(PropertyConcept.DECREASE_EDIFICATION_LEVEL))
            {
                square = this.modifyEdificationlevel(this.squareInfo, this.action);
                // TODO: update square info in board info
                // TODO: increase player's balance
            }*/
            
            return null;
        }

        private SquareInfo modifyEdificationlevel(SquareInfo squareInfo, EdificationLevelAction action)
        {
            var square = squareInfo.DeepClone();
            switch (action)
            {
                case EdificationLevelAction.BUILD:
                    squareInfo.edificationLevel += 1;
                    break;
                case EdificationLevelAction.DESTROY:
                    squareInfo.edificationLevel -= 1;
                    break;
                default:
                    square = null;
                    break;
            }

            return square;
        }
    }
}