using System;
using System.Collections.Generic;
using database;
using model;

namespace controller{
    public class ListMatches : IUseCaseFunctionality<List<MatchInfo>>{
        private readonly Func<MatchInfo, bool> matchFilter;
        private readonly IMatchRepository matchRepository;

        public ListMatches(IMatchRepository matchRepository, Func<MatchInfo, bool> matchFilter)
        {
            this.matchRepository = matchRepository;
            this.matchFilter = matchFilter;
        }

        public List<MatchInfo> execute()
        {
            return matchRepository.findAll(matchFilter ?? (_ => true));
        }
    }
}