using System;

namespace Market.Data.Models
{
    public class UserActivity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Activity { get; set; }

        public DateTime Date { get; set; }
    }
}
