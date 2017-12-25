using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Market.Web.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        [Required]
        //property validation required
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

        public IFormFile ProfilePictureFile { get; set; }

        public byte[] CurrentProfilePicture { get; set; }
    }
}
