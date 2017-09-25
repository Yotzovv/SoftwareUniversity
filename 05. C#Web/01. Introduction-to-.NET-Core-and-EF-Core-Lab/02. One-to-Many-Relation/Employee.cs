using System.ComponentModel.DataAnnotations;

public class Employee
{
    public Employee(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public int DepartmentId { get; set; }

    public Department Department { get; set; }
}