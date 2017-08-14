using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Astronomer
    {
        public Astronomer()
        {
            this.PioneeringDiscoveries = new HashSet<Discovery>();
            this.ObservationDiscoveries = new HashSet<Discovery>();              
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

       public virtual ICollection<Discovery> PioneeringDiscoveries { get; set; }
       public virtual ICollection<Discovery> ObservationDiscoveries { get; set; }

    }
}
