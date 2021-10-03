using System;
using System.Collections.Generic;
using System.Linq;
using database;
using model;

namespace controller{
    public class GetBoards : IUseCaseFunctionality<List<BoardInfo>>{
        private readonly IMatchRepository _matchRepository;
        private readonly Func<BoardInfo, bool> _filter;

        public GetBoards(IMatchRepository matchRepository, Func<BoardInfo, bool> filter)
        {
            _matchRepository = matchRepository;
            _filter = filter;
        }

        public List<BoardInfo> execute()
        {
            return _matchRepository.getBoards(_filter).ToList();
        }
    }
}