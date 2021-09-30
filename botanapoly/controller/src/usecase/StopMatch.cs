using System;
using database;
using model;
using util;

namespace controller{
    public class StopMatch : IUseCaseFunctionality<MatchInfo>{
        private readonly IMatchRepository matchRepository;
        private readonly MatchInfo matchInfo;

        public StopMatch(IMatchRepository matchRepository, MatchInfo matchInfo)
        {
            this.matchRepository = matchRepository;
            this.matchInfo = matchInfo;
        }

        public MatchInfo execute()
        {
            return matchRepository.endMatch(matchInfo);
        }
    }
}