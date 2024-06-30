
using MediatR;
using StaffManager.Application.Responses;
using StaffManager.Domain.Entities;
using StaffManager.Domain.Repositories;

namespace StaffManager.Application.Commands.Employees.Update;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ServiceResponse<Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ServiceResponse<Employee>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var existingEmployee = await _employeeRepository.GetByIdAsync(request.Id);
        if (existingEmployee == null)
        {
            return new ServiceResponse<Employee>(null, "Funcionário não encontrado.", false);
        }

        // Atualizando os campos da entidade existente com os valores do inputModel
        existingEmployee.Name = request.EmployeeInput.Name;
        existingEmployee.LastName = request.EmployeeInput.LastName;
        existingEmployee.Departament = request.EmployeeInput.Departament;
        existingEmployee.Active = request.EmployeeInput.Active;
        existingEmployee.Shift = request.EmployeeInput.Shift;
        existingEmployee.ModificationDate = DateTime.Now.ToLocalTime();

        // Chamando UpdateEmployeeAsync com a entidade existente
        var result = await _employeeRepository.UpdateEmployeeAsync(existingEmployee);

        if (result)
        {
            return new ServiceResponse<Employee>(existingEmployee, "Funcionário atualizado com sucesso.", true);
        }
        else
        {
            return new ServiceResponse<Employee>(existingEmployee, "Falha ao atualizar o funcionário.", false);
        }
    }
}
