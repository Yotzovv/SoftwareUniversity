using Market.Data;
using Market.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Services.Model
{
    public class UserActivityService : IUserActivityService
    {
        private readonly ApplicationDbContext db;

        public UserActivityService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<UserActivity>> GetAllUsersActivity()
            => await this.db
                         .UserActivities
                         .ToListAsync();
                         

        public async Task AddUserActivity(string activity, ApplicationUser currentUser)
        {
            await this.db
                      .UserActivities
                      .AddAsync(new UserActivity
                      {
                          Activity = activity,
                          User = currentUser,
                          UserId = currentUser.Id,
                          Date = DateTime.UtcNow
                      });

            await this.db.SaveChangesAsync();
        }

        public async Task AddUserActivity(string activity, string username)
        {
            var user = await this.db.Users.FirstAsync(x => x.UserName == username);

            await this.AddUserActivity(activity, user);
        }
    }
}
