using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectForEveryTopic.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForEveryTopic.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services)
    {
        string DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
        string DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
        string DB_PASSWORD = Environment.GetEnvironmentVariable("SA_PASSWORD");

        services.AddDbContext<IBookDbContext, BookDbContext>(options =>
        {
            var con = $"Data source={DB_HOST};" +
                            $"Initial Catalog={DB_NAME};" +
                            $"User ID=SA;Password={DB_PASSWORD};" +
                            $"TrustServerCertificate=True;";
            options.UseSqlServer(con);
        });
        return services;
    }
}
