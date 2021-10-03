using System;
using System.Collections.Generic;
using database;
using model;

namespace controller{
    public class CreateMatch : IUseCaseFunctionality<int>{
        private readonly IMatchRepository _matchRepository;
        private readonly int _hostId;
        private readonly string _name;
        private readonly int _maxPlayers;
        private readonly int? _maxDuration;
        private readonly string _password;
        private readonly int _boardId;

        public CreateMatch(IMatchRepository matchRepository, int hostId, string name, int maxPlayers, int? maxDuration, string password, int boardId)
        {
            _matchRepository = matchRepository;
            _hostId = hostId;
            _name = name;
            _maxPlayers = maxPlayers;
            _maxDuration = maxDuration;
            _password = password;
            _boardId = boardId;
        }

        public int execute()
        {
            _matchRepository.createMatch(_name, _hostId, _maxPlayers, _maxDuration, _password, _boardId);
            return 0;
        }
    }
}