using System;
using System.Collections.Generic;
using model;

namespace rest.service{
    public interface IApiKeyStore{

        Dictionary<string, int> findAll(Func<string, bool> filter);
        int? find(string apiKey);
        int? register(string apiKey, int userId);
    }
}