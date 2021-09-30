using System;
using System.Collections.Generic;
using System.Linq;
using controller;
using model;

namespace database{
    public class MatchRepositoryMock : IMatchRepository{

        private List<MatchInfo> _matches;

        public MatchRepositoryMock()
        {
            _matches = new List<MatchInfo>()
            {
                {
                    new MatchInfo(1, "", null, 6, 0, 0l, "asdf", 0, 1, MatchState.CREATED, null, null)
                },
                {
                    new MatchInfo(2, "", null, 6, 0, 0l, "asdf", 0, 1, MatchState.CREATED, null, null)
                }
            };
        }
        
        public MatchInfo createMatch(PlayerInfo host, int? maxPlayers, int? maxDuration, string password, BoardInfo board)
        {
            throw new NotImplementedException();
        }

        public List<BoardInfo> getBoards(Func<BoardInfo, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<MatchInfo> getMatches(Func<MatchInfo, bool> filter)
        {
            return _matches.Where(filter).ToList();
        }

        public List<PlayerInfo> getMatchPlayers(MatchInfo matchInfo, Func<PlayerInfo, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<SquareInfo> getMatchSquares(MatchInfo matchInfo, Func<SquareInfo, bool> filter)
        {
            throw new NotImplementedException();
        }

        public MatchInfo startMatch(MatchInfo matchInfo)
        {
            throw new NotImplementedException();
        }

        public MatchInfo endMatch(MatchInfo matchInfo)
        {
            throw new NotImplementedException();
        }

        public MatchInfo leaveMatch(PlayerInfo playerInfo, bool watch)
        {
            throw new NotImplementedException();
        }

        public MatchInfo joinMatch(MatchInfo matchInfo, UserInfo userInfo, string password)
        {
            throw new NotImplementedException();
        }

        public CardInfo getRandomCard(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public MatchInfo endTurn(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public MatchInfo punishPlayer(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public MatchInfo movePlayer(PlayerInfo playerInfo, int amount)
        {
            throw new NotImplementedException();
        }

        public MatchInfo manageProperty(PlayerInfo playerInfo, SquareInfo squareInfo, bool buy)
        {
            throw new NotImplementedException();
        }

        public MatchInfo addEdification(PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            throw new NotImplementedException();
        }

        public MatchInfo removeEdification(PlayerInfo playerInfo, SquareInfo squareInfo)
        {
            throw new NotImplementedException();
        }

        public MatchInfo payDebt(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }
    }
}