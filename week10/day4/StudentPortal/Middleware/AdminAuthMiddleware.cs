using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace StudentPortal.Middleware
{
    public class AdminAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if request is for Admin section
            if (context.Request.Path.StartsWithSegments("/Admin"))
            {
                // Check authentication
                if (!context.Session.Keys.Contains("User"))
                {
                    context.Response.Redirect("/Home/Login");
                    return;
                }
            }

            await _next(context);
        }
    }
}

