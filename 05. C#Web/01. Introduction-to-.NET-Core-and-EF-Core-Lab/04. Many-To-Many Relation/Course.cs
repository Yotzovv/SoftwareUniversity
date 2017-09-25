using System.ComponentModel.DataAnnotations;

public class Course
{
    public Course(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
