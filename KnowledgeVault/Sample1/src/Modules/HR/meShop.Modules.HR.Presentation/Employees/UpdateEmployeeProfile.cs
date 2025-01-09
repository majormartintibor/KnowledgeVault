using MediatR;
using meShop.Modules.HR.Core.Employees.UpdateEmployee;
using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Presentation.ApiResults;
using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace meShop.Modules.HR.Presentation.Employees;

internal sealed class UpdateEmployeeProfile : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("employees/{id}/profile", async (Guid id, Request request, ISender sender) =>
        {
            Result result = await sender.Send(new UpdateEmployeeCommand(
                id,
                request.FirstName,
                request.LastName));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
        .RequireAuthorization("employees:write")
        .WithTags(Tags.HR);
    }


    internal sealed record Request(string FirstName,  string LastName); 
}
