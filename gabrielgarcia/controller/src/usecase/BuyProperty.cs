using database;
using database.model.codes;
using model;

namespace controller{
    public class BuyProperty : IUseCaseFunctionality<BuyPropertyCode>{
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public BuyProperty(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public BuyPropertyCode execute()
        {
            return _matchRepository.buyProperty(_playerInfo.Id);
        }
    }
}