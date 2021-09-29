namespace model{
    public class UserInfo : ModelEntity{
        private  string _email;
        private  string _username;
        private  string _password;
        private  long _birth;

        public UserInfo(int id, string email, string username, string password, long birth) : base(id)
        {
            _email = email;
            _username = username;
            _password = password;
            _birth = birth;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public long Birth
        {
            get => _birth;
            set => _birth = value;
        }
    }
}