using Microsoft.Extensions.DependencyInjection;
using CleanArch.Shared.Services;
using Microsoft.AspNetCore.Builder;

namespace CleanArch.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
           services.AddHostedService<AppInitializer>();

            return services;
        }
        public static IApplicationBuilder UseShared(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
