using Microsoft.Extensions.DependencyInjection;
using StaffManager.Domain.Repositories;
using StaffManager.Infrastructure.Repositories;

namespace StaffManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddLibs(this IServiceCollection services, ConfigurationDbContext configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(configuration.Assemblies.ToArray());
        });

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}
