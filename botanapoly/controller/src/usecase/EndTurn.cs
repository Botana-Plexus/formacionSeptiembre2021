using database;
using model;

namespace controller {
    public class EndTurn : IUseCaseFunctionality<int>{
        
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public EndTurn(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public int execute()
        {
            this._matchRepository.endTurn(this._playerInfo);
            return 0;
        }
    }
}