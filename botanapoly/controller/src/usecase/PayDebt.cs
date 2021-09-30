using database;
using model;

namespace controller{
    public class PayDebt : IUseCaseFunctionality<MatchInfo>{

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public PayDebt(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public MatchInfo execute()
        {
            return _matchRepository.payDebt(_playerInfo);
        }
    }
}