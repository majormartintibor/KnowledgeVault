using meShop.Modules.Product.Core.Domain;
using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.Product.Core.CreateProduct;
internal sealed class ProductCreatedDomainEventHandler : IDomainEventHandler<ProductCreatedDomainEvent>
{
    public Task Handle(ProductCreatedDomainEvent domainEvent, CancellationToken  cancellationToken)
    {
        Console.WriteLine("Product with ID {id} has been created!", domainEvent.Id);
        return Task.CompletedTask;
    }
}