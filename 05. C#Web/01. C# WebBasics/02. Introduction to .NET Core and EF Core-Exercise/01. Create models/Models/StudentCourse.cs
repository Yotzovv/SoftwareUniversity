using System.ComponentModel.DataAnnotations;

public class StudentCourse
{
    public int Student_Id { get; set; }

    public Student Student { get; set; }
    
    public int Course_Id { get; set; }

    public Course Course { get; set; }
}
