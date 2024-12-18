using meShop.Modules.HR.Core.Abstractions.Data;
using meShop.SharedKernel.Persistence.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using meShop.Modules.HR.Persistence.Database;

namespace meShop.Modules.HR.Persistence;
public static class PersistenceConfiguration
{
    public static void AddHRPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string databaseConnectionString
            = configuration.GetConnectionString("Database")!;

        services.AddDbContext<HRDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.HR))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<HRDbContext>());

        //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
}
