using Market.Data.Models;
using Market.Services;
using Market.Web.Areas.User.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Market.Web.WebConstants;

namespace Market.Web.Areas.Post.Controllers
{
    [Area(PostArea)]
    public class DeleteController : Controller
    {
        private readonly IPostService products;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserActivityService userActivities;

        public DeleteController(IPostService products, IUserActivityService userActivities, UserManager<ApplicationUser> userManager)
        {
            this.products = products;
            this.userManager = userManager;
            this.userActivities = userActivities;
        }
        
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await this.products.DeletePost(id);

            var user = this.userManager.FindByNameAsync(User.Identity.Name);

            await this.userActivities.AddUserActivity(string.Format(DeletedPost, id), user.Result);

            return RedirectToAction("", "Profile", new { username = User.Identity.Name });
        }
    }
}
