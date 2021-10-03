using System;
using System.Collections.Generic;
using System.Linq;
using database;
using model;

namespace controller{
    public class GetMatchSquares : IUseCaseFunctionality<List<SquareInfo>>{
        private readonly IMatchRepository _matchRepository;
        private readonly BoardInfo _matchInfo;
        private readonly Func<SquareInfo, bool> _filter;

        public GetMatchSquares(IMatchRepository matchRepository, BoardInfo matchInfo, Func<SquareInfo, bool> filter)
        {
            _matchRepository = matchRepository;
            _matchInfo = matchInfo;
            _filter = filter;
        }

        public List<SquareInfo> execute()
        {
            return _matchRepository.getMatchSquares(_matchInfo.Id, _filter).ToList();
        }
    }
}