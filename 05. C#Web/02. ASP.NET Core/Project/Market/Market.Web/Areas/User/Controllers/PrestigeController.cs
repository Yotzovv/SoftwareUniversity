using Market.Services;
using Market.Web.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;
using static Market.Web.WebConstants;

namespace Market.Web.Areas.User.Controllers
{
    [Area(UserArea)]
    public class PrestigeController : Controller
    {
        private readonly IUserService users;
        private readonly IPrestigeService prestige;
        private readonly IOrderService orders;

        public PrestigeController(IUserService users, IPrestigeService prestige, IOrderService orders)
        {
            this.users = users;
            this.prestige = prestige;
            this.orders = orders;
        }

        [HttpPost]
        [Route("SetPrestige")]
        public async Task<IActionResult> SetPrestige(string userId, int orderId, bool wasHonest, bool wasHumble, bool wasInLineWithExpectations, bool wasNice)
        {
            var user = users.GetUserById(userId);
            var calcPrestigeServiceModel = new Market.Services.Model.CalcPrestigeServiceModel
            {
                WasHonest = wasHonest,
                WasHumble = wasHumble,
                WasInlineWithExpectations = wasInLineWithExpectations,
                WasNice = wasNice
            };

            await this.prestige.SetPrestige(user.Result, calcPrestigeServiceModel);
            await this.orders.IsRecieved(orderId);

            return RedirectToAction("", "Profile", new { username = User.Identity.Name });
        }
    }
}
