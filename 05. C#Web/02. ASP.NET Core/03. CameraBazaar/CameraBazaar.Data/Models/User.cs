using CameraBazaar.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CameraBazaar.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public List<Camera> Cameras { get; set; } = new List<Camera>();
    }
}
