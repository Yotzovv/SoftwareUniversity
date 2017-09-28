using System.ComponentModel.DataAnnotations;

public class StudentCourse
{
    public StudentCourse(int student_Id, int coruse_id)
    {
        Student_Id = student_Id;
        Course_Id = coruse_id;
    }

    public int Student_Id { get; set; }

    public Student Student { get; set; }
    
    public int Course_Id { get; set; }

    public Course Course { get; set; }
}
