using System;
using System.ComponentModel.DataAnnotations;
using static LerningSystem.Data.DataConstants;

namespace LerningSystem.Web.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        [Required]
        [MaxLength(ArticleTitleMaxLength)]
        [MinLength(ArticleTitleMinLength)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
