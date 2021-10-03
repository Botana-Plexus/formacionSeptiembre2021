using database;
using model;

namespace controller{
    public class MovePlayer : IUseCaseFunctionality<int>{
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;
        private readonly int _amount;

        public MovePlayer(IMatchRepository matchRepository, PlayerInfo playerInfo, int amount)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _amount = amount;
        }

        public int execute()
        {
            return _matchRepository.movePlayer(_playerInfo.Id, _amount);
        }
    }
}