using Microsoft.Extensions.DependencyInjection;
using ProjectForEveryTopic.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForEveryTopic.Application;
public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services)
    {
        services.AddTransient<IBookService, BookService>();
        return services;
    }
}
