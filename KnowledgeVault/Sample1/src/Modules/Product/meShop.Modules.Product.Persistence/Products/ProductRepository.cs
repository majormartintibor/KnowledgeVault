using meShop.Modules.Product.Core.Ports.Incoming;
using meShop.Modules.Product.Persistence.Database;

namespace meShop.Modules.Product.Persistence.Products;

internal class ProductRepository(ProductDbContext context) : IProductRepository
{
    public async Task InsertProductAsync(Core.Domain.Product product)
    {
        await context.AddAsync(product);
    }
}