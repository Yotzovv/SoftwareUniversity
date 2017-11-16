using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [RegularExpression(@"^\w+$", ErrorMessage = "Username must contain only letters.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^\+\d{10,12}$", ErrorMessage = "Phone number must start with a '+' and contain between 10 to 12 digits.")]
        public string Phone { get; set; }
    }
}
