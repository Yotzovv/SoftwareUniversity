using System.Collections.Generic;

namespace JudgeApp.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public List<Contest> Contests { get; set; }

        public List<Submission> Submissions { get; set; }
    }
}
