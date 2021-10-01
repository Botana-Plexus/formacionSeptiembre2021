using System;
using database;
using model;

namespace controller{
    public class GetPlayerProperties : IUseCaseFunctionality<object>{

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly Func<PlayerInfo, bool> _filter;

        public GetPlayerProperties(IMatchRepository matchRepository, PlayerInfo playerInfo, Func<PlayerInfo, bool> filter)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _filter = filter;
        }

        public object execute()
        {
            return _matchRepository.getPlayerProperties(_playerInfo, _filter);
        }
    }
}