using meShop.Modules.HR.Core.Employees.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace meShop.Modules.HR.Persistence.Employees;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.HasKey(r => r.Name);

        builder.Property(r => r.Name).HasMaxLength(50);

        builder
            .HasMany<Employee>()
            .WithMany(u => u.Roles)
            .UsingEntity(joinBuilder =>
            {
                joinBuilder.ToTable("employee_roles");

                joinBuilder.Property("RolesName").HasColumnName("role_name");
            });

        builder.HasData(
            Role.Example);
    }
}