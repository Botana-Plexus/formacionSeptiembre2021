using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using model;

namespace database{
    public interface IMatchRepository{
        void createMatch(string name, int hostId, int maxPlayers, int? maxDuration, string password, int boardId);
        IEnumerable<BoardInfo> getBoards(Func<BoardInfo, bool> filter);
        IEnumerable<MatchInfo> getMatches(Func<MatchInfo, bool> filter);
        List<PlayerInfo> getMatchPlayers(MatchInfo matchInfo, Func<PlayerInfo, bool> filter);
        List<SquareInfo> getMatchSquares(BoardInfo matchInfo, Func<SquareInfo, bool> filter);
        void startMatch(int matchId);
        void endMatch(int matchId);
        void switchToObserver(PlayerInfo playerInfo);
        void leaveMatch(PlayerInfo playerInfo);
        int joinMatch(MatchInfo matchInfo, UserInfo userInfo, string password);
        int getRandomCard(PlayerInfo playerInfo);
        CardInfo getCardInfo(CardInfo cardInfo);
        int getTurnInfo(PlayerInfo playerInfo);
        void endTurn(PlayerInfo playerInfo);
        void punishPlayer(PlayerInfo playerInfo);
        int movePlayer(PlayerInfo playerInfo, int amount);
        int buyProperty(PlayerInfo playerInfo, SquareInfo squareInfo);
        int sellProperty(PlayerInfo playerInfo, SquareInfo squareInfo);
        int addEdification(PlayerInfo playerInfo, SquareInfo squareInfo); //edificar vs venderEdificacion
        int removeEdification(PlayerInfo playerInfo, SquareInfo squareInfo);
        void updateDebt(PlayerInfo playerInfo, CardInfo cardInfo);
        int payDebt(PlayerInfo playerInfo);
        void setDoubleRoll(PlayerInfo player, bool reset);
        object getPlayerProperties(PlayerInfo playerInfo, Func<PlayerInfo, bool> filter);

        void registerUser(UserInfo userInfo);
        int authenticate(UserInfo userInfo);

        IEnumerable<UserInfo> getUsers(Func<UserInfo, bool> filter);
    }
}