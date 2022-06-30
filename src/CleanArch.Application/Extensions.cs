using CleanArch.Domain.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddSingleton<IUserFactory, UserFactory>();
            return services;
        }
    }
}
