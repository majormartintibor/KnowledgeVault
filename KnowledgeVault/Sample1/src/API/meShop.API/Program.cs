using meShop.API.Extensions;
using meShop.API.Middleware;
using meShop.Modules.Product.Infrastructure;
using meShop.SharedKernel.Core;
using meShop.SharedKernel.Presentation.Endpoints;
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

builder.Services.AddCore([meShop.Modules.Product.Core.AssemblyReference.Assembly]);
builder.Services.AddProductModule();

builder.Configuration.AddModuleConfiguration(["product"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();   
}

app.MapEndpoints();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseHttpsRedirection();

await app.RunAsync();