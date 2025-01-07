using meShop.Modules.HR.Core.Employees.Domain;
using meShop.Modules.HR.Core.Employees.Ports.Incomming;
using meShop.Modules.HR.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace meShop.Modules.HR.Persistence.Employees;

internal sealed class EmployeeRepository(HRDbContext context) : IEmployeeRepository
{
    public async Task<Employee?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Employees.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public void Insert(Employee employee)
    {
        foreach (var role in employee.Roles)
        {
            context.Attach(role);
        }

        context.Employees.Add(employee);
    }
}