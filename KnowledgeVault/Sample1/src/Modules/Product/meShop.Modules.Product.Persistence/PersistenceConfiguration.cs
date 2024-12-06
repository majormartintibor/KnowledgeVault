using meShop.Modules.Product.Core.Abstractions.Data;
using meShop.Modules.Product.Core.Ports.Incoming;
using meShop.Modules.Product.Persistence.Database;
using meShop.Modules.Product.Persistence.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace meShop.Modules.Product.Persistence;
public static class PersistenceConfiguration
{
    public static void AddProductPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string databaseConnectionString
            = configuration.GetConnectionString("Database")!;

        services.AddDbContext<ProductDbContext>(options =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Products))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors());

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ProductDbContext>());

        services.AddScoped<IProductRepository, ProductEntityRepository>();
    }
}