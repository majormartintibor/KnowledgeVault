namespace meShop.SharedKernel.Core.Domain;
public interface IDomainEvent
{
    Guid Id { get; }
    DateTime OccuredOnUtc { get; }
}