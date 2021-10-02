using System;
using System.Collections.Generic;
using System.Linq;
using controller;
using model;

namespace database{
    public class MatchRepositoryMock : IMatchRepository{

        private List<MatchInfo> _matches;
        private List<BoardInfo> _boards;
        private List<PlayerInfo> _players;
        private List<UserInfo> _users;

        public MatchRepositoryMock()
        {
            _users = new List<UserInfo>()
            {
                new UserInfo(1, "", "user1", "pass1", 127356178236871623L),
                new UserInfo(2, "", "user2", "pass2", 182763871263872136L)
            };
            _players = new List<PlayerInfo>()
            {
                new PlayerInfo(1, _users[0], -1, 100D,-1,null,null,null,null,-1),
                new PlayerInfo(2, _users[1], -1, 100D,-1,null,null,null,null,-1)
            };
            _matches = new List<MatchInfo>()
            {
                new MatchInfo(1, "", _players[0].Id, 6, 0, 0l, "asdf", 0, 1, MatchState.CREATED, -1, null),
                new MatchInfo(2, "", _players[1].Id, 6, 0, 0l, "asdf", 0, 1, MatchState.CREATED, -1, null)
            };
            _boards = new List<BoardInfo>
            {
                new BoardInfo(1, new List<SquareInfo>(), 100D)
            };
            _players[0].Match = _matches[0].Id;
            _players[1].Match = _matches[1].Id;
        }

        public void createMatch(string name, int hostId, int maxPlayers, int? maxDuration, string password, int boardId)
        {
            int id = _matches.Count + 1;
            _matches.Add(new MatchInfo(id, name, hostId, maxPlayers, maxDuration, 0L, password, 0, 1, MatchState.CREATED, boardId, null));
        }

        public IEnumerable<BoardInfo> getBoards(Func<BoardInfo, bool> filter)
        {
            return _boards.Where(filter);
        }

        public IEnumerable<MatchInfo> getMatches(Func<MatchInfo, bool> filter)
        {
            return _matches.Where(filter);
        }

        public List<PlayerInfo> getMatchPlayers(MatchInfo matchInfo, Func<PlayerInfo, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<SquareInfo> getMatchSquares(BoardInfo matchInfo, Func<SquareInfo, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void startMatch(int matchId)
        {
            this.getMatches(match => match.Id.Equals(matchId)).First().MatchState = MatchState.RUNNING;
        }

        public void endMatch(int matchId)
        {
            this.getMatches(match => match.Id.Equals(matchId)).First().MatchState = MatchState.TERMINATED;
        }

        public void switchToObserver(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public void leaveMatch(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public int joinMatch(MatchInfo matchInfo, UserInfo userInfo, string password)
        {
            throw new NotImplementedException();
        }

        public int getRandomCard(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public CardInfo getCardInfo(CardInfo cardInfo)
        {
            throw new NotImplementedException();
        }

        public int getTurnInfo(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public void endTurn(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public void punishPlayer(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public int movePlayer(PlayerInfo playerInfo, int amount)
        {
            throw new NotImplementedException();
        }

        public int buyProperty(PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            throw new NotImplementedException();
        }

        public int sellProperty(PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            throw new NotImplementedException();
        }

        public int addEdification(PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            throw new NotImplementedException();
        }

        public int removeEdification(PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            throw new NotImplementedException();
        }

        public void updateDebt(PlayerInfo playerInfo, CardInfo cardInfo)
        {
            throw new NotImplementedException();
        }

        public int payDebt(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public void setDoubleRoll(PlayerInfo player, bool reset)
        {
            throw new NotImplementedException();
        }

        public object getPlayerProperties(PlayerInfo playerInfo, Func<PlayerInfo, bool> filter)
        {
            throw new NotImplementedException();
        }

        public void registerUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public int authenticate(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserInfo> getUsers(Func<UserInfo, bool> filter)
        {
            return _users.Where(filter);
        }
    }
}