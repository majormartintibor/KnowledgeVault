using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Core.Domain;
public class Employee : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    private Employee() { }

    public static Result<Employee> Create(
        string name)
    {
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = name,
        };

        employee.Raise(new EmployeeCreatedDomainEvent(employee.Id));

        return employee;
    }
}
