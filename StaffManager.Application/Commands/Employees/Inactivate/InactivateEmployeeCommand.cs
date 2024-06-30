
using MediatR;
using StaffManager.Application.Responses;
using StaffManager.Domain.Entities;

namespace StaffManager.Application.Commands.Employees.Inactivate;

public class InactivateEmployeeCommand : IRequest<ServiceResponse<Employee>>
{
    public InactivateEmployeeCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
