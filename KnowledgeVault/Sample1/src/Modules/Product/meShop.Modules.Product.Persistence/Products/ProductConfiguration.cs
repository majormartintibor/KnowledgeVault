using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace meShop.Modules.Product.Persistence.Products;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Core.Domain.Product>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Product> builder)
    {
        builder.ToTable("Products");
    }
}