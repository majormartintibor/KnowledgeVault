using meShop.Modules.Product.Core.Abstractions.Data;
using meShop.Modules.Product.Persistence.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace meShop.Modules.Product.Persistence.Database;

public sealed class ProductDbContext(DbContextOptions<ProductDbContext> options) 
    : DbContext(options), IUnitOfWork
{
    internal DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Products);

        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
    }
}