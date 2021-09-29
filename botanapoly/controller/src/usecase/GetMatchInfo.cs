using System;
using database;
using model;

namespace controller{
    public class GetMatchInfo : IUseCaseFunctionality<MatchInfo>{
        private readonly IMatchRepository matchRepository;
        private readonly int matchId;

        public GetMatchInfo(IMatchRepository matchRepository, int matchId)
        {
            this.matchRepository = matchRepository;
            this.matchId = matchId;
        }

        public MatchInfo execute()
        {
            if (!matchRepository.exists(matchId)) throw new NullReferenceException();

            return matchRepository.find(matchId);
        }
    }
}