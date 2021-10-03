using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using controller;
using database.model;
using database.model.codes;
using model;

namespace database{
    public class MatchRepositorySqlServerDb : IMatchRepository{
        private readonly IConnectionFactory _connectionFactory;

        public MatchRepositorySqlServerDb(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void createMatch(string name, int hostId, int maxPlayers, int? maxDuration, string password, int boardId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            var d = maxDuration.HasValue ? maxDuration.Value : -1;
            var p = password.Trim().Length > 0 ? password : "null";
            sql.executeStoredProcedure($"crearPartida '{name}','{hostId}','{maxPlayers}','{maxDuration}','{p}','{boardId}'");
        }

        public IEnumerable<BoardInfo> getBoards(Func<BoardInfo, bool> filter)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return sql.executeStoredProcedureReader($"getTableros")
                .Select(Parsers.parseBoard)
                .Where(filter);
        }

        //TODO: tiempoTranscurrido???
        //TODO: switch filter for int
        public IEnumerable<MatchInfo> getMatches(Func<MatchInfo, bool> filter)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return sql.executeStoredProcedureReader($"getPartidas null")
                .Select(Parsers.parseMatch)
                .Where(filter)
                .Select(match =>
                {
                    match.PlayerIds = getMatchPlayers(match.Id, player => true).Select(e => e.Id).ToList();
                    return match;
                });
        }

        public IEnumerable<PlayerInfo> getMatchPlayers(int matchId, Func<PlayerInfo, bool> filter)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return sql.executeStoredProcedureReader($"getJugadoresInfo '{matchId}'")
                .Select(Parsers.parsePlayer)
                .Where(filter);
        }

        public IEnumerable<SquareInfo> getMatchSquares(int? boardId, Func<SquareInfo, bool> filter)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            var b = boardId.HasValue ? "" + boardId.Value : null;
            return sql.executeStoredProcedureReader($"getCasillas '{b}', 'null'")
                .Select(Parsers.parseSquare)
                .Where(filter);
        }


        public void startMatch(int matchId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            sql.executeStoredProcedure($"ComenzarPartida '{matchId}'");
        }

        public void endMatch(int matchId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            sql.executeStoredProcedure($"finalizarPartida '{matchId}'");
        }

        public void switchToObserver(int playerId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            sql.executeStoredProcedure($"retirarJugador '{playerId}'");
        }

        public void leaveMatch(int playerId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            sql.executeStoredProcedure($"abandonarPartida '{playerId}'");
        }

        public AddPlayerCode joinMatch(int matchId, int userId, string password)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return (AddPlayerCode) sql.executeStoredProcedureINT($"anadirJugador '{userId}', '{matchId}', '{password}'");
        }

        public int getRandomCard(int playerId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return sql.executeStoredProcedureINT($"getCartaAletoria '{playerId}'");
        }

        public CardInfo getCardInfo(int cardId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return sql.executeStoredProcedureReader($"getInfoCarta {cardId}")
                .Select(Parsers.parseCard)
                .First();
        }

        public TurnInfoCode getTurnInfo(int playerId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return (TurnInfoCode) sql.executeStoredProcedureINT($"getTurno {playerId}");
        }

        public void endTurn(int playerId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            sql.executeStoredProcedure($"finalizarTurno '{playerId}'");
        }

        public void punishPlayer(int playerId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            sql.executeStoredProcedure($"castigar '{playerId}'");
        }

        public int movePlayer(int playerId, int amount)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return sql.executeStoredProcedureINT($"mover {playerId},{amount}");
        }

        public BuyPropertyCode buyProperty(int playerId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return (BuyPropertyCode) sql.executeStoredProcedureINT($"comprar {playerId}");
        }

        public SellPropertyCode sellProperty(int playerId, int squareId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return (SellPropertyCode) sql.executeStoredProcedureINT($"vender '{playerId}', '{squareId}'");
        }

        public BuyEdificationCode addEdification(int playerId, int squareId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return (BuyEdificationCode) sql.executeStoredProcedureINT($"edificar '{playerId}' '{squareId}'");
        }

        public SellEdificationCode removeEdification(int playerId, int squareId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return (SellEdificationCode) sql.executeStoredProcedureINT($"venderEdificacion '{playerId}' '{squareId}'");
        }

        public void updateDebt(int playerId, int? cardId, int multiplier)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            var c = cardId.HasValue ? $"{cardId}" : "null";
            sql.executeStoredProcedure($"actualizarDeuda '{playerId}' '{c}', {multiplier}");
        }

        public PayDebtCode payDebt(int playerId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return (PayDebtCode) sql.executeStoredProcedureINT($"pagarDeuda '{playerId}'");
        }

        public int setDoubleRoll(int playerId, bool reset)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            var r = reset ? "1" : "";
            return sql.executeStoredProcedureINT($"setDobles '{playerId}' '{r}'");
        }

        public IEnumerable<SquareInfo> getPlayerProperties(int playerId, Func<SquareInfo, bool> filter)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return sql.executeStoredProcedureReader($"getPropiedades '{playerId}'")
                .Select(Parsers.parseSquare)
                .Where(filter);
        }

        public UserInfo registerUser(UserInfo userInfo)
        {
            QuerysSQL sql = new QuerysSQL(_connectionFactory.get());
            var d = new DateTime(1970, 1, 1).AddSeconds(userInfo.Birth);
            sql.executeStoredProcedure($"registrar '{userInfo.Email}', '{userInfo.Username}', '{userInfo.Password}', '{d}'");
            return sql.executeStoredProcedureReader($"select id, email, nick, pass, fechaNacimiento from usuarios u where u.nick = '{userInfo.Username}'")
                .Select(Parsers.parseUser)
                .First();
        }

        public int? authenticate(string username, string password)
        {
            return new QuerysSQL(_connectionFactory.get()).executeStoredProcedureINT($"select id from usuarios u where u.nick = '{username}' and u.pass = '{password}'");
        }

        public IEnumerable<UserInfo> getUsers(Func<UserInfo, bool> filter)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return sql.executeStoredProcedureReader("select id, email, nick, pass, fechaNacimiento from usuarios")
                .Select(Parsers.parseUser)
                .Where(filter);
        }

        public PlayerInfo getFromUser(int userId)
        {
            var sql = new QuerysSQL(_connectionFactory.get());
            return sql.executeStoredProcedureReader($"select id, idUsuario, idPartida, saldo, posicion, orden, dobles, turnosDeCastigo, deuda, acreedor from jugadores j where j.id = '{userId}'")
                .Select(Parsers.parsePlayer)
                .First();
        }
    }
}