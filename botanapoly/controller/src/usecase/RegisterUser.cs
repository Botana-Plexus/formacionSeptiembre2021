using database;
using model;

namespace controller{
    public class RegisterUser : IUseCaseFunctionality<int>{
        private readonly IMatchRepository _matchRepository;
        private readonly UserInfo _userInfo;

        public RegisterUser(IMatchRepository matchRepository, UserInfo userInfo)
        {
            _matchRepository = matchRepository;
            _userInfo = userInfo;
        }

        public int execute()
        {
            _matchRepository.registerUser(_userInfo);
            return 0;
        }
    }
}