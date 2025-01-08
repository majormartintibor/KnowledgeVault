using meShop.SharedKernel.Core.EventBus;

namespace meShop.Modules.HR.IntegrationEvents;

public sealed record EmployeeRegisteredIntegrationEvent : IntegrationEvent
{
    public EmployeeRegisteredIntegrationEvent(
        Guid id,
        DateTime occuredOnUtc,
        Guid employeeId,
        string email,
        string firstName,
        string lastName)
        : base(id, occuredOnUtc)
    {
        EmployeeId = employeeId;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public Guid EmployeeId { get; init; }
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}