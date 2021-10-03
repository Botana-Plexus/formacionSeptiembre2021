using database;
using database.model.codes;
using model;

namespace controller{
    public class SellProperty : IUseCaseFunctionality<SellPropertyCode>{
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly SquareInfo _squareInfo;

        public SellProperty(IMatchRepository matchRepository, PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _squareInfo = squareInfo;
        }

        public SellPropertyCode execute()
        {
            return _matchRepository.sellProperty(_playerInfo.Id, _squareInfo.Id);
        }
    }
}