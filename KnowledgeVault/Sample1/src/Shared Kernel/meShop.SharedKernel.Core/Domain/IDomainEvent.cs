using MediatR;

namespace meShop.SharedKernel.Core.Domain;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
    DateTime OccuredOnUtc { get; }
}