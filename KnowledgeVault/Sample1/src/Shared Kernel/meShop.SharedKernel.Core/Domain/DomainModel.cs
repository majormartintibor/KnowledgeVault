namespace meShop.SharedKernel.Core.Domain;

public abstract class DomainModel
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected DomainModel()
    {

    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => [.. _domainEvents];

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}