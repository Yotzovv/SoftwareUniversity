using System;
using System.ComponentModel.DataAnnotations;
using static LerningSystem.Data.DataConstants;

namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    public class PublishArticleFormModel
    {
        [Required]
        [MaxLength(ArticleTitleMaxLength)]
        [MinLength(ArticleTitleMinLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
    }
}
