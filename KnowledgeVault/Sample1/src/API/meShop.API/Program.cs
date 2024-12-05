using meShop.API.Extensions;
using meShop.API.Middleware;
using meShop.Modules.Product.Presentation;
using meShop.SharedKernel.Presentation.Endpoints;
using meShop.SharedKernel.Core;
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
builder.Services.AddProductPresentationModule();

builder.Configuration.AddModuleConfiguration(["product"]);

//infra-persistence
//builder.Services.AddProductModule(builder.Configuration);

//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
}

app.MapEndpoints();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.UseHttpsRedirection();

await app.RunAsync();