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

        public ProfileController(IPostService products, IUserService users, IMessageService messages, UserManager<ApplicationUser> userManager)
        {
            this.products = products;
            this.users = users;
            this.messages = messages;
            this.userManager = userManager;
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
            
            return View(user);
        }
    }
}
