using MassTransit;
using meShop.Modules.HR.Core.Abstractions.Identity;
using meShop.Modules.HR.Infrastructure.Authorization;
using meShop.Modules.HR.Infrastructure.Identity;
using meShop.Modules.HR.Persistence;
using meShop.Modules.HR.Presentation;
using meShop.SharedKernel.Core.Authorization;
using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace meShop.Modules.HR.Infrastructure;
public static class HRModule
{
    public static IServiceCollection AddHRModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(AssemblyReference.Assembly);
        services.AddHRPersistence(configuration);
        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPermissionService, PermissionService>();

        services.Configure<KeyCloakOptions>(configuration.GetSection("HR:KeyCloak"));

        services.AddTransient<KeyCloakAuthDelegatingHandler>();

        services
            .AddHttpClient<KeyCloakClient>((serviceProvider, httpClient) =>
            {
                KeyCloakOptions keyCloakOptions = serviceProvider
                    .GetRequiredService<IOptions<KeyCloakOptions>>().Value;

                httpClient.BaseAddress = new Uri(keyCloakOptions.AdminUrl);
            })
            .AddHttpMessageHandler<KeyCloakAuthDelegatingHandler>();

        services.AddTransient<IIdentityProviderService, IdentityProviderService>();
    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        //registrationConfigurator.AddConsumer<>();
    }
}