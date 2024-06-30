
using MediatR;
using StaffManager.Application.Models.InputModels;
using StaffManager.Application.Responses;
using StaffManager.Domain.Entities;

namespace StaffManager.Application.Commands.Employees.Create;

public class CreateEmployeeCommand : IRequest<ServiceResponse<Employee>>
{
    public CreateEmployeeCommand(EmployeeInputModel employeeInput)
    {
        EmployeeInput = employeeInput;
    }

    public EmployeeInputModel EmployeeInput { get; set; }
}
