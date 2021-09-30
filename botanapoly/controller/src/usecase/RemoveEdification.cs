using database;
using model;

namespace controller{
    public class RemoveEdification : IUseCaseFunctionality<MatchInfo> {
        
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly SquareInfo _squareInfo;


        public RemoveEdification(IMatchRepository matchRepository, PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _squareInfo = squareInfo;
        }

        public MatchInfo execute()
        {
            return _matchRepository.removeEdification(_playerInfo, _squareInfo);
        }
        
    }
}