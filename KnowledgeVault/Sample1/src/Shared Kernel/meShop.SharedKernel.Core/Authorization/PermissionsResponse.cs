namespace meShop.SharedKernel.Core.Authorization;
public sealed record PermissionsResponse(Guid UserId, HashSet<string> Permissions);