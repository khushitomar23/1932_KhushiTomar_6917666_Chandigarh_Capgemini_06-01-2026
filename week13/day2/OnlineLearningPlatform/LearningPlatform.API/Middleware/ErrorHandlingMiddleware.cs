using System.Net;
using System.Text.Json;

namespace LearningPlatform.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode == 404)
                {
                    context.Response.ContentType = "application/json";
                    var response = JsonSerializer.Serialize(new { error = "Resource not found" });
                    await context.Response.WriteAsync(response);
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var response = JsonSerializer.Serialize(new { error = "An unexpected error occurred", detail = ex.Message });
                await context.Response.WriteAsync(response);
            }
        }
    }
}