using Dapper;
using meShop.Modules.HR.Core.Employees.Domain;
using meShop.SharedKernel.Core.Authorization;
using meShop.SharedKernel.Core.Data;
using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Core.Messaging;
using System.Data.Common;

namespace meShop.Modules.HR.Core.Employees.GetEmployeePermissions;

internal sealed class GetEmployeePermissionsQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetEmployeePermissionsQuery, PermissionsResponse>
{
    public async Task<Result<PermissionsResponse>> Handle(
        GetEmployeePermissionsQuery request,
        CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT DISTINCT
                 u.id AS {nameof(EmployeePermission.EmployeeId)},
                 rp.permission_code AS {nameof(EmployeePermission.Permission)}
             FROM hr.employees u
             JOIN hr.employee_roles ur ON ur.employee_id = u.id
             JOIN hr.role_permissions rp ON rp.role_name = ur.role_name
             WHERE u.identity_id = @IdentityId
             """;

        List<EmployeePermission> permissions = (await connection.QueryAsync<EmployeePermission>(sql, request)).AsList();

        if (!permissions.Any())
        {
            return Result.Failure<PermissionsResponse>(EmployeeErrors.NotFound(request.IdentityId));
        }

        return new PermissionsResponse(permissions[0].EmployeeId, permissions.Select(p => p.Permission).ToHashSet());
    }

    internal sealed class EmployeePermission
    {
        internal Guid EmployeeId { get; init; }

        internal string Permission { get; init; } = string.Empty;
    }
}