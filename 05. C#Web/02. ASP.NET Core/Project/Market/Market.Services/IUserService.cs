using Market.Data.Models;
using Market.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IUserService
    {
        Task<UserProfileServiceModel> GetProfileAsync(string username);

        Task<List<UserListingServiceModel>> SearchAsync(string searchText);

        Task<ApplicationUser> GetUserById(string id);

        Task<ApplicationUser> GetUserByUserName(string username);
    }
}
