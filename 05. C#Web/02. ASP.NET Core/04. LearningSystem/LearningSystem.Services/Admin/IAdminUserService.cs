using LearningSystem.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin
{
    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync();
    }
}
