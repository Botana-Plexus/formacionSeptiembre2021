using System.Collections.Generic;
using controller;

namespace model{
    public class MatchInfo : ModelEntity{
        private readonly string _code;
        private readonly PlayerInfo _host;
        private readonly int _maxPlayerNo;
        private readonly long _createdDate;
        private readonly string password;
        private readonly int _currentPlayerNo;
        private readonly int _turn;
        private readonly MatchState _matchState;
        private readonly BoardInfo _boardInfo;

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

        public string Code => _code;

        public PlayerInfo Host => _host;

        public int MaxPlayerNo => _maxPlayerNo;

        public long CreatedDate => _createdDate;

        public string Password => password;

        public int CurrentPlayerNo => _currentPlayerNo;

        public int Turn => _turn;

        public MatchState MatchState => _matchState;

        public BoardInfo BoardInfo => _boardInfo;
        
    }
}