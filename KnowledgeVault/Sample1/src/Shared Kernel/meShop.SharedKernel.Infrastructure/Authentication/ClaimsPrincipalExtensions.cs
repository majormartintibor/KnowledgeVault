using meShop.SharedKernel.Core.Exceptions;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;

namespace meShop.SharedKernel.Infrastructure.Authentication;
public static class ClaimsPrincipalExtensions
{
    public static Guid GetEmployeeId(this ClaimsPrincipal? principal)
    {
        string? employeeId = principal?.FindFirst(CustomClaims.Sub)?.Value;

        return Guid.TryParse(employeeId, out Guid parsedEmployeeId) ?
        parsedEmployeeId :
            throw new MeShopException("Employee identifier is unavailable");
    }

    public static string GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
               throw new MeShopException("Employee identity is unavailable");
    }

    public static HashSet<string> GetPermissions(this ClaimsPrincipal? principal)
    {
        IEnumerable<Claim> permissionClaims = principal?.FindAll(CustomClaims.Permission) ??
                                              throw new MeShopException("Permissions are unavailable");

        return permissionClaims.Select(c => c.Value).ToHashSet();
    }
}