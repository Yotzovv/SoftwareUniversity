using ModPanel.App.Data;
using ModPanel.App.Data.Models;
using ModPanel.App.Enums;
using ModPanel.App.Services.Contracts;
using System.Linq;

namespace ModPanel.App.Services
{
    public class UserService : IUserService
    {
        public bool Create(string email, string password, Positions position)
        {
            using (var db = new ModPanelContext())
            {
                if(this.UserExists(email, password))
                {
                    return false;
                }

                var isAdmin = !db.Users.Any();

                var user = new User
                {
                    Email = email,
                    Password = password,
                    IsAdmin = isAdmin,
                    Position = position,
                    isApproved = false,
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool UserExists(string email, string password)
        {
            using (var db = new ModPanelContext())
            {
                return db.Users.Any(u => u.Email == email && u.Password == password);
            }
        }
    }
}
