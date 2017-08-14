using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
    public class Picture
    {
        public Picture()
        {
            this.Albums = new List<Album>();
        }
        [Key]
        public int Id { get; set; }
        
        [Required] 
        public string Title { get; set; }

        [Required]
        public string Caption { get; set; }

        [Required]
        public string PathInFileSystem { get; set; }

        public virtual List<Album> Albums { get; set; }
    }
}
