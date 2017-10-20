using SimpleMvc.Data;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMvc.App.ViewModels
{
    public class AllUsernamesViewModel
    {
        public IList<string> Usernames { get; set; }

        public int GetUserID(string username)
        {
            using (var ctx = new NotesDbContext())
            {
                return ctx.Users.FirstOrDefault(u => u.Username == username).Id;
            }
        }
    }
}
