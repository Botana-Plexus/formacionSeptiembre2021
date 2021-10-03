using database;
using model;

namespace controller{
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
            _matchRepository.endTurn(_playerInfo.Id);
            return 0;
        }
    }
}