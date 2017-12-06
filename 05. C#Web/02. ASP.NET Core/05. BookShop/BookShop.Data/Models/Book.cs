using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static BookShop.Data.DataConstants;

namespace BookShop.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public int? Edition { get; set; }

        public int? AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public List<BookCategory> Categories { get; set; } = new List<BookCategory>();
    }
}
