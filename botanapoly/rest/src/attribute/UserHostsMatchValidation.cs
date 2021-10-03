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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserHostsMatchValidation : Attribute, IAsyncActionFilter{
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var repository = Configuration.Instance.MatchRepository;
            var apiKeyStore = Configuration.Instance.ApiKeyStore;
            var request = context.HttpContext.Request;
            if (context.HttpContext.Request.RouteValues.TryGetValue("matchId", out var extractedMatchID))
                if (request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
                {
                    var matchId = int.Parse((string) extractedMatchID);
                    var userId = apiKeyStore.find(extractedApiKey);
                    if (userId.HasValue)
                    {
                        var matches = repository.getMatches(match => match.Id.Equals(matchId) && match.HostId.Equals(userId));
                        if (matches.Any()) await next();
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