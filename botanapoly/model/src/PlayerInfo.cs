using controller;

namespace model{
    public class PlayerInfo : ModelEntity{
        private readonly UserInfo _user;
        private readonly MatchInfo _match;
        private readonly double _balance;
        private readonly SquareInfo _square;
        private readonly int turn;

        public PlayerInfo(int id, UserInfo user, MatchInfo match, double balance, SquareInfo square, int turn) : base(id)
        {
            _user = user;
            _match = match;
            _balance = balance;
            _square = square;
            this.turn = turn;
        }

        public UserInfo User => _user;

        public MatchInfo Match => _match;

        public double Balance => _balance;

        public SquareInfo Square => _square;

        public int Turn => turn;
        
    }
}