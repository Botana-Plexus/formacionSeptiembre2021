using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using database.model.codes;
using model;

namespace database{
    public interface IMatchRepository{
        void createMatch(string name, int hostId, int maxPlayers, int? maxDuration, string password, int boardId);
        IEnumerable<BoardInfo> getBoards(Func<BoardInfo, bool> filter);
        IEnumerable<MatchInfo> getMatches(Func<MatchInfo, bool> filter);
        IEnumerable<PlayerInfo> getMatchPlayers(int matchId, Func<PlayerInfo, bool> filter);
        IEnumerable<SquareInfo> getMatchSquares(int? boardId, Func<SquareInfo, bool> filter);
        void startMatch(int matchId);
        void endMatch(int matchId);
        void switchToObserver(int playerId);
        void leaveMatch(int playerId);
        AddPlayerCode joinMatch(int matchId, int userId, string password);
        int getRandomCard(int playerId);
        CardInfo getCardInfo(int cardId);
        TurnInfoCode getTurnInfo(int playerId);
        void endTurn(int playerId);
        void punishPlayer(int playerId);
        int movePlayer(int playerId, int amount);
        BuyPropertyCode buyProperty(int playerId);
        SellPropertyCode sellProperty(int playerId, int squareId);
        BuyEdificationCode addEdification(int playerId, int squareId);
        SellEdificationCode removeEdification(int playerId, int squareId);
        void updateDebt(int playerId, int? cardId, int multiplier);
        PayDebtCode payDebt(int playerId);
        int setDoubleRoll(int playerId, bool reset);
        IEnumerable<SquareInfo> getPlayerProperties(int playerId, Func<SquareInfo, bool> filter);

        UserInfo registerUser(UserInfo userInfo);
        int? authenticate(string username, string password);

        IEnumerable<UserInfo> getUsers(Func<UserInfo, bool> filter);
        PlayerInfo getFromUser(int userId);
    }
}