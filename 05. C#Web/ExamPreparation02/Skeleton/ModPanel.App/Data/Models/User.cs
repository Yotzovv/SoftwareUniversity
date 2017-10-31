using ModPanel.App.Enums;
using System.Collections.Generic;

namespace ModPanel.App.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Post> Posts { get; set; }

        public List<Log> Logs { get; set; }

        public bool IsAdmin { get; set; }

        public bool isApproved { get; set; }

        public Positions Position { get; set; }
    }
}
