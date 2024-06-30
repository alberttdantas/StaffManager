
using MediatR;
using StaffManager.Application.Models.InputModels;
using StaffManager.Application.Responses;
using StaffManager.Domain.Entities;

namespace StaffManager.Application.Commands.Employees.Update;

public class UpdateEmployeeCommand : IRequest<ServiceResponse<Employee>>
{
    public UpdateEmployeeCommand(EmployeeInputModel? employeeInput, int id)
    {
        EmployeeInput = employeeInput;
        Id = id;
    }

    public int Id { get; set; }
    public EmployeeInputModel? EmployeeInput { get; set; }
}
