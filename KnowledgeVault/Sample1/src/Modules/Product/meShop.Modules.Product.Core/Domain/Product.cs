using meShop.SharedKernel.Core.Domain;

namespace meShop.Modules.Product.Core.Domain;

public class Product : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    private Product() { }

    public static Result<Product> Create(
        string name)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
        };

        product.Raise(new ProductCreatedDomainEvent(product.Id));

        return product;
    }
}