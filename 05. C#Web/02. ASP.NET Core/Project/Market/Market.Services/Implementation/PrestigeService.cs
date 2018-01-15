using System.Reflection;
using System.Threading.Tasks;
using Market.Data;
using Market.Data.Models;
using Market.Services.Model;

namespace Market.Services.Implementation
{
    public class PrestigeService : IPrestigeService
    {
        private readonly ApplicationDbContext db;

        public PrestigeService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task SetPrestige(ApplicationUser user, CalcPrestigeServiceModel calcPrestigeServiceModel)
        {
            PropertyInfo[] properties = calcPrestigeServiceModel.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var val = prop.GetValue(calcPrestigeServiceModel).ToString();

                if (val == "True")
                {
                    user.Prestige += 0.2;
                }
            }

            await this.db.SaveChangesAsync();
        }
    }
}
