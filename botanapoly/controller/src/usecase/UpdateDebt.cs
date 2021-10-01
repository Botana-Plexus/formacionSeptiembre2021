using System;
using database;
using model;

namespace controller{
    public class UpdateDebt : IUseCaseFunctionality<int>{

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly CardInfo _cardInfo;

        public UpdateDebt(IMatchRepository matchRepository, PlayerInfo playerInfo, CardInfo cardInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _cardInfo = cardInfo;
        }

        public int execute()
        {
            _matchRepository.updateDebt(_playerInfo, _cardInfo);
            return 0;
        }
    }
}