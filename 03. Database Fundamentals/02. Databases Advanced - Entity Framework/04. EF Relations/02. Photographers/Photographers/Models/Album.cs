using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
    public class Album
    {
        public Album()
        {
            this.Pictures = new List<Picture>();
            this.Tags = new List<Tag>();
            this.Photographers = new List<PhotographerAlbum>();
        }
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        [Required]
        public string BackgroundColor { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        public List<PhotographerAlbum> Photographers { get; set; }

        public virtual List<Picture> Pictures { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
