using Microsoft.AspNetCore.Routing;

namespace meShop.SharedKernel.Presentation.Endpoints;
public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}