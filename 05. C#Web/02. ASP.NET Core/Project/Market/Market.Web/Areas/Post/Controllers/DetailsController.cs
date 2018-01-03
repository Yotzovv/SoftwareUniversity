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
        private readonly IUserActivityService userActivities;

        public DetailsController(IPostService posts, IUserService users, IUserActivityService userActivities)
        {
            this.posts = posts;
            this.users = users;
            this.userActivities = userActivities;
        }

        [Route("details")]
        public async Task<IActionResult> Details(int id)
        {
            await this.posts.AddView(id);

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
                SubmissionDate = post.Result.SubmissionDate,
                ViewsCount = post.Result.Views
            };
            
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = this.users.GetUserByUserName(User.Identity.Name);
                await this.userActivities.AddUserActivity(string.Format(SawPost, post.Result.Id), currentUser.Result);
            }

            return View(postDetails);
        }
    }
}
