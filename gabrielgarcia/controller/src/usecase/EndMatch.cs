using System;
using database;
using model;
using util;

namespace controller{
    public class EndMatch : IUseCaseFunctionality<int>{
        private readonly IMatchRepository _matchRepository;
        private readonly int _matchId;

        public EndMatch(IMatchRepository matchRepository, int matchId)
        {
            _matchRepository = matchRepository;
            _matchId = matchId;
        }

        public int execute()
        {
            _matchRepository.endMatch(_matchId);
            return 0;
        }
    }
}