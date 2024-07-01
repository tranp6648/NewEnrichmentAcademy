using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EnrichmentAcademy.Midlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckOTPMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckOTPMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,Services.AccoutService accoutService)
        {
            await accoutService.UpdateOTP();
           await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckOTPMiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckOTPMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckOTPMiddleware>();
        }
    }
}
