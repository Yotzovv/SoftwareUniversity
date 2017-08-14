using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Models
{
    public class Homework
    {
        public enum TypeOfContent
        {
            app,
            pdf,
            zip
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public TypeOfContent ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public int CourseId { get; set; }
        
        [Required]
        public int StudentId { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
