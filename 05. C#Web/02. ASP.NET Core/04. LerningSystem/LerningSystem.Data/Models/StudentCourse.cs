using LerningSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LerningSystem.Data.Models
{
    public class StudentCourse
    {
        public string StudentId { get; set; }

        public User Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public Grade? Grade { get; set; }

        [MaxLength(DataConstants.CourseExamSubmissionFileLength)]
        public byte[] ExamSubmission { get; set; }
    }
}
