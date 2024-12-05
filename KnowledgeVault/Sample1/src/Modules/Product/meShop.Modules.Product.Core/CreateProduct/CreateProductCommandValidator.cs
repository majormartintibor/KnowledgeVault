using FluentValidation;

namespace meShop.Modules.Product.Core.CreateProduct;
internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}