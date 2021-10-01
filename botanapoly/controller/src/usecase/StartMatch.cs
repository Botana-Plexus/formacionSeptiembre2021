using System;
using database;
using model;
using util;

namespace controller{
    public class StartMatch : IUseCaseFunctionality<int>{
        
        private readonly IMatchRepository matchRepository;
        private readonly MatchInfo matchInfo;

        public StartMatch(IMatchRepository matchRepository, MatchInfo matchInfo)
        {
            this.matchRepository = matchRepository;
            this.matchInfo = matchInfo;
        }

        public int execute()
        {
            matchRepository.startMatch(matchInfo);
            return 0;
        }
    }
}