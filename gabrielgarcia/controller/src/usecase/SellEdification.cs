using database;
using database.model.codes;
using model;

namespace controller{
    public class SellEdification : IUseCaseFunctionality<SellEdificationCode>{
        
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly SquareInfo _squareInfo;

        public SellEdification(IMatchRepository matchRepository, PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _squareInfo = squareInfo;
        }

        public SellEdificationCode execute()
        {
            return _matchRepository.removeEdification(_playerInfo.Id, _squareInfo.Id);
        }
    }
}