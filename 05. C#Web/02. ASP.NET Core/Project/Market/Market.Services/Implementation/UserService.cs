using System.Threading.Tasks;
using Market.Services.Model;
using Market.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Market.Data.Models;

namespace Market.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<UserProfileServiceModel> GetProfileAsync(string username)
            => await this.db
                         .Users
                         .Where(u => u.UserName == username)
                         .ProjectTo<UserProfileServiceModel>()
                         .FirstOrDefaultAsync();

        public async Task<ApplicationUser> GetUserById(string id)
            => await this.db
                         .Users
                         .FindAsync(id);

        public async Task<List<UserListingServiceModel>> SearchAsync(string searchText)
        {
            if(string.IsNullOrWhiteSpace(searchText))
            {
                return await this.db
                                 .Users
                                 .ProjectTo<UserListingServiceModel>()
                                 .ToListAsync();
            }

            return await this.db
                             .Users
                             .Where(u => u.UserName.Contains(searchText))
                             .ProjectTo<UserListingServiceModel>()
                             .ToListAsync();
        }
    }
}
