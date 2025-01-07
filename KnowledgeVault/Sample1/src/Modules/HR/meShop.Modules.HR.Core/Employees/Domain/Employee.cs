using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Core.Employees.Domain;

public class Employee : Entity
{
    private readonly List<Role> _roles = [];

    public Guid Id { get; private set; }    
    public string Email { get; private set; } = string.Empty;

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Name => FirstName + " " + LastName;

    public string IdentityId { get; private set; } = string.Empty;

    public IReadOnlyCollection<Role> Roles => [.. _roles];

    private Employee() { }

    public static Employee Create(        
        string email, 
        string firstName, 
        string lastName, 
        string identityId)
    {
        var employee = new Employee
        {
            Id = Guid.NewGuid(),           
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            IdentityId = identityId
        };

        employee._roles.Add(Role.Example);

        employee.Raise(new EmployeeRegisteredDomainEvent(employee.Id));

        return employee;
    }

    public void Update(string firstName, string lastName)
    {
        if (FirstName == firstName && LastName == lastName)
        {
            return;
        }

        FirstName = firstName;
        LastName = lastName;

        Raise(new EmployeeProfileUpdatedDomainEvent(Id, FirstName, LastName));
    }
}