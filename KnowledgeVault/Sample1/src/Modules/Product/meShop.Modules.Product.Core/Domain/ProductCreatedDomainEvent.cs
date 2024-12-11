using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.Product.Core.Domain;
public record ProductCreatedDomainEvent(Guid ProductId) : DomainEvent;