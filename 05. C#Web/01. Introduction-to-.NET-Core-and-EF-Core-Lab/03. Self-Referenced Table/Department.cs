﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Department
{
    public Department(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set;}

    public List<Employee> Employees { get; set; }
}

