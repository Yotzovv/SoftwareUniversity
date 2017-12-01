using AutoMapper.QueryableExtensions;
using LearningSystem.Services.Admin.Models;
using LerningSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly LearningSystemDbContext db;

        public AdminUserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
            => await this.db
                   .Users
                   .ProjectTo<AdminUserListingServiceModel>()
                   .ToListAsync();
    }
}
