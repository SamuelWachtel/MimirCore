using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace MimirCore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        // Note: Service implementations and other dependencies (FluentValidation, AutoMapper) 
        // will be registered in the Infrastructure layer
        // This file only contains the basic application layer configuration

        return services;
    }
}