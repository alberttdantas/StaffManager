
using StaffManager.Domain.Enums;

namespace StaffManager.Application.Models.ViewModels;

public class EmployeeViewModel
{
    public EmployeeViewModel(int id, string name, string lastName, DepartamentEnum departament, bool active, ShiftEnum shift, DateTime creationDate, DateTime modificationDate)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Departament = departament;
        Active = active;
        Shift = shift;
        CreationDate = creationDate;
        ModificationDate = modificationDate;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DepartamentEnum Departament { get; set; }
    public bool Active { get; set; }
    public ShiftEnum Shift { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
}
