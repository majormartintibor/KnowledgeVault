using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Core.Employees.Domain;

public sealed record EmployeeRegisteredDomainEvent(Guid EmployeeId) : DomainEvent;