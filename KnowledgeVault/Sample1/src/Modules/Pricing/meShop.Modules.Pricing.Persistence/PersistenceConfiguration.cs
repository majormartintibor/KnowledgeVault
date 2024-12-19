using meShop.Modules.Pricing.Core.Abstractions.Data;
using meShop.Modules.Pricing.Persistence.Database;
using meShop.SharedKernel.Persistence.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace meShop.Modules.Pricing.Persistence;

public static class PersistenceConfiguration
{
    public static void AddPricingPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string databaseConnectionString
            = configuration.GetConnectionString("Database")!;

        services.AddDbContext<PricingDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Pricing))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<PricingDbContext>());

        //services.AddScoped<IRepository, Repository>();
    }
}