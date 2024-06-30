
using MediatR;
using StaffManager.Application.Models.ViewModels;
using StaffManager.Application.Responses;
using StaffManager.Domain.Repositories;

namespace StaffManager.Application.Queries.Employees.GetAll;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, ServiceResponse<List<EmployeeViewModel>>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ServiceResponse<List<EmployeeViewModel>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAllAsync();
        
        if (employees == null || !employees.Any()) 
        {
            return new ServiceResponse<List<EmployeeViewModel>>(null, "Funcionários não obtidos.", false);
        }

        var employeeViewModels = employees.Select(e => new EmployeeViewModel(
            e.Id,
            e.Name,
            e.LastName,
            e.Departament,
            e.Active,
            e.Shift,
            e.CreationDate,
            e.ModificationDate)).ToList();

        return new ServiceResponse<List<EmployeeViewModel>>(employeeViewModels, "Funcionários obtidos com sucesso.", true);
    }
}
