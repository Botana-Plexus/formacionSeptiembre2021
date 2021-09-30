using database;
using model;

namespace controller{
    public class PunishPlayer : IUseCaseFunctionality<MatchInfo> {

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public PunishPlayer(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public MatchInfo execute()
        {
            return _matchRepository.punishPlayer(_playerInfo);
        }
    }
}