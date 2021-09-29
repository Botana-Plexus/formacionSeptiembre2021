using controller;

namespace model{
    public class PlayerInfo : ModelEntity{
        private  UserInfo _user;
        private  MatchInfo _match;
        private  double _balance;
        private  SquareInfo _square;
        private  int turn;

        public PlayerInfo(int id, UserInfo user, MatchInfo match, double balance, SquareInfo square, int turn) : base(id)
        {
            _user = user;
            _match = match;
            _balance = balance;
            _square = square;
            this.turn = turn;
        }

        public UserInfo User
        {
            get => _user;
            set => _user = value;
        }

        public MatchInfo Match
        {
            get => _match;
            set => _match = value;
        }

        public double Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public SquareInfo Square
        {
            get => _square;
            set => _square = value;
        }

        public int Turn
        {
            get => turn;
            set => turn = value;
        }
    }
}