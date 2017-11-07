using System.ComponentModel.DataAnnotations;

public class Resource
{
    public Resource(int id, string name, ResourseType type, string uRL)
    {
        Id = id;
        Name = name;
        Type = type;
        URL = uRL;
    }

    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public ResourseType Type { get; set; }

    [Required]
    public string URL { get; set; }

    public int CourseId { get; set; }

    public Course Course { get; set; }
}
