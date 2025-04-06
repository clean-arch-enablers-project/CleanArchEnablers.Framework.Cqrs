using System.Reflection;
using CleanArchEnablers.Framework.Cqrs.Dispatchers;
using CleanArchEnablers.Framework.Cqrs.Dispatchers.Implementations;
using CleanArchEnablers.Framework.Cqrs.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchEnablers.Framework.Cqrs;

public static class Extensions
{
    private static IServiceCollection AddCommandsHandlers(this IServiceCollection services, Assembly assembly)
    {
        var commandHandlerTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>)))
            .ToList();

        foreach (var handlerType in commandHandlerTypes)
        {
            var interfaces = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<,>))
                .ToList();

            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, handlerType);
            }
        }
        
        return services;
    }
    
    private static IServiceCollection AddQueryHandler(this IServiceCollection services, Assembly assembly)
    {
        var queryHandlerTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
            .ToList();

        foreach (var handlerType in queryHandlerTypes)
        {
            var interfaces = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))
                .ToList();

            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, handlerType);
            }
        }
        
        return services;
    }
    
    public static IServiceCollection AddCaeCqrs(this IServiceCollection services, Assembly assembly)
    {
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        
        services.AddCommandsHandlers(assembly);
        services.AddQueryHandler(assembly);
        
        return services;
    }
}