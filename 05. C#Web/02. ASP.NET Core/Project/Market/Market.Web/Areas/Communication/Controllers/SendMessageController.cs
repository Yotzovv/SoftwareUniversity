using Ganss.XSS;
using Market.Data.Models;
using Market.Services;
using Market.Web.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Market.Web.WebConstants;

namespace Market.Web.Areas.Communication.Controllers
{
    [Area(CommunicationArea)]
    public class SendMessageController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserService users;
        private readonly IMessageService messages;
        private readonly IUserActivityService userActivities;

        public SendMessageController(UserManager<ApplicationUser> userManager, IUserActivityService userActivities, IUserService users, IMessageService messages)
        {
            this.userManager = userManager;
            this.users = users;
            this.messages = messages;
            this.userActivities = userActivities;
        }

        [Route("SendMessageAsync")]
        [HttpPost]
        public async Task<IActionResult> SendMessageAsync(string recieverId ,string text)
        {
            ApplicationUser sender = await this.userManager.GetUserAsync(User);
            ApplicationUser reciever = await this.users.GetUserById(recieverId);

            await this.messages.SendMessage(text, sender, reciever);

            await this.userActivities.AddUserActivity(string.Format(SentMessage, reciever.UserName), sender);
            
            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty });
        }
    }
}
