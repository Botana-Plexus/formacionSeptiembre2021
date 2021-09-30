using controller;

namespace model{
    public class PlayerInfo : ModelEntity{
        
        private  UserInfo _user;
        private  MatchInfo _match;
        private  double _balance;
        private  SquareInfo _square;
        private  int? _turn;
        private int? _remainingPunishmentRounds;
        private int? _doubleRollsCounter;
        private int? _debt;
        private PlayerInfo _creditor;

        public PlayerInfo(int id, UserInfo user, MatchInfo match, double balance, SquareInfo square, int? turn, int? remainingPunishmentRounds, int? doubleRollsCounter, int? debt, PlayerInfo creditor) : base(id)
        {
            _user = user;
            _match = match;
            _balance = balance;
            _square = square;
            _turn = turn;
            _remainingPunishmentRounds = remainingPunishmentRounds;
            _doubleRollsCounter = doubleRollsCounter;
            _debt = debt;
            _creditor = creditor;
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

        public int? Turn
        {
            get => _turn;
            set => _turn = value;
        }

        public int? RemainingPunishmentRounds
        {
            get => _remainingPunishmentRounds;
            set => _remainingPunishmentRounds = value;
        }

        public int? DoubleRollsCounter
        {
            get => _doubleRollsCounter;
            set => _doubleRollsCounter = value;
        }

        public int? Debt
        {
            get => _debt;
            set => _debt = value;
        }

        public PlayerInfo Creditor
        {
            get => _creditor;
            set => _creditor = value;
        }
    }
}