using System;
using System.Collections.Generic;
using model;

namespace rest.service{
    public interface IApiKeyStore{

        Dictionary<string, UserInfo> findAll(Func<string, bool> filter);
        UserInfo find(string apiKey);
        UserInfo register(string apiKey, UserInfo userInfo);
    }
}