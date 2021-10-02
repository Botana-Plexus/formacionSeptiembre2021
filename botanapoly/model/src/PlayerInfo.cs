using controller;

namespace model{
    public class PlayerInfo : ModelEntity{
        
        private  UserInfo _user;
        private  int _matchId;
        private  double _balance;
        private  int _squareId;
        private  int? _turn;
        private int? _remainingPunishmentRounds;
        private int? _doubleRollsCounter;
        private int? _debt;
        private int _creditorId;

        public PlayerInfo(int id, UserInfo user, int matchId, double balance, int squareId, int? turn, int? remainingPunishmentRounds, int? doubleRollsCounter, int? debt, int creditorId) : base(id)
        {
            _user = user;
            _matchId = matchId;
            _balance = balance;
            _squareId = squareId;
            _turn = turn;
            _remainingPunishmentRounds = remainingPunishmentRounds;
            _doubleRollsCounter = doubleRollsCounter;
            _debt = debt;
            _creditorId = creditorId;
        }

        public UserInfo User
        {
            get => _user;
            set => _user = value;
        }

        public int Match
        {
            get => _matchId;
            set => _matchId = value;
        }

        public double Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public int Square
        {
            get => _squareId;
            set => _squareId = value;
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

        public int Creditor
        {
            get => _creditorId;
            set => _creditorId = value;
        }
    }
}