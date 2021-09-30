using database;
using model;

namespace controller{
    public class ManageProperty : IUseCaseFunctionality<MatchInfo>{

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly SquareInfo _squareInfo;
        private readonly bool buy;

        public ManageProperty(IMatchRepository matchRepository, PlayerInfo playerInfo, SquareInfo squareInfo, bool buy)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _squareInfo = squareInfo;
            this.buy = buy;
        }

        public MatchInfo execute()
        {
            return _matchRepository.manageProperty(_playerInfo, _squareInfo, buy);
        }
    }
}