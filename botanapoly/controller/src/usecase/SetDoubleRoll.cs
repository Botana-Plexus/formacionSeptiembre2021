using database;
using model;

namespace controller{
    public class SetDoubleRoll : IUseCaseFunctionality<int>{
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly bool _reset;

        public SetDoubleRoll(IMatchRepository matchRepository, PlayerInfo playerInfo, bool reset)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _reset = reset;
        }

        public int execute()
        {
            _matchRepository.setDoubleRoll(_playerInfo.Id, _reset);
            return 0;
        }
    }
}