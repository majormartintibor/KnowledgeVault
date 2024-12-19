using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Core.Employees.Domain;
public sealed record EmployeeProfileUpdatedDomainEvent(
    Guid UserId, 
    string FirstName, 
    string LastName) 
    : DomainEvent;