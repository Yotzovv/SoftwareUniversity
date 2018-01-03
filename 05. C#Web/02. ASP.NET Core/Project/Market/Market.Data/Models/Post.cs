using Market.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace Market.Data.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        
        public List<Image> Images { get; set; } = new List<Image>();

        public bool IsActive { get; set; } = true;

        public Categories Category { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int Views { get; set; } = 0;

        public ApplicationUser Owner { get; set; }
    }
}
