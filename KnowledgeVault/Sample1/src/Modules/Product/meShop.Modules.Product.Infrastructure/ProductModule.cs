﻿using MassTransit;
using meShop.Modules.Product.Persistence;
using meShop.Modules.Product.Presentation;
using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace meShop.Modules.Product.Infrastructure;
public static class ProductModule
{
    public static IServiceCollection AddProductModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(AssemblyReference.Assembly);
        services.AddProductPersistence(configuration);
        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        //registrationConfigurator.AddConsumer<>();
    }
}