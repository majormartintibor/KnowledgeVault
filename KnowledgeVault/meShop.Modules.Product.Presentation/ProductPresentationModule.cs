using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.Extensions.DependencyInjection;

namespace meShop.Modules.Product.Presentation;

//This will need to go in an infrastructure project most likely
public static class ProductPresentationModule
{
    public static IServiceCollection AddProductPresentationModule(this IServiceCollection services)
    {
        services.AddEndpoints(AssemblyReference.Assembly);
        return services;
    }
}