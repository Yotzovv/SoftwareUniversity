using ModPanel.App.Attributes.Posts;
using System.ComponentModel.DataAnnotations;

namespace ModPanel.App.Models
{
    public class PostModel
    {
        [Required]
        [CapitalAttribute]
        [MinLength(3), MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
