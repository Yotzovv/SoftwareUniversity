using System;

namespace ModPanel.App.Data.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedOn { get; set; }
    }
}
