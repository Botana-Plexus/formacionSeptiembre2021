using System;
using System.Collections.Generic;
using database;
using model;

namespace controller{
    public class CreateMatch : IUseCaseFunctionality<MatchInfo>{

        private IMatchRepository _matchRepository;
        private PlayerInfo _playerInfo;
        private string _name;
        private int? _maxPlayers;
        private int? _maxDuration;
        private string _password;
        private BoardInfo _boardInfo;

        public CreateMatch(IMatchRepository matchRepository, PlayerInfo playerInfo, string name, int? maxPlayers, int? maxDuration, string password, BoardInfo boardInfo)
        {
            _matchRepository = matchRepository;
            _playerInfo = playerInfo;
            _name = name;
            _maxPlayers = maxPlayers;
            _maxDuration = maxDuration;
            _password = password;
            _boardInfo = boardInfo;
        }

        public MatchInfo execute()
        {
            return this._matchRepository.createMatch(_playerInfo, _maxPlayers, _maxDuration, _password, _boardInfo);
        }
    }
}