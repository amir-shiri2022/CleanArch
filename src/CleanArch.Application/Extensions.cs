using CleanArch.Domain.Factories;
using CleanArch.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddCommands();

            services.AddSingleton<IUserFactory, UserFactory>();
            return services;
        }
    }
}
