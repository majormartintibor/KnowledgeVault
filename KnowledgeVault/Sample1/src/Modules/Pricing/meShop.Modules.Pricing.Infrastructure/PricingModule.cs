using MassTransit;
using meShop.Modules.Pricing.Persistence;
using meShop.Modules.Pricing.Presentation;
using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace meShop.Modules.Pricing.Infrastructure;

public static class PricingModule
{
    public static IServiceCollection AddPricingModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(AssemblyReference.Assembly);
        services.AddPricingPersistence(configuration);
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