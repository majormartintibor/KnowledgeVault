using meShop.Modules.Product.Core.DomainModels;

namespace meShop.Modules.Product.Core.Ports.Incoming;

public interface IProductRepository
{
    Task InsertProductAsync(ProductDOM product);
}