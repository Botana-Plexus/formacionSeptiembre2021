using System;
using database;
using model;

namespace controller {
    public class ModifyEdificationLevel{
        
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly SquareInfo _squareInfo;
        private readonly TurnAction _action;

        public ModifyEdificationLevel(IMatchRepository matchRepository, PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _squareInfo = squareInfo;
        }

        public int execute()
        {
            switch (_action)
            {
                case TurnAction.INCREASE_EDIFICATION_LEVEL:
                    return _matchRepository.addEdification(_playerInfo, _squareInfo);
                case TurnAction.DECREASE_EDIFICATION_LEVEL:
                    return _matchRepository.removeEdification(_playerInfo, _squareInfo);
                default:
                    throw new Exception("Action not supported");
            }
        }
        
    }
}