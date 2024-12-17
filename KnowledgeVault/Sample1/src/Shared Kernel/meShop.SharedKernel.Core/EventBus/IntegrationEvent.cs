namespace meShop.SharedKernel.Core.EventBus;

public abstract record IntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; init; }

    public DateTime OccuredOnUtc { get; init; }

    protected IntegrationEvent(Guid id, DateTime occuredOnUtc)
    {
        Id = id;
        OccuredOnUtc = occuredOnUtc;
    }
}
