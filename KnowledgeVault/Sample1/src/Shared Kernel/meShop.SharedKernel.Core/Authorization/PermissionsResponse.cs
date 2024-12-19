namespace meShop.SharedKernel.Core.Authorization;
public sealed record PermissionsResponse(Guid EmployeeId, HashSet<string> Permissions);