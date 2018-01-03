using Market.Services;
using Market.Web.Areas.Product.Models;
using Market.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Market.Web.WebConstants;

namespace Market.Web.Areas.Product.Controllers
{
    [Area(PostArea)]
    public class UpdateController : Controller
    {
        private readonly IPostService posts;
        private readonly IUserActivityService userActivities;

        public UpdateController(IPostService posts, IUserActivityService userActivities)
        {
            this.posts = posts;
            this.userActivities = userActivities;
        }

        [Route("update")]
        public async Task<IActionResult> Update(int postId)
        {
            var post = posts.GetPostById(postId);

            var postDetails = new PostViewModel
            {
                Id = postId,
                Title = post.Result.Title,
                Description = post.Result.Description,
                Price = post.Result.Price,
                Images = await posts.GetAllPostImages(postId),
                Category = post.Result.Category,
            };

            return View(postDetails);
        }

        [HttpPost]
        [Route("updateasync")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(PostViewModel post)
        {
            await this.posts.UpdatePost(post.Id,
                                        post.Title,
                                        post.Description,
                                        post.Price,
                                        post.FormUploadedImages);

            await this.userActivities.AddUserActivity(string.Format(UpdatedPost, post.Id), User.Identity.Name);

            return RedirectToAction(nameof(DetailsController.Details), "Details", new { id = post.Id });
        }
    }
}
