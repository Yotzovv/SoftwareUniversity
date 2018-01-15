using Market.Data.Models;
using Market.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IUserService
    {
        Task<List<UserListingServiceModel>> SearchAsync(string searchText);

        string GetUserId(string username);

        Task<UserProfileServiceModel> GetProfileAsync(string username);

        Task<ApplicationUser> GetUserById(string id);

        Task<ApplicationUser> GetUserByUserName(string username);
    }
}
