using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.Product.Core.Domain;
public sealed record ProductCreatedDomainEvent(Guid ProductId) : DomainEvent;