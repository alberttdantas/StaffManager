
using MediatR;
using StaffManager.Application.Responses;
using StaffManager.Domain.Entities;
using StaffManager.Domain.Repositories;

namespace StaffManager.Application.Commands.Employees.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ServiceResponse<Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ServiceResponse<Employee>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.Id);
        var result = await _employeeRepository.DeleteEmployeeAsync(employee);

        if (result)
        {
            return new ServiceResponse<Employee>(employee, "Funcionário deletado com sucesso.", true);
        }

        return new ServiceResponse<Employee>(null, "Falha ao deletar funcionário", false);
    }
}
