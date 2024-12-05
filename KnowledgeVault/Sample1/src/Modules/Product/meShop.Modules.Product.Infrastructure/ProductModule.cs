using meShop.Modules.Product.Presentation;
using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.Extensions.DependencyInjection;

namespace meShop.Modules.Product.Infrastructure;
public static class ProductModule
{
    public static IServiceCollection AddProductModule(this IServiceCollection services)
    {
        services.AddEndpoints(AssemblyReference.Assembly);
        return services;
    }
}