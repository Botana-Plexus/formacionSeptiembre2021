using database;
using model;

namespace controller{
    public class AuthenticateUser : IUseCaseFunctionality<int?>{
        private readonly IMatchRepository _matchRepository;
        private readonly string _username;
        private readonly string _password;

        public AuthenticateUser(IMatchRepository matchRepository, string username, string password)
        {
            _matchRepository = matchRepository;
            _username = username;
            this._password = password;
        }

        public int? execute()
        {
            return _matchRepository.authenticate(_username, _password);
        }
    }
}