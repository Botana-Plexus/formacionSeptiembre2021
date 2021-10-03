using System.Collections.Generic;
using controller;

namespace model{
    public class MatchInfo : ModelEntity{
        private string _code;
        private int _hostId;
        private int? _maxPlayerAmount;
        private int? _maxDurationMinutes;
        private long _startDate;
        private bool _hasPassword;
        private int _currentPlayerAmount;
        private int _turn;
        private int _matchState;
        private int _boardId;
        private List<int> _playerIds;

        public MatchInfo(int id, string code, int hostId, int? maxPlayerAmount, int? maxDurationMinutes, long startDate, bool hasPassword, int currentPlayerAmount, int turn, int matchState, int boardId, List<int> playerIds) : base(id)
        {
            _code = code;
            _hostId = hostId;
            _maxPlayerAmount = maxPlayerAmount;
            _maxDurationMinutes = maxDurationMinutes;
            _startDate = startDate;
            _hasPassword = hasPassword;
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

        public int? MaxPlayerAmount
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
            get => _startDate;
            set => _startDate = value;
        }

        public bool Password
        {
            get => _hasPassword;
            set => _hasPassword = value;
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

        public int MatchState
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