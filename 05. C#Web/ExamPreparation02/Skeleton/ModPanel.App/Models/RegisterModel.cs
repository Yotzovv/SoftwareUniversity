using ModPanel.App.Attributes.Users;
using ModPanel.App.Enums;
using System.ComponentModel.DataAnnotations;

namespace ModPanel.App.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        [Password]
        public string ConfirmPassword { get; set; }

        [Required]
        public Positions Position { get; set; }
    }
}
