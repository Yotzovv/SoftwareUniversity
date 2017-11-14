using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        
        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
