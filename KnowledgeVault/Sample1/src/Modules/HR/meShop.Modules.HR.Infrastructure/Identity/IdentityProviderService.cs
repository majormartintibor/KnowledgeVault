using meShop.Modules.HR.Core.Abstractions.Identity;
using meShop.SharedKernel.Core.Domain;
using Microsoft.Extensions.Logging;
using System.Net;

namespace meShop.Modules.HR.Infrastructure.Identity;

internal sealed class IdentityProviderService(KeyCloakClient keyCloakClient, ILogger<IdentityProviderService> logger)
    : IIdentityProviderService
{
    private const string PasswordCredentialType = "Password";

    // POST /admin/realms/{realm}/employees
    public async Task<Result<string>> RegisterEmployeeAsync(EmployeeModel employee, CancellationToken cancellationToken = default)
    {
        var employeeRepresentation = new EmployeeRepresentation(
            employee.Email,
            employee.Email,
            employee.FirstName,
            employee.LastName,
            true,
            true,
            [new CredentialRepresentation(PasswordCredentialType, employee.Password, false)]);

        try
        {
            string identityId = await keyCloakClient.RegisterEmployeeAsync(employeeRepresentation, cancellationToken);

            return identityId;
        }
        catch (HttpRequestException exception) when (exception.StatusCode == HttpStatusCode.Conflict)
        {
            logger.LogError(exception, "Employee registration failed");

            return Result.Failure<string>(IdentityProviderErrors.EmailIsNotUnique);
        }
    }
}