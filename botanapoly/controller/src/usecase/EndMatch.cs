using System;
using database;
using model;
using util;

namespace controller{
    public class EndMatch : IUseCaseFunctionality<int>{
        private readonly IMatchRepository _matchRepository;
        private readonly MatchInfo matchInfo;

        public EndMatch(IMatchRepository matchRepository, MatchInfo matchInfo)
        {
            this._matchRepository = matchRepository;
            this.matchInfo = matchInfo;
        }

        public int execute()
        {
            _matchRepository.endMatch(matchInfo);
            return 0;
        }
    }
}