using meShop.Modules.Product.Core.Abstractions.Data;
using meShop.Modules.Product.Core.Ports.Incoming;
using meShop.SharedKernel.Core.Domain;
using meShop.SharedKernel.Core.Messaging;

namespace meShop.Modules.Product.Core.CreateProduct;
internal sealed class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateProductCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        CreateProductCommand request, 
        CancellationToken cancellationToken)
    {
        Result<Domain.Product> result = Domain.Product.Create(request.Name);

        if (result.IsFailure)
        {
            return Result.Failure<Guid>(result.Error);
        }
        
        await productRepository.InsertProductAsync(result.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}