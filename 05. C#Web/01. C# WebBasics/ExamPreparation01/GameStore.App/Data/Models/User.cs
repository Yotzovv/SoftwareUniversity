﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.App.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(6), MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
