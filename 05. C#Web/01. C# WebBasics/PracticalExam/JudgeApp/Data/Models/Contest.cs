using System.Collections.Generic;

namespace JudgeApp.Data.Models
{
    public class Contest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public bool IsActive { get; set; } = true;

        public List<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
