using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace rest {
    public class ApiKeyValidationMiddleware {

        private readonly RequestDelegate _next;

        public ApiKeyValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided");
                return;
            }
            
            //TODO: http://codingsonata.com/secure-asp-net-core-web-api-using-api-key-authentication/ in case ApiKey store is used
            await _next(context);
        }
    }
}