
using MediatR;
using StaffManager.Application.Models.ViewModels;
using StaffManager.Application.Responses;

namespace StaffManager.Application.Queries.Employees.GetById;

public class GetEmployeeByIdQuery : IRequest<ServiceResponse<EmployeeViewModel>>
{
    public int Id { get; set; }

    public GetEmployeeByIdQuery(int id)
    {
        Id = id;
    }
}
