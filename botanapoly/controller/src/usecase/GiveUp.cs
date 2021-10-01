using database;
using model;

namespace controller{
    public class GiveUp : IUseCaseFunctionality<int>{

        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly bool _watch;

        public GiveUp(IMatchRepository matchRepository, PlayerInfo playerInfo, bool watch)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _watch = watch;
        }

        public int execute()
        {
            if (_watch)
            {
                this._matchRepository.switchToObserver(_playerInfo);
            }
            else
            {
                this._matchRepository.leaveMatch(_playerInfo);
            }
            return 0;
        }
    }
}