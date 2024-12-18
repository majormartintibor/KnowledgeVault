using meShop.Modules.HR.Core.Abstractions.Data;
using meShop.Modules.HR.Persistence.Employees;
using Microsoft.EntityFrameworkCore;

namespace meShop.Modules.HR.Persistence.Database;

public sealed class HRDbContext(DbContextOptions<HRDbContext> options)
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Core.Domain.Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.HR);

        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }}
