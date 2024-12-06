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
        var id = Guid.NewGuid();
        await productRepository.InsertProductAsync(new DomainModels.ProductDOM { Id = id, Name = request.Name });
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return id;
    }
}