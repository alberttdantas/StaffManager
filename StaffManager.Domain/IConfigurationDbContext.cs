
using System.Reflection;

namespace StaffManager.Domain;

public interface IConfigurationDbContext
{
    public List<Assembly> Assemblies { get; set; }
}
