using meShop.Modules.HR.Core.Employees.Domain;

namespace meShop.Modules.HR.Core.Employees.Ports.Incomming;

public interface IEmployeeRepository
{
    Task<Employee?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Employee employee);
}