using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Student
{
    public Student(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<StudentsCourses> StudentsCourses { get; set; }
}