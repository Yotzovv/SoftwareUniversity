using Market.Data;
using Market.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Services.Implementation
{
    public class UserLoggsService : IUserLoggsService
    {
        private readonly ApplicationDbContext db;

        public UserLoggsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<UserLogin>> GetUsersLoggs()
        {
            var userLoggs = await this.db
                                      .UserLoggs
                                      .ToListAsync();

            foreach (var log in userLoggs)
            {
                log.User = this.db.Users.Find(log.UserId);
            }

            return userLoggs;
        }

        public async Task SetUserLoginDate(string username)
        {
            var user = this.db.Users.First(u => u.UserName == username);

            await this.db
                      .UserLoggs
                      .AddAsync(new UserLogin
                      {
                          UserId = user.Id,
                          User = user,
                          LoginDate = DateTime.UtcNow,
                      });

            await this.db.SaveChangesAsync();
        }

        public async Task SetUserLogoutDate(string username)
        {
            var user = this.db.Users.First(u => u.UserName == username);

            var userLog = await this.db.UserLoggs.Where(n => n.User == user).LastAsync();
            userLog.LogoutDate = DateTime.UtcNow;

            await this.db.SaveChangesAsync();
        }
    }
}
