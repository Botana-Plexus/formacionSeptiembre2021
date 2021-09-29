using System;
using System.Collections.Generic;
using database;
using model;
using util;

namespace controller {
    public class JoinMatch : IUseCaseFunctionality<MatchInfo>{
        private readonly IMatchRepository matchRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly MatchInfo matchInfo;
        private readonly PlayerInfo playerInfo;

        public JoinMatch(IMatchRepository matchRepository, IPlayerRepository playerRepository, MatchInfo matchInfo, PlayerInfo playerInfo)
        {
            this.matchRepository = matchRepository;
            this.playerRepository = playerRepository;
            this.matchInfo = matchInfo;
            this.playerInfo = playerInfo;
        }

        public MatchInfo execute()
        {
            MatchInfo result = null;
            List<PlayerInfo> players = null;
            if (!playerRepository.exists(playerInfo) || !matchRepository.exists(matchInfo)) throw new NullReferenceException();

            result = ExtensionMethods.DeepClone(matchInfo);
            players = result.players;
            players.Add(playerInfo);
            result.players = players;
            result = matchRepository.saveOrUpdate(result);
            if (result == null) throw new NullReferenceException();

            return result;
        }
    }
}