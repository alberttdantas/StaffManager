
using MediatR;
using StaffManager.Application.Responses;
using StaffManager.Domain.Entities;
using StaffManager.Domain.Repositories;

namespace StaffManager.Application.Commands.Employees.Create;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ServiceResponse<Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ServiceResponse<Employee>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = request.EmployeeInput.ToEntity();
        var result = await _employeeRepository.CreateEmployeeAsync(employee);

        if (result)
        {
            return new ServiceResponse<Employee>(employee, "Funcionário criado com sucesso.", true);
        }

        return new ServiceResponse<Employee>(null, "Falha ao criar o funcionário.", false);
    }
}
