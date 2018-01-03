using Market.Data.Models;
using Market.Services;
using Market.Web.Areas.Admin.Controllers;
using Market.Web.Areas.Product.Models;
using Market.Web.Areas.User.Controllers;
using Market.Web.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using static Market.Web.WebConstants;

namespace Market.Web.Areas.Product.Controllers
{
    [Area(PostArea)]
    public class AddController : Controller
    {
        private readonly IPostService posts;
        private readonly IUserActivityService userActivities;
        private readonly UserManager<ApplicationUser> userManager;

        public AddController(IPostService posts, IUserActivityService userActivities, UserManager<ApplicationUser> userManager)
        {
            this.posts = posts;
            this.userManager = userManager;
            this.userActivities = userActivities;
        }

        [Route("add")]
        public IActionResult Add() => View();

        [HttpPost]
        [Route("AddAsync")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAsync(PostViewModel postModel)
        {
            //TODO:html sanitizer 
            var user = await userManager.GetUserAsync(User);

            await this.posts.AddPost(postModel.Title,
                                           postModel.Description,
                                           postModel.Price,
                                           postModel.Category,
                                           postModel.FormUploadedImages,
                                           user);

            await this.userActivities.AddUserActivity(string.Format(AddedPost, posts.GetPostId(postModel.Title)), user);

            return RedirectToAction(nameof(HomeController.Index), "Home", new { string.Empty });
        }
    }
}


