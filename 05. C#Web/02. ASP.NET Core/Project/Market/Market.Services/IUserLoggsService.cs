using Market.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IUserLoggsService
    {
        Task SetUserLoginDate(string username);

        Task SetUserLogoutDate(string username);

        Task<IEnumerable<UserLogin>> GetUsersLoggs();
    }
}
