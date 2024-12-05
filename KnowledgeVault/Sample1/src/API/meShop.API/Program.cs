using meShop.API.Extensions;
using meShop.SharedKernel.Core;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(t => t.FullName?.Replace("+", "."));
});

builder.Services.AddCore([meShop.Modules.Product.Core.AssemblyReference.Assembly]);

builder.Configuration.AddModuleConfiguration([""]);

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

//infra-endpoints
//ProductModule.MapEndpoints(app);

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

await app.RunAsync();