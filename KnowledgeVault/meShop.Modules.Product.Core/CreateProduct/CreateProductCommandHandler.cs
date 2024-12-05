using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.Product.Core.CreateProduct;
internal sealed class CreateProductCommandHandler()
    : ICommandHandler<CreateProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return Guid.NewGuid();
    }
}