using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure.EF.Context;
using CleanArch.Infrastructure.EF.Options;
using CleanArch.Infrastructure.EF.Repositories;
using CleanArch.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.EF
{
    public static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            var options = configuration.GetOptions<PostgresOptions>("Postgres");
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));

            return services;
        }
    }
}
