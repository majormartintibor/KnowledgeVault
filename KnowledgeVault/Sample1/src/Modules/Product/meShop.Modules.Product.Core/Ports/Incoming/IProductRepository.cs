namespace meShop.Modules.Product.Core.Ports.Incoming;

public interface IProductRepository
{
    Task InsertProductAsync(Domain.Product product);
}