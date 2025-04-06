using CleanArchEnablers.Framework.Cqrs.Dispatchers;
using CleanArchEnablers.Framework.Cqrs.Dispatchers.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchEnablers.Framework.Cqrs;

public static class Extensions
{
    public static IServiceCollection AddCaeCqrs(this IServiceCollection services)
    {
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        
        return services;
    }
}