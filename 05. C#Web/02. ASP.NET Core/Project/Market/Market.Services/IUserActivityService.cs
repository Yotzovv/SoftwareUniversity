using Market.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IUserActivityService
    {
        Task AddUserActivity(string activity, ApplicationUser currentUser);

        Task AddUserActivity(string activity, string username);

        Task<List<UserActivity>> GetAllUsersActivity();
    }
}
