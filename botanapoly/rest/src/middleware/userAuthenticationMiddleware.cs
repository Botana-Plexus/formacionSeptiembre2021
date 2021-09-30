using System.Threading.Tasks;
using database;
using Microsoft.AspNetCore.Http;

namespace rest.middleware{
    public class userAuthenticationMiddleware : AbstractMiddleWare{
        private readonly IMatchRepository _matchRepository;
        
        public userAuthenticationMiddleware(RequestDelegate next, IMatchRepository matchRepository) : base(next)
        {
            _matchRepository = matchRepository;
        }

        public override Task Invoke(HttpContext context)
        {
            context.Request.Headers.ContainsKey("apiKey")
            return base.Invoke(context);
        }
    }
}