using System;
using System.ComponentModel.DataAnnotations;

public class Homework
{
    public Homework(int id, string content, ContentType type, DateTime submissionDate, Student student)
    {
        Id = id;
        Content = content;
        Type = type;
        SubmissionDate = submissionDate;
        Student = student;
    }

    public int Id { get; set; }

    [Required]
    public string Content { get; set; }
    
    public ContentType Type { get; set; }
    
    public DateTime SubmissionDate { get; set; }

    public int CourseId { get; set; }

    public Course Course { get; set; }

    public int StudentId { get; set; }

    public Student Student { get; set; }
}
