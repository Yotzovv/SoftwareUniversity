using System.Collections.Generic;

public class Manager : Employee
{
    public Manager(string name) : base(name)
    {
    }

    public List<Employee> Employees { get; set; }
}