using meShop.SharedKernel.Core.Data;
using meShop.SharedKernel.Persistence.Data;
using meShop.SharedKernel.Persistence.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace meShop.SharedKernel.Persistence;

public static class PersistenceConfiguration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        string databaseConenctionString)
    {
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConenctionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.TryAddSingleton<PublishDomainEventsInterceptor>();

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        return services;
    }
}