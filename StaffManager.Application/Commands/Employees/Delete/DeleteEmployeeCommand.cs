
using MediatR;
using StaffManager.Application.Responses;
using StaffManager.Domain.Entities;

namespace StaffManager.Application.Commands.Employees.Delete;

public class DeleteEmployeeCommand : IRequest<ServiceResponse<Employee>>
{
    public DeleteEmployeeCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
