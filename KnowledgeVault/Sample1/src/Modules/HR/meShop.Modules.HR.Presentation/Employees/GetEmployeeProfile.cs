using MediatR;
using meShop.Modules.HR.Core.Employees.GetEmployee;
using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Infrastructure.Authentication;
using meShop.SharedKernel.Presentation.ApiResults;
using meShop.SharedKernel.Presentation.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;

namespace meShop.Modules.HR.Presentation.Employees;

internal sealed class GetEmployeeProfile : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("employees/profile", async (ClaimsPrincipal claims, ISender sender) =>
        {
            Result<EmployeeResponse> result = await sender.Send(new GetEmployeeQuery(claims.GetEmployeeId()));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .RequireAuthorization("employees:read")
        .WithTags(Tags.HR);
    }
}