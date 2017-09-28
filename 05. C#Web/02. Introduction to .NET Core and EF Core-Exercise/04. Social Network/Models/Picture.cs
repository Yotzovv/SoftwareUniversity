using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Picture
{
    public Picture()
    {
    }

    public Picture(string title, string caption, string filePath)
    {
        Title = title;
        Caption = caption;
        FilePath = filePath;
    }

    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Caption { get; set; }

    [Required]
    public string FilePath { get; set; }

    public List<AlbumsPictures> Albums { get; set; }    
}
