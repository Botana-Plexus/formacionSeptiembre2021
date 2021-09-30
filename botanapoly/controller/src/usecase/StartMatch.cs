using System;
using database;
using model;
using util;

namespace controller{
    public class StartMatch : IUseCaseFunctionality<MatchInfo>{
        
        private readonly IMatchRepository matchRepository;
        private readonly MatchInfo matchInfo;

        public StartMatch(IMatchRepository matchRepository, MatchInfo matchInfo)
        {
            this.matchRepository = matchRepository;
            this.matchInfo = matchInfo;
        }

        public MatchInfo execute()
        {
            return matchRepository.startMatch(matchInfo);
        }
    }
}