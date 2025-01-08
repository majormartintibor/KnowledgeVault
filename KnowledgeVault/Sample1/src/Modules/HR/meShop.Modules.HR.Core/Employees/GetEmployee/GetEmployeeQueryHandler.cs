using Dapper;
using meShop.Modules.HR.Core.Employees.Domain;
using meShop.SharedKernel.Core.Data;
using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Core.Messaging;
using System.Data.Common;

namespace meShop.Modules.HR.Core.Employees.GetEmployee;

public sealed class GetEmployeeQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetEmployeeQuery, EmployeeResponse>
{
    public async Task<Result<EmployeeResponse>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
            SELECT
                id AS {nameof(EmployeeResponse.EmployeeId)},
                email AS {nameof(EmployeeResponse.Email)},
                first_name AS {nameof(EmployeeResponse.FirstName)},
                last_name AS {nameof(EmployeeResponse.LastName)}
            FROM hr.Employees
            WHERE id = @EmployeeId
            """;

        EmployeeResponse? employee = await connection.QuerySingleOrDefaultAsync<EmployeeResponse>(sql, request);

        if (employee == null)
        {
            return Result.Failure<EmployeeResponse>(EmployeeErrors.NotFound(request.EmployeeId));
        }

        return employee;
    }
}
