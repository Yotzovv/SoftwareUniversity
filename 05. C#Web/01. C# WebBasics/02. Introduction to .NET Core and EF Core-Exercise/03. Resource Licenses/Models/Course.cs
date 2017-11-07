using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Course
{
    public Course()
    {
    }

    public Course(string name, string description, DateTime startDate, DateTime endDate, decimal price)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
        Participants = new List<StudentCourse>();
        Resources = new List<Resource>();
        Homework = new List<Homework>();
    }

    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public List<StudentCourse> Participants { get; set; }

    public List<Resource> Resources { get; set; }

    public List<Homework> Homework { get; set; }
}
 