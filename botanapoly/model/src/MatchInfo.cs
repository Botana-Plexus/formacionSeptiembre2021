using System.Collections.Generic;
using controller;

namespace model{
    public class MatchInfo : ModelEntity{
        private string _code;
        private int _hostId;
        private int _maxPlayerAmount;
        private int? _maxDurationMinutes;
        private long _startedDate;
        private string _password;
        private int _currentPlayerAmount;
        private int _turn;
        private MatchState _matchState;
        private int _boardId;
        private List<int> _playerIds;

        public MatchInfo(int id, string code, int hostId, int maxPlayerAmount, int? maxDurationMinutes, long startedDate, string password, int currentPlayerAmount, int turn, MatchState matchState, int boardId, List<int> playerIds) : base(id)
        {
            _code = code;
            _hostId = hostId;
            _maxPlayerAmount = maxPlayerAmount;
            _maxDurationMinutes = maxDurationMinutes;
            _startedDate = startedDate;
            _password = password;
            _currentPlayerAmount = currentPlayerAmount;
            _turn = turn;
            _matchState = matchState;
            _boardId = boardId;
            _playerIds = playerIds;
        }

        public string Code
        {
            get => _code;
            set => _code = value;
        }

        public int HostId
        {
            get => _hostId;
            set => _hostId = value;
        }

        public int MaxPlayerAmount
        {
            get => _maxPlayerAmount;
            set => _maxPlayerAmount = value;
        }

        public int? MaxDurationMinutes
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

        public int BoardInfo
        {
            get => _boardId;
            set => _boardId = value;
        }

        public List<int> PlayerIds
        {
            get => _playerIds;
            set => _playerIds = value;
        }
    }
}