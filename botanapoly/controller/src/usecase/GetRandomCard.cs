using database;
using model;

namespace controller{
    public class GetRandomCard : IUseCaseFunctionality<int>{
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public GetRandomCard(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public int execute()
        {
            return _matchRepository.getRandomCard(_playerInfo.Id);
        }
    }
}