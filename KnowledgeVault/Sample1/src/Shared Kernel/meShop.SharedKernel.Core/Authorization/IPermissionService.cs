using meShop.SharedKernel.Core.Domain;

namespace meShop.SharedKernel.Core.Authorization;
public interface IPermissionService
{
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
}