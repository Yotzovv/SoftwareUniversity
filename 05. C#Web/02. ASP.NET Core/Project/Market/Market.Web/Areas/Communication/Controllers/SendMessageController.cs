using Market.Data.Models;
using Market.Services;
using Market.Web.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Market.Web.Areas.Communication.Controllers
{
    public class SendMessageController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService users;
        private readonly IMessageService messages;

        public SendMessageController(UserManager<ApplicationUser> userManager, IUserService users, IMessageService messages)
        {
            this.userManager = userManager;
            this.users = users;
            this.messages = messages;
        }

        public async Task<IActionResult> SendMessageAsync(string recieverId ,string text)
        {
            ApplicationUser sender = await this.userManager.GetUserAsync(User);
            ApplicationUser reciever = await this.users.GetUserById(recieverId);

            await this.messages.SendMessage(text, sender, reciever);
            
            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty });
        }
    }
}
