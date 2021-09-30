using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using model;

namespace database{
    public interface IMatchRepository{
        MatchInfo createMatch(PlayerInfo host, int? maxPlayers, int? maxDuration, string password, BoardInfo board);
        List<BoardInfo> getBoards(Func<BoardInfo, bool> filter);
        List<MatchInfo> getMatches(Func<MatchInfo, bool> filter);
        List<PlayerInfo> getMatchPlayers(MatchInfo matchInfo, Func<PlayerInfo, bool> filter);
        List<SquareInfo> getMatchSquares(MatchInfo matchInfo, Func<SquareInfo, bool> filter);
        MatchInfo startMatch(MatchInfo matchInfo);
        MatchInfo endMatch(MatchInfo matchInfo);
        MatchInfo leaveMatch(PlayerInfo playerInfo, bool watch);
        MatchInfo joinMatch(MatchInfo matchInfo, UserInfo userInfo, string password);
        CardInfo getRandomCard(PlayerInfo playerInfo);
        MatchInfo endTurn(PlayerInfo playerInfo);
        MatchInfo punishPlayer(PlayerInfo playerInfo);
        MatchInfo movePlayer(PlayerInfo playerInfo, int amount);
        MatchInfo manageProperty(PlayerInfo playerInfo, SquareInfo squareInfo, bool buy);
        MatchInfo addEdification(PlayerInfo playerInfo, SquareInfo squareInfo); //edificar vs venderEdificacion
        MatchInfo removeEdification(PlayerInfo playerInfo, SquareInfo squareInfo);
        MatchInfo payDebt(PlayerInfo playerInfo);
    }
}