using System;
using System.Collections.Generic;
using System.Linq;
using database;
using model;

namespace controller{
    public class GetMatchPlayers : IUseCaseFunctionality<List<PlayerInfo>>{
        private readonly IMatchRepository _matchRepository;
        private readonly MatchInfo _matchInfo;
        private readonly Func<PlayerInfo, bool> _filter;

        public GetMatchPlayers(IMatchRepository matchRepository, MatchInfo matchInfo, Func<PlayerInfo, bool> filter)
        {
            _matchRepository = matchRepository;
            _matchInfo = matchInfo;
            _filter = filter;
        }

        public List<PlayerInfo> execute()
        {
            return _matchRepository.getMatchPlayers(_matchInfo.Id, _filter).ToList();
        }
    }
}