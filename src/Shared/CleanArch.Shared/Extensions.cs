using Microsoft.Extensions.DependencyInjection;
using CleanArch.Shared.Services;
using Microsoft.AspNetCore.Builder;
using CleanArch.Shared.Exceptions;

namespace CleanArch.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddHostedService<AppInitializer>();
            services.AddScoped<ExceptionMiddleware>();
            return services;
        }
        public static IApplicationBuilder UseShared(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
