using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace meShop.Modules.HR.Persistence.Employees;

internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Core.Domain.Employee>
{
    public void Configure(EntityTypeBuilder<Core.Domain.Employee> builder)
    {
        builder.ToTable("Employees");
    }
}