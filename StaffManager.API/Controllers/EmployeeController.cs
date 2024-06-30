using MediatR;
using Microsoft.AspNetCore.Mvc;
using StaffManager.Application.Commands.Employees.Create;
using StaffManager.Application.Commands.Employees.Delete;
using StaffManager.Application.Commands.Employees.Inactivate;
using StaffManager.Application.Commands.Employees.Update;
using StaffManager.Application.Models.InputModels;
using StaffManager.Application.Models.ViewModels;
using StaffManager.Application.Queries.Employees.GetAll;
using StaffManager.Application.Queries.Employees.GetById;
using StaffManager.Application.Responses;

namespace StaffManager.WebAPI.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/employees
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<EmployeeViewModel>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllEmployeesQuery());
        return Ok(result);
    }

    // GET: api/employees/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<EmployeeViewModel>>> GetById(int id)
    {
        var result = await _mediator.Send(new GetEmployeeByIdQuery(id));
        return Ok(result);
    }

    // POST: api/employees
    [HttpPost]
    public async Task<ActionResult<ServiceResponse<EmployeeViewModel>>> Create([FromBody] EmployeeInputModel inputModel)
    {
        var command = new CreateEmployeeCommand(inputModel);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // PUT: api/employees/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<EmployeeViewModel>>> Update(int id, [FromBody] EmployeeInputModel inputModel)
    {
        var command = new UpdateEmployeeCommand(inputModel, id); // Passe o id como um parâmetro separado
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // DELETE: api/employees/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
    {
        var command = new DeleteEmployeeCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result); // Aqui você pode retornar um bool ou um ViewModel, dependendo da sua preferência
    }


    // POST: api/employees/inactivate/{id}
    [HttpPut("inactivate/{id}")]
    public async Task<ActionResult<ServiceResponse<EmployeeViewModel>>> Inactivate(int id)
    {
        var command = new InactivateEmployeeCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
