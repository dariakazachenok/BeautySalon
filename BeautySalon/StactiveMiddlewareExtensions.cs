using Microsoft.AspNetCore.Builder;

namespace BeautySalon
{
    public static class StactiveMiddlewareExtensions
    {
        public static IApplicationBuilder UseStactive(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StactiveMiddleware>();
        }
    }
}
