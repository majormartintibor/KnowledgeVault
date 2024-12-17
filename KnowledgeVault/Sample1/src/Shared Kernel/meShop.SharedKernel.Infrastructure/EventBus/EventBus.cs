using MassTransit;
using meShop.SharedKernel.Core.EventBus;

namespace meShop.SharedKernel.Infrastructure.EventBus;

internal sealed class EventBus(IBus bus) : IEventBus
{
    public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken)
        where T : IIntegrationEvent
    {
        await bus.Publish(integrationEvent, cancellationToken);        
    }
}