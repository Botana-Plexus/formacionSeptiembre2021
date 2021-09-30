using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using database;
using model;
using util;

namespace controller {
    public class JoinMatch : IUseCaseFunctionality<MatchInfo>{

        private readonly IMatchRepository _matchRepository;
        private readonly MatchInfo _matchInfo;
        private readonly UserInfo _userInfo;
        private readonly string _password;

        public JoinMatch(IMatchRepository matchRepository, MatchInfo matchInfo, UserInfo userInfo, string password)
        {
            _matchRepository = matchRepository;
            _matchInfo = matchInfo;
            _userInfo = userInfo;
            _password = password;
        }

        public MatchInfo execute()
        {
            return _matchRepository.joinMatch(_matchInfo, _userInfo, _password);
        }
    }
}