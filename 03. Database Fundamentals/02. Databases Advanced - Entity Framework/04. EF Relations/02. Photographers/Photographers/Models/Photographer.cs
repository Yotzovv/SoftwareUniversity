using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.Albums = new List<PhotographerAlbum>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        public virtual List<PhotographerAlbum> Albums { get; set; }
    }
}
