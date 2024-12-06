using meShop.Modules.Product.Core.DomainModels;
using meShop.Modules.Product.Core.Ports.Incoming;
using meShop.Modules.Product.Persistence.Database;

namespace meShop.Modules.Product.Persistence.Entities.Product;

internal class ProductEntityRepository(ProductDbContext context) : IProductRepository
{
    public async Task InsertProductAsync(ProductDOM product)
    {
        await context.AddAsync(new ProductEntity { Id = product.Id, Name = product.Name });
    }
}