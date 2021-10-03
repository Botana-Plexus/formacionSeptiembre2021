using System;
using database;
using model;
using util;

namespace controller{
    public class StartMatch : IUseCaseFunctionality<int>{
        private readonly IMatchRepository matchRepository;
        private readonly int matchId;

        public StartMatch(IMatchRepository matchRepository, int matchId)
        {
            this.matchRepository = matchRepository;
            this.matchId = matchId;
        }

        public int execute()
        {
            matchRepository.startMatch(matchId);
            return 0;
        }
    }
}