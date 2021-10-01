using database;
using model;

namespace controller{
    public class GetTurnInfo : IUseCaseFunctionality<int>{

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public GetTurnInfo(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public int execute()
        {
            return _matchRepository.getTurnInfo(_playerInfo);
        }
    }
}