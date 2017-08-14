using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Models
{
    public class Resource
    {
        public enum TypeOfResource
        {
            Video,
            Presentation,
            Document,
            Other
        };

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TypeOfResource RecourseType { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public int CourseId { get; set; }

      //  public virtual List<License> Licenses { get; set; }
    }
}
