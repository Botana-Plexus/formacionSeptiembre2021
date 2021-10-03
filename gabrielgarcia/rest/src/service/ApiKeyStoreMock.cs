using System;
using System.Collections.Generic;
using System.Linq;
using database;
using model;
using rest.service;

namespace rest{
    public class ApiKeyStoreMock : IApiKeyStore{
        private readonly Dictionary<string, int> store;
        private readonly IMatchRepository _matchRepository;

        public ApiKeyStoreMock(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
            store = new Dictionary<string, int>();
        }

        public Dictionary<string, int> findAll(Func<string, bool> filter)
        {
            return store.Where(pair => filter(pair.Key)).ToDictionary(i => i.Key, i => i.Value);
        }

        public int? find(string apiKey)
        {
            return store.ContainsKey(apiKey) ? store[apiKey] : null;
        }

        public int? register(string apiKey, int userId)
        {
            int? result = null;
            if (!store.ContainsKey(apiKey))
            {
                store[apiKey] = userId;
                result = userId;
            }

            return result;
        }
    }
}