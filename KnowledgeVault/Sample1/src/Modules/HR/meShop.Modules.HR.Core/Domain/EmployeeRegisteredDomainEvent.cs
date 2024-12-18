using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.HR.Core.Domain;

public sealed record EmployeeRegisteredDomainEvent(Guid UserId) : DomainEvent;