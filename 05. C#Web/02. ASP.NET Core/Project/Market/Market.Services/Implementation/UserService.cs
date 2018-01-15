using AutoMapper.QueryableExtensions;
using Market.Data;
using Market.Data.Models;
using Market.Services.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<ApplicationUser> GetUserByUserName(string username)
            => await this.db
                         .Users
                         .FirstAsync(x => x.UserName == username);

        public string GetUserId(string username)
            => this.GetUserByUserName(username)
                   .Result
                   .Id;

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
