using System;
using System.Collections.Generic;
using System.Linq;
using database;
using model;
using rest.service;

namespace rest {
    public class ApiKeyStoreMock : IApiKeyStore{

        private readonly Dictionary<string, UserInfo> store;
        private readonly IMatchRepository _matchRepository;

        public ApiKeyStoreMock(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
            this.store = new Dictionary<string, UserInfo>()
            {
                {"asda1sda1sd", _matchRepository.getUsers(user => user.Id.Equals(1)).First()},
                {"asda1sda2sd", _matchRepository.getUsers(user => user.Id.Equals(2)).First()}
            };
        }

        public Dictionary<string, UserInfo> findAll(Func<string, bool> filter)
        {
            return store.Where(pair => filter(pair.Key)).ToDictionary(i => i.Key, i => i.Value);
        }

        public UserInfo find(string apiKey)
        {
            return store.ContainsKey(apiKey) ? store[apiKey] : null;
        }

        public UserInfo register(string apiKey, UserInfo userInfo)
        {
            store[apiKey] = userInfo;
            return store[apiKey];
        }
    }
}