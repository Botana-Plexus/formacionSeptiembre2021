using System;
using System.Collections.Generic;
using database;
using model;

namespace controller {
    public class GetMatchSquares : IUseCaseFunctionality<List<SquareInfo>>{

        private readonly IMatchRepository _matchRepository;
        private readonly MatchInfo _matchInfo;
        private readonly Func<SquareInfo, bool> _filter;

        public GetMatchSquares(IMatchRepository matchRepository, MatchInfo matchInfo, Func<SquareInfo, bool> filter)
        {
            _matchRepository = matchRepository;
            _matchInfo = matchInfo;
            _filter = filter;
        }

        public List<SquareInfo> execute()
        {
            return _matchRepository.getMatchSquares(_matchInfo, _filter);
        }
    }
}