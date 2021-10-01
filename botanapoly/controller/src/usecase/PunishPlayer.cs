using database;
using model;

namespace controller {
    public class PunishPlayer : IUseCaseFunctionality<int> {

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public PunishPlayer(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public int execute()
        {
            _matchRepository.punishPlayer(_playerInfo);
            return 0;
        }
    }
}