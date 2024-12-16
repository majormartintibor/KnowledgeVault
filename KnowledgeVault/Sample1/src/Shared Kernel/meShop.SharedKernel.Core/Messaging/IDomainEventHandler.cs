using MediatR;
using meShop.SharedKernel.Core.Domain;

namespace meShop.SharedKernel.Core.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;