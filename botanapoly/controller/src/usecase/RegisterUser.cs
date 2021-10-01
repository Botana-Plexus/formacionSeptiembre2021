using database;
using model;

namespace controller {
    public class RegisterUser : IUseCaseFunctionality<UserInfo>{

        private readonly IMatchRepository _matchRepository;
        private readonly UserInfo _userInfo;

        public RegisterUser(IMatchRepository matchRepository, UserInfo userInfo)
        {
            _matchRepository = matchRepository;
            _userInfo = userInfo;
        }

        public UserInfo execute()
        {
            return _matchRepository.registerUser(_userInfo);
        }
    }
}