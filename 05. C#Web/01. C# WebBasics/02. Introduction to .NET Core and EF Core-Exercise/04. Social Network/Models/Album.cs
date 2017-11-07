using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Album
{
    public Album()
    {
        Pictures = new List<AlbumsPictures>();
    }

    public Album(string name, string backgroundColor, bool isPublic, int owner_Id)
    {
        Name = name;
        BackgroundColor = backgroundColor;
        IsPublic = isPublic;
        OwnerId = owner_Id;
    }

    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string BackgroundColor { get; set; }

    [Required]
    public bool IsPublic { get; set; }

    public List<AlbumsPictures> Pictures { get; set; }

    public int OwnerId { get; set; }

    public User Owner { get; set; }
}
