
using StaffManager.Domain.Entities;
using StaffManager.Domain.Enums;

namespace StaffManager.Application.Models.InputModels;

public class EmployeeInputModel
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DepartamentEnum Departament { get; set; }
    public bool Active { get; set; }
    public ShiftEnum Shift { get; set; }

    public Employee ToEntity()
        => new Employee(Name, LastName, Departament, Active, Shift);
}


