using System;

namespace Market.Data.Models
{
    public class UserLogin
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime LoginDate { get; set; }

        public DateTime LogoutDate { get; set; }
    }
}
