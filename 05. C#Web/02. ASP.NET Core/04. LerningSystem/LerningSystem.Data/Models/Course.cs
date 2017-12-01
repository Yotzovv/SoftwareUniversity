using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static LerningSystem.Data.DataConstants;

namespace LerningSystem.Data.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CourseNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(CourseDescriptionMaxLength)]
        public string Description { get; set; }
        
        public string TrainerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public User Trainer { get; set; }

        public List<StudentCourse> Students { get; set; } = new List<StudentCourse>();
    }
}
