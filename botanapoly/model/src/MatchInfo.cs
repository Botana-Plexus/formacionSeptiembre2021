using System.Collections.Generic;
using controller;

namespace model{
    public class MatchInfo : ModelEntity{
        private string _code;
        private PlayerInfo _host;
        private int _maxPlayerAmount;
        private int _maxDurationMinutes;
        private long _startedDate;
        private string _password;
        private int _currentPlayerAmount;
        private int _turn;
        private MatchState _matchState;
        private BoardInfo _boardInfo;
        private List<PlayerInfo> _players;

        public MatchInfo(int id, string code, PlayerInfo host, int maxPlayerAmount, int maxDurationMinutes, long startedDate, string password, int currentPlayerAmount, int turn, MatchState matchState, BoardInfo boardInfo, List<PlayerInfo> players) : base(id)
        {
            _code = code;
            _host = host;
            _maxPlayerAmount = maxPlayerAmount;
            _maxDurationMinutes = maxDurationMinutes;
            _startedDate = startedDate;
            _password = password;
            _currentPlayerAmount = currentPlayerAmount;
            _turn = turn;
            _matchState = matchState;
            _boardInfo = boardInfo;
            _players = players;
        }

        public string Code
        {
            get => _code;
            set => _code = value;
        }

        public PlayerInfo Host
        {
            get => _host;
            set => _host = value;
        }

        public int MaxPlayerAmount
        {
            get => _maxPlayerAmount;
            set => _maxPlayerAmount = value;
        }

        public int MaxDurationMinutes
        {
            get => _maxDurationMinutes;
            set => _maxDurationMinutes = value;
        }

        public long StartedDate
        {
            get => _startedDate;
            set => _startedDate = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public int CurrentPlayerAmount
        {
            get => _currentPlayerAmount;
            set => _currentPlayerAmount = value;
        }

        public int Turn
        {
            get => _turn;
            set => _turn = value;
        }

        public MatchState MatchState
        {
            get => _matchState;
            set => _matchState = value;
        }

        public BoardInfo BoardInfo
        {
            get => _boardInfo;
            set => _boardInfo = value;
        }

        public List<PlayerInfo> Players
        {
            get => _players;
            set => _players = value;
        }
    }
}