using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Student
{
    public Student()
    {
    }

    public Student(string name, string phoneNumber, DateTime registrationDate, DateTime birthday)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        RegistrationDate = registrationDate;
        Birthday = birthday;
        Courses = new List<StudentCourse>();
        Homeworks = new List<Homework>();
    }

    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime RegistrationDate { get; set; }

    public DateTime? Birthday { get; set; }

    public List<StudentCourse> Courses { get; set; }

    public List<Homework> Homeworks { get; set; }
}
