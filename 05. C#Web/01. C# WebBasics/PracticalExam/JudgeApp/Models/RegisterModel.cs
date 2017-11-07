using JudgeApp.Attriubte;
using System.ComponentModel.DataAnnotations;

namespace JudgeApp.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        [Password]
        public string ConfirmPassword { get; set; }
    }
}
