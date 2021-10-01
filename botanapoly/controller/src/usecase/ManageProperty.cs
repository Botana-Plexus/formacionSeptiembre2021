using database;
using model;

namespace controller{
    public class ManageProperty : IUseCaseFunctionality<int>{

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

        public int execute()
        {
            return buy
                ? _matchRepository.buyProperty(_playerInfo, _squareInfo)
                : _matchRepository.sellProperty(_playerInfo, _squareInfo);
        }
    }
}