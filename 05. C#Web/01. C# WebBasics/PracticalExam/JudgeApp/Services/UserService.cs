using JudgeApp.Data;
using JudgeApp.Data.Models;
using JudgeApp.Services.Contracts;
using System.Linq;

namespace JudgeApp.Services
{
    public class UserService : IUserService
    {
        public bool Create(string fullName, string email, string password)
        {
            using (var db = new JudgeAppContext())
            {
                if (this.UserExists(email, password))
                {
                    return false;
                }

                var isAdmin = !db.Users.Any();

                var user = new User
                {
                    Email = email,
                    FullName = fullName,
                    Password = password,
                    IsAdmin = isAdmin,
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public bool UserExists(string email, string password)
        {
            using (var db = new JudgeAppContext())
            {
                return db.Users.Any(u => u.Email == email && u.Password == password);
            }
        }

        public bool UserExists(string email)
        {
            using (var db = new JudgeAppContext())
            {
                return db.Users.Any(u => u.Email == email);
            }
        }
    }
}
