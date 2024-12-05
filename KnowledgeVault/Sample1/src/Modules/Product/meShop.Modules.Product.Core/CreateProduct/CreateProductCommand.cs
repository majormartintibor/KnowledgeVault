using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.Product.Core.CreateProduct;
public sealed record CreateProductCommand(string Name) : ICommand<Guid>;