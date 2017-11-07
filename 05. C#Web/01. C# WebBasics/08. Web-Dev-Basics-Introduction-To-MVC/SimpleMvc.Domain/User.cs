using System.Collections.Generic;

namespace SimpleMvc.Domain
{
    public class User
    {
        public User()
        {
            Notes = new List<Note>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public IList<Note> Notes { get; set; }
    }
}
