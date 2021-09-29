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
            MatchInfo result = null;
            if (!matchRepository.exists(matchInfo)) throw new NullReferenceException();

            result = ExtensionMethods.DeepClone(matchInfo);
            result.MatchState = MatchState.RUNNING;
            result = matchRepository.saveOrUpdate(matchInfo);
            if (result == null) throw new NullReferenceException();

            return result;
        }
    }
}