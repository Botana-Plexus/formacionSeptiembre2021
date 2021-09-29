using System.Collections.Generic;
using controller;

namespace model{
    public class MatchInfo : ModelEntity{
        private string _code;
        private PlayerInfo _host;
        private int _maxPlayerNo;
        private long _createdDate;
        private string password;
        private int _currentPlayerNo;
        private int _turn;
        private MatchState _matchState;
        private BoardInfo _boardInfo;

        public MatchInfo(int id, string code, PlayerInfo host, int maxPlayerNo, long createdDate, string password, int currentPlayerNo, int turn, MatchState matchState, BoardInfo boardInfo) : base(id)
        {
            _code = code;
            _host = host;
            _maxPlayerNo = maxPlayerNo;
            _createdDate = createdDate;
            this.password = password;
            _currentPlayerNo = currentPlayerNo;
            _turn = turn;
            _matchState = matchState;
            _boardInfo = boardInfo;
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

        public int MaxPlayerNo
        {
            get => _maxPlayerNo;
            set => _maxPlayerNo = value;
        }

        public long CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public int CurrentPlayerNo
        {
            get => _currentPlayerNo;
            set => _currentPlayerNo = value;
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
    }
}