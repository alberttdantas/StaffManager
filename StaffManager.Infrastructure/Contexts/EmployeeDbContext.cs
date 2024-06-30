
using StaffManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StaffManager.Infrastructure.Contexts;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext>options) : base(options)
    {

    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(EmployeeDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
