﻿using GameStore.App.Infrastructure.Validation;
using GameStore.App.Infrastructure.Validation.Users;

namespace GameStore.App.Models.Users
{
    public class RegisterModel
    {
        [Required]
        [Email]
        public string Email { get; set; }

        public string Name { get; set; }

        [Required]
        [Password]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
