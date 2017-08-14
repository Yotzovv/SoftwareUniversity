using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem.Models
{
    public class Book
    {
        public enum EditionType
        {
            Normal,
            Promo,
            Gold
        }

        public enum AgeRestriction
        {
            Minor,
            Teen,
            Adult
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Discription { get; set; }

        [Required]
        public EditionType Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        public AgeRestriction AgeRestrict { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

    }
}
