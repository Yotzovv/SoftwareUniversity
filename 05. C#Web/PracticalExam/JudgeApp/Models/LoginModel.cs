using JudgeApp.Attriubte;
using System.ComponentModel.DataAnnotations;

namespace JudgeApp.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }
    }
}
