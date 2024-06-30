
using Microsoft.EntityFrameworkCore;
using StaffManager.Domain.Entities;
using StaffManager.Domain.Repositories;
using StaffManager.Infrastructure.Contexts;

namespace StaffManager.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _context;

    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteEmployeeAsync(Employee employee)
    {
        _context.Employees.Remove(employee);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee> GetByIdAsync(int? id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<bool> UpdateEmployeeAsync(Employee employee)
    {
        // Verificando se a entidade já está sendo rastreada
        var trackedEntity = _context.Set<Employee>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(employee.Id));

        // caso não esteja, anexando-a ao contexto
        if (trackedEntity != null)
        {
            _context.Entry(trackedEntity).State = EntityState.Detached;
        }
        _context.Entry(employee).State = EntityState.Modified;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> InactivateEmployeeAsync(Employee employee)
    {
        employee.Active = false;
        employee.ModificationDate = DateTime.UtcNow;
        _context.Employees.Update(employee);
        return await _context.SaveChangesAsync() > 0;
    }
}
