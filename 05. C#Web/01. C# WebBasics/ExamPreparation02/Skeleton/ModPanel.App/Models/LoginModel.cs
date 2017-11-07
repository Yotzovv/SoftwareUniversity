using System.ComponentModel.DataAnnotations;

namespace ModPanel.App.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        //pass attr
        public string Password { get; set; }
    }
}
