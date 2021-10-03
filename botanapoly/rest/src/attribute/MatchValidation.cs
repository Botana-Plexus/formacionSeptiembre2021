using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace rest {
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class MatchValidation : Attribute, IAsyncActionFilter{
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.RouteValues.TryGetValue("matchId", out var extractedMatchID))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 404,
                    Content = "Match not found in request"
                };
                return;
            }
            
            context.RouteData.Values.TryGetValue("matchId", out object matchId);
            if (!Configuration.Instance.MatchRepository.getMatches(match => match.Id.Equals(int.Parse((string) matchId))).Any())
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 404,
                    Content = "Match not found in repository"
                };
                return;
            }

            await next();
        }
    }
}