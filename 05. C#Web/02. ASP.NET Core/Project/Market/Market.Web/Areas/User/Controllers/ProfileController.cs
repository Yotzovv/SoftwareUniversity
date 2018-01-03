using Market.Data.Models;
using Market.Services;
using Market.Services.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using static Market.Web.WebConstants;

namespace Market.Web.Areas.User.Controllers
{
    [Area(UserArea)]
    public class ProfileController : Controller
    {
        private readonly IPostService products;
        private readonly IUserService users;
        private readonly IMessageService messages;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserActivityService userActivities;

        public ProfileController(IPostService products, IUserService users, IMessageService messages, IUserActivityService userActivities, UserManager<ApplicationUser> userManager)
        {
            this.products = products;
            this.users = users;
            this.messages = messages;
            this.userManager = userManager;
            this.userActivities = userActivities;
        }

        [Route("Profile")]
        public async Task<IActionResult> Profile(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return NotFound();
            }

            var user = await this.users.GetProfileAsync(username);
            user.Posts = await this.products.GetAllUsersPostsAsync(username);
            user.Messages = await this.messages.GetUserMessages(username);

            await this.userActivities.AddUserActivity(string.Format(SawProfile, user.Username), User.Identity.Name);
            
            return View(user);
        }
    }
}
