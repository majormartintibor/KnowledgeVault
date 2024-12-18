using meShop.SharedKernel.Core.Authorization;
using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.HR.Core.Employees.GetEmployeePermissions;
public sealed record GetEmployeePermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;