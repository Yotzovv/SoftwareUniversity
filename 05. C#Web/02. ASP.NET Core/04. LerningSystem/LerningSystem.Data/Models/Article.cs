using System;
using System.ComponentModel.DataAnnotations;
using static LerningSystem.Data.DataConstants;

namespace LerningSystem.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ArticleTitleMaxLength)]
        [MinLength(ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}