using database;
using database.model.codes;
using model;

namespace controller{
    public class PayDebt : IUseCaseFunctionality<PayDebtCode>{
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public PayDebt(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public PayDebtCode execute()
        {
            return _matchRepository.payDebt(_playerInfo.Id);
        }
    }
}