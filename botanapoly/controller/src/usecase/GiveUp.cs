using database;
using model;

namespace controller{
    public class GiveUp : IUseCaseFunctionality<MatchInfo>{

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly bool _watch;

        public GiveUp(IMatchRepository matchRepository, PlayerInfo playerInfo, bool watch)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _watch = watch;
        }

        public MatchInfo execute()
        {
            return this._matchRepository.leaveMatch(_playerInfo, _watch);
        }
    }
}