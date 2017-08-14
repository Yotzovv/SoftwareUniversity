using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class Element
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime DateBought { get; set; }
        [ForeignKey("SubGroup")]
        public int SubGroupId { get; set; }
        public virtual SubGroup SubGroup { get; set; }
    }
}
