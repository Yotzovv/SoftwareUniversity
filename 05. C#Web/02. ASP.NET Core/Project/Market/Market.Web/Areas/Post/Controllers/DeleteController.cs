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

        public DeleteController(IPostService products, UserManager<ApplicationUser> userManager)
        {
            this.products = products;
            this.userManager = userManager;
        }
        
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.products.DeletePost(id);

            return RedirectToAction("", "Profile", new { username = User.Identity.Name });
        }
    }
}
