using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
    public enum Role
    {
        Owner,
        Viewer,
    }

    public class PhotographerAlbum
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Photographer")]
        public int Photographer_Id { get; set; }

        public virtual Photographer Photographer { get; set; }

        [Key]
        [ForeignKey("Album")]
        [Column(Order = 2)]
        public int Album_Id { get; set; }

        public virtual Album Album { get; set; }
        public Role Role { get; set; }
    }
}
