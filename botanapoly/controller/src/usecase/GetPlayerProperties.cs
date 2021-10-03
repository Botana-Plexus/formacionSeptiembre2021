using System;
using database;
using model;

namespace controller{
    public class GetPlayerProperties : IUseCaseFunctionality<object>{
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly Func<SquareInfo, bool> _filter;

        public GetPlayerProperties(IMatchRepository matchRepository, PlayerInfo playerInfo, Func<SquareInfo, bool> filter)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _filter = filter;
        }

        public object execute()
        {
            return _matchRepository.getPlayerProperties(_playerInfo.Id, _filter);
        }
    }
}