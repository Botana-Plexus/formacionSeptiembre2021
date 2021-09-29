using System;
using System.Collections.Generic;
using database;
using model;

namespace controller {
    public class ListCreatedMatchesByUser : IUseCaseFunctionality<List<MatchInfo>>{
        private readonly IMatchRepository matchRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly PlayerInfo playerInfo;

        public ListCreatedMatchesByUser(IMatchRepository matchRepository, IPlayerRepository playerRepository, PlayerInfo playerInfo)
        {
            this.matchRepository = matchRepository;
            this.playerRepository = playerRepository;
            this.playerInfo = playerInfo;
        }

        public List<MatchInfo> execute()
        {
            if (!playerRepository.exists(playerInfo)) throw new NullReferenceException();
            return matchRepository.findAll(match => match.host.Equals(playerInfo));
        }
    }
}