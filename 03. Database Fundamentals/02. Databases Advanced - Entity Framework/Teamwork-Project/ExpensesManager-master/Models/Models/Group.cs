using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Group
    {
        public Group()
        {
            this.IsActive = true;
            this.SubGroups = new HashSet<SubGroup>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public virtual ICollection<SubGroup> SubGroups { get; set; }





    }
}
