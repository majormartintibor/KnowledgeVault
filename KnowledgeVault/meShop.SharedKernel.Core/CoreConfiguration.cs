using FluentValidation;
using meShop.SharedKernel.Core.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace meShop.SharedKernel.Core;
public static class CoreConfiguration
{
    public static IServiceCollection AddCore(
        this IServiceCollection services,
        Assembly[] moduleAssemblies)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(moduleAssemblies);

            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

        return services;
    }
}