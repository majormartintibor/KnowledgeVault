using HealthChecks.UI.Client;
using meShop.API.Extensions;
using meShop.API.Middleware;
using meShop.Modules.HR.Infrastructure;
using meShop.Modules.Pricing.Infrastructure;
using meShop.Modules.Product.Infrastructure;
using meShop.SharedKernel.Core;
using meShop.SharedKernel.Infrastructure;
using meShop.SharedKernel.Persistence;
using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowDevelopmentOrigin", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;

builder.Services.AddCore([
    meShop.Modules.HR.Core.AssemblyReference.Assembly,    
    meShop.Modules.Pricing.Core.AssemblyReference.Assembly,
    meShop.Modules.Product.Core.AssemblyReference.Assembly
   ]);

builder.Services.AddInfrastructure(
    [
        HRModule.ConfigureConsumers,
        PricingModule.ConfigureConsumers,
        ProductModule.ConfigureConsumers,        
    ]);

builder.Services.AddPersistence(databaseConnectionString);

builder.Services.AddHRModule(builder.Configuration);
builder.Services.AddPricingModule(builder.Configuration);
builder.Services.AddProductModule(builder.Configuration);

builder.Configuration.AddModuleConfiguration(
    [         
        "hr", 
        "pricing",
        "product"
    ]);

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddUrlGroup(new Uri(builder.Configuration.GetValue<string>("KeyCloak:HealthUrl")!), HttpMethod.Get, "keycloak");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowDevelopmentOrigin");
    app.ApplyMigrations();
}

app.MapEndpoints();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

await app.RunAsync();