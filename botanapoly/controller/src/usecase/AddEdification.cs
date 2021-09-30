using database;
using model;

namespace controller{
    public class AddEdification : IUseCaseFunctionality<MatchInfo>{

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly SquareInfo _squareInfo;


        public AddEdification(IMatchRepository matchRepository, PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _squareInfo = squareInfo;
        }

        public MatchInfo execute()
        {
            return _matchRepository.addEdification(_playerInfo, _squareInfo);
        }
    }
}