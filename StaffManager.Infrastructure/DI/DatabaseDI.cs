
using StaffManager.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StaffManager.Infrastructure.DI;

public static class DatabaseDI
{
    public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<EmployeeDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}
