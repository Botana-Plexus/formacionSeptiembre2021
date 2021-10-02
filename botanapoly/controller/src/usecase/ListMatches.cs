using System;
using System.Collections.Generic;
using System.Linq;
using database;
using model;

namespace controller{
    public class ListMatches : IUseCaseFunctionality<List<MatchInfo>>{

        private readonly IMatchRepository _matchRepository;
        private readonly Func<MatchInfo, bool> _filter;

        public ListMatches(IMatchRepository matchRepository, Func<MatchInfo, bool> filter)
        {
            _matchRepository = matchRepository;
            _filter = filter;
        }

        public List<MatchInfo> execute()
        {
            return this._matchRepository.getMatches(_filter).ToList();
        }
    }
}