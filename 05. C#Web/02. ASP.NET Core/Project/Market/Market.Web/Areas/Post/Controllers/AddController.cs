using Market.Data.Models;
using Market.Services;
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
        private readonly UserManager<ApplicationUser> userManager;

        public AddController(IPostService posts, UserManager<ApplicationUser> userManager)
        {
            this.posts = posts;
            this.userManager = userManager;
        }

        [Route("add")]
        public IActionResult Add() => View();

        [HttpPost]
        [Route("AddAsync")]
        public async Task<IActionResult> AddAsync(PostViewModel postModel)
        {
            //TODO:html sanitizer 

            await this.posts.AddPost(postModel.Title,
                                           postModel.Description,
                                           postModel.Price,
                                           postModel.Category,
                                           postModel.FormUploadedImages,
                                           await userManager.GetUserAsync(User));

            return RedirectToAction(nameof(HomeController.Index), "Home", new { string.Empty });
        }
    }
}


