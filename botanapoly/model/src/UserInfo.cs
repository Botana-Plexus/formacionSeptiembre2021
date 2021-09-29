namespace model{
    public class UserInfo : ModelEntity{
        private readonly string _email;
        private readonly string _username;
        private readonly string _password;
        private readonly long _birth;

        public UserInfo(int id, string email, string username, string password, long birth) : base(id)
        {
            _email = email;
            _username = username;
            _password = password;
            _birth = birth;
        }

        public string Email => _email;

        public string Username => _username;

        public string Password => _password;

        public long Birth => _birth;
        
    }
}