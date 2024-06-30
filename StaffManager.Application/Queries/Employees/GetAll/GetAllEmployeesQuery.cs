
using MediatR;
using StaffManager.Application.Models.ViewModels;
using StaffManager.Application.Responses;

namespace StaffManager.Application.Queries.Employees.GetAll;

public class GetAllEmployeesQuery : IRequest<ServiceResponse<List<EmployeeViewModel>>>
{
    public GetAllEmployeesQuery()
    {
        
    }
}
