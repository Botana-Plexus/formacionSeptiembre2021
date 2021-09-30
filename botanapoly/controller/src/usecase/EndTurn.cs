using database;
using model;

namespace controller {
    public class EndTurn : IUseCaseFunctionality<MatchInfo>{
        
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public EndTurn(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public MatchInfo execute()
        {
            return this._matchRepository.endTurn(this._playerInfo);
        }
    }
}