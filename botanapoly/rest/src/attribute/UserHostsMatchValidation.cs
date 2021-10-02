using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using model;
using rest.service;

namespace rest{
    public class UserHostsMatchValidation : Attribute, IAsyncActionFilter{
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            IMatchRepository repository = Configuration.Instance.MatchRepository;
            IApiKeyStore apiKeyStore = Configuration.Instance.ApiKeyStore;
            HttpRequest request = context.HttpContext.Request;
            if (context.HttpContext.Request.RouteValues.TryGetValue("matchId", out var extractedMatchID))
            {
                if (request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
                {
                    int matchId = int.Parse((string) extractedMatchID);
                    int? userId = apiKeyStore.find(extractedApiKey);
                    if (userId.HasValue)
                    {
                        IEnumerable<MatchInfo> matches = repository.getMatches(match => match.Id.Equals(matchId) && match.HostId.Equals(userId));
                        if (matches.Any())
                        {
                            await next();
                        }
                    }
                }
            }
            context.Result = new ContentResult()
            {
                StatusCode = 404,
                Content = "user is not hosting match"
            };
            return;
        }
    }
}