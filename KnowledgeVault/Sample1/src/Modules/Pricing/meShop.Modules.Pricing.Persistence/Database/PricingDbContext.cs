using meShop.Modules.Pricing.Core.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace meShop.Modules.Pricing.Persistence.Database;

public sealed class PricingDbContext(DbContextOptions<PricingDbContext> options)
    : DbContext(options), IUnitOfWork
{
    //internal DbSet<>  { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Pricing);

        //modelBuilder.ApplyConfiguration();
    }
}