
using MediatR;
using StaffManager.Application.Responses;
using StaffManager.Domain.Entities;
using StaffManager.Domain.Repositories;

namespace StaffManager.Application.Commands.Employees.Inactivate;

public class InactivateEmployeeCommandHandler : IRequestHandler<InactivateEmployeeCommand, ServiceResponse<Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public InactivateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ServiceResponse<Employee>> Handle(InactivateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.Id);

        if (employee == null)
        {
            return new ServiceResponse<Employee>(null, "Funcionário não encontrado.", false);
        }

        var success = await _employeeRepository.InactivateEmployeeAsync(employee);

        if (!success)
        {
            return new ServiceResponse<Employee>(null, "Erro ao inativar o funcionário.", false);
        }

        return new ServiceResponse<Employee>(employee, "Funcionário inativado com sucesso.", true);

        // Após a inativação, obtenha a lista atualizada de todos os funcionários
        //var employees = await _employeeRepository.GetAllAsync();

        //return new ServiceResponse<List<Employee>>(employees, "Funcionário inativado com sucesso e lista de funcionários atualizada.", true);
    }

}
