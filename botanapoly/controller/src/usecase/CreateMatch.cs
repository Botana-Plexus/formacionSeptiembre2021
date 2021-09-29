using System;
using System.Collections.Generic;
using database;
using model;

namespace controller{
    public class CreateMatch : IUseCaseFunctionality<MatchInfo>{
        private readonly IMatchRepository matchRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly PlayerInfo hostPlayer;
        private readonly MatchTemplateInfo matchTemplateInfo;
        private readonly bool visibility;
        private readonly long hash;
        private readonly Dictionary<string, object> matchTemplateConfiguration;

        public CreateMatch(IMatchRepository matchRepository, IPlayerRepository playerRepository, PlayerInfo hostPlayer, MatchTemplateInfo matchTemplate, bool visibility, long hash, Dictionary<string, object> matchTemplateConfiguration)
        {
            this.matchRepository = matchRepository;
            this.playerRepository = playerRepository;
            this.hostPlayer = hostPlayer;
            matchTemplateInfo = matchTemplate;
            this.visibility = visibility;
            this.hash = hash;
            this.matchTemplateConfiguration = matchTemplateConfiguration;
        }

        public MatchInfo execute()
        {
            MatchInfo matchInfo;
            if (!playerRepository.exists(hostPlayer)) throw new NullReferenceException();

            matchInfo = new MatchInfo();
            matchInfo.hash = hash;
            matchInfo.visibility = visibility;
            matchInfo.host = hostPlayer;
            matchInfo.matchTemplateInfo = matchTemplateInfo;
            matchInfo = matchRepository.saveOrUpdate(matchInfo);
            if (matchInfo == null) throw new NullReferenceException();

            return matchInfo;
        }
    }
}