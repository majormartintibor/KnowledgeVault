using MediatR;
using meShop.Modules.Product.Core.CreateProduct;
using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Presentation.ApiResults;
using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace meShop.Modules.Product.Presentation.ProductCreation;

internal sealed record Request(string Name);

internal class CreateProduct : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("product", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(
                new CreateProductCommand(request.Name));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Product);
    }
}