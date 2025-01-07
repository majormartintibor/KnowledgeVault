using MediatR;
using meShop.Modules.HR.Core.Employees.RegisterEmployee;
using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Presentation.ApiResults;
using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace meShop.Modules.HR.Presentation.Employees;

internal sealed class RegisterEmployee : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("employees/register", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(new RegisterEmployeeCommand(
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .AllowAnonymous()
        .WithTags(Tags.HR);
    }
}

internal sealed record Request(
    string Email,
    string Password,
    string FirstName,
    string LastName);
