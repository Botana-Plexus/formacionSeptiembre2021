using System;
using database;
using model;

namespace controller{
    public class UpdateDebt : IUseCaseFunctionality<int>{
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly CardInfo _cardInfo;
        private readonly int _multiplier;

        public UpdateDebt(IMatchRepository matchRepository, PlayerInfo playerInfo, CardInfo cardInfo, int multiplier)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _cardInfo = cardInfo;
            _multiplier = multiplier;
        }

        public int execute()
        {
            _matchRepository.updateDebt(_playerInfo.Id, _cardInfo.Id, _multiplier);
            return 0;
        }
    }
}