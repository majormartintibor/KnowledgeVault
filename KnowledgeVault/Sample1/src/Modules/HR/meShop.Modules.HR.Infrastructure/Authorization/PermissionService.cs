using MediatR;
using meShop.Modules.HR.Core.Employees.GetEmployeePermissions;
using meShop.SharedKernel.Core.Authorization;
using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Infrastructure.Authorization;
internal sealed class PermissionService(ISender sender) : IPermissionService
{
    public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
    {
        return await sender.Send(new GetEmployeePermissionsQuery(identityId));
    }
}
