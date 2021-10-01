using database;
using model;

namespace controller {
    public class AuthenticateUser : IUseCaseFunctionality<int>{

        private readonly IMatchRepository _matchRepository;
        private readonly UserInfo _userInfo;

        public AuthenticateUser(IMatchRepository matchRepository, UserInfo userInfo)
        {
            _matchRepository = matchRepository;
            _userInfo = userInfo;
        }

        public int execute()
        {
            return _matchRepository.authenticate(_userInfo);
        }
    }
}