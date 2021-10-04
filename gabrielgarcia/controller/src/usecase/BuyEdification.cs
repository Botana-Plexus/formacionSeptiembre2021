using database;
using database.model.codes;
using model;

namespace controller{
    public class BuyEdification : IUseCaseFunctionality<BuyEdificationCode>{
        
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly SquareInfo _squareInfo;

        public BuyEdification(IMatchRepository matchRepository, PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _squareInfo = squareInfo;
        }

        public BuyEdificationCode execute()
        {
            return _matchRepository.addEdification(_playerInfo.Id, _squareInfo.Id);
        }
    }
}