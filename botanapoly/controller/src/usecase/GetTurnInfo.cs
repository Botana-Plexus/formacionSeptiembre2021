using database;
using database.model.codes;
using model;

namespace controller{
    public class GetTurnInfo : IUseCaseFunctionality<TurnInfoCode>{
        private readonly IMatchRepository _matchRepository;
        private readonly PlayerInfo _playerInfo;

        public GetTurnInfo(IMatchRepository matchRepository, PlayerInfo playerInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
        }

        public TurnInfoCode execute()
        {
            return _matchRepository.getTurnInfo(_playerInfo.Id);
        }
    }
}