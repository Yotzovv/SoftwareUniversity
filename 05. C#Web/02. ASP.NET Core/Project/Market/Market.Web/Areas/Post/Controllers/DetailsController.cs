using Market.Services;
using Market.Web.Areas.Product.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Market.Web.WebConstants;

namespace Market.Web.Areas.Product.Controllers
{
    [Area(PostArea)]
    public class DetailsController : Controller
    {
        private readonly IPostService posts;
        private readonly IUserService users;

        public DetailsController(IPostService posts, IUserService users)
        {
            this.posts = posts;
            this.users = users;
        }

        [Route("details")]
        public async Task<IActionResult> Details(int id)
        {
            var post = posts.GetPostById(id);

            var postDetails = new PostDetailsViewModel
            {
                Id = id,
                Title = post.Result.Title,
                Description = post.Result.Description,
                Price = post.Result.Price,
                Images = await posts.GetAllPostImages(id),
                Owner = await this.users.GetUserById(posts.GetPostOwnerId(id)),
                Category = post.Result.Category,
            };

            return View(postDetails);
        }
    }
}
