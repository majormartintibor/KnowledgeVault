namespace meShop.SharedKernel.Core.EventBus;

public interface IIntegrationEvent
{
    Guid Id { get; }
    DateTime OccuredOnUtc { get; }
}