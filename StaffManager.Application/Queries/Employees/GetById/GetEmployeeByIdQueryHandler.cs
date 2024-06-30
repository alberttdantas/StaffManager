
using MediatR;
using StaffManager.Application.Models.ViewModels;
using StaffManager.Application.Responses;
using StaffManager.Domain.Repositories;

namespace StaffManager.Application.Queries.Employees.GetById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, ServiceResponse<EmployeeViewModel>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ServiceResponse<EmployeeViewModel>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.Id);

        if (employee == null)
        {
            return new ServiceResponse<EmployeeViewModel>(null, "Funcionário não encontrado.", false);
        }

        var employeeViewModel = new EmployeeViewModel(
            employee.Id,
            employee.Name,
            employee.LastName,
            employee.Departament,
            employee.Active,
            employee.Shift,
            employee.CreationDate,
            employee.ModificationDate);

        return new ServiceResponse<EmployeeViewModel>(employeeViewModel, "Funcionário obtido com sucesso.", true);
    }
}
