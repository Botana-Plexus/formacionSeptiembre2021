using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace rest.middleware{
    public abstract class AbstractMiddleWare {
        
        private readonly RequestDelegate _next;

        public AbstractMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public virtual async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}