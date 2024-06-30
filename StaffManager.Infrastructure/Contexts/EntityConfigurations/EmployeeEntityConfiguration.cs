

using StaffManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StaffManager.Infrastructure.Contexts.EntityConfigurations;

public class EmployeeEntityConfiguration
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);

        builder.Property(e => e.Departament).IsRequired();
        builder.Property(e => e.Active).IsRequired();
        builder.Property(e => e.Shift).IsRequired();
        builder.Property(e => e.CreationDate).IsRequired();
        builder.Property(e => e.ModificationDate).IsRequired();
    }
}
