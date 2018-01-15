using Market.Data.Models;
using Market.Services.Model;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IPrestigeService
    {
        Task SetPrestige(ApplicationUser user, CalcPrestigeServiceModel calcPrestigeServiceModel);
    }
}
