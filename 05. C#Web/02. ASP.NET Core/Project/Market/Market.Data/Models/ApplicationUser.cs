using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.Data.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {      
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
        
        public DateTime Birthdate { get; set; }
        
        public string Country { get; set; }

        public string Area { get; set; }
        
        public string DeliveryOfficeAddress { get; set; }

        public double Prestige { get; set; }

        public byte[] ProfilePicture { get; set; }

        public List<Order> Orders { get; set; }

        public IEnumerable<UserLogin> UserLoggs { get; set; } = new List<UserLogin>();

        public List<UserActivity> UserActivities { get; set; } = new List<UserActivity>();

        public List<PostOwner> Posts { get; set; }
    }
}
