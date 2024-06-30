using StaffManager.Domain.Entities;

namespace StaffManager.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync();
    Task<Employee> GetByIdAsync(int? id);
    Task<bool> CreateEmployeeAsync(Employee employee);
    Task<bool> DeleteEmployeeAsync(Employee employee);
    Task<bool> UpdateEmployeeAsync(Employee employee);
    Task<bool> InactivateEmployeeAsync(Employee employee);
}
