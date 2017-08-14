using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Discovery
    {
        public Discovery()
        {
            this.Stars = new HashSet<Star>();
            this.Planets = new HashSet<Planet>();
            this.Pioneers = new HashSet<Astronomer>();
            this.Observers = new HashSet<Astronomer>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int TelescopeUsedId { get; set; }

        [Required]
        public virtual Telescope TelescopeUsed { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
        public virtual ICollection<Astronomer> Pioneers { get; set; }
        public virtual ICollection<Astronomer> Observers { get; set; }


    }
}
