using StaffManager.Domain.Enums;

namespace StaffManager.Domain.Entities;

public class Employee
{
    public Employee(string name, string lastName, DepartamentEnum departament, bool active, ShiftEnum shift)
    {
        Name = name;
        LastName = lastName;
        Departament = departament;
        Active = active;
        Shift = shift;
        CreationDate = DateTime.Now.ToLocalTime();
        ModificationDate = DateTime.Now.ToLocalTime();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DepartamentEnum Departament {  get; set; }
    public bool Active { get; set; }
    public ShiftEnum Shift { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
}
