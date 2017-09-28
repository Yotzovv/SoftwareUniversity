using System;
using System.ComponentModel.DataAnnotations;

public class Homework
{
    public Homework()
    {
    }

    public Homework(string content, ContentType type, DateTime submissionDate, int studentID, int courseID)
    {
        Content = content;
        Type = type;
        SubmissionDate = submissionDate;
        StudentId = studentID;
        CourseId = courseID;
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
