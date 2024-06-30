
using StaffManager.Domain;
using System.Reflection;

namespace StaffManager.Infrastructure;

#nullable disable
public class ConfigurationDbContext : IConfigurationDbContext
{
    public List<Assembly> Assemblies { get; set; } = new();
}
