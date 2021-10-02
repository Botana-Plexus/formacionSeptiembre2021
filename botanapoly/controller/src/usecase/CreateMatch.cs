using System;
using System.Collections.Generic;
using database;
using model;

namespace controller{
    public class CreateMatch : IUseCaseFunctionality<int>{

        private readonly IMatchRepository _matchRepository;
        private readonly UserInfo _userInfo;
        private readonly string _name;
        private readonly int _maxPlayers;
        private readonly int? _maxDuration;
        private readonly string _password;
        private readonly BoardInfo _boardInfo;

        public CreateMatch(IMatchRepository matchRepository, UserInfo userInfo, string name, int maxPlayers, int? maxDuration, string password, BoardInfo boardInfo)
        {
            _matchRepository = matchRepository;
            _userInfo = userInfo;
            _name = name;
            _maxPlayers = maxPlayers;
            _maxDuration = maxDuration;
            _password = password;
            _boardInfo = boardInfo;
        }

        public int execute()
        {
            _matchRepository.createMatch(_name, _userInfo, _maxPlayers, _maxDuration, _password, _boardInfo);
            return 0;
        }
    }
}