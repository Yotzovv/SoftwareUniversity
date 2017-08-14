using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Models
{
    public class StudentCourse
    {
        [Key]
        [Required]
        public int Student_Id { get; set; }

        [Required]
        public int Course_Id { get; set; }
    }
}
