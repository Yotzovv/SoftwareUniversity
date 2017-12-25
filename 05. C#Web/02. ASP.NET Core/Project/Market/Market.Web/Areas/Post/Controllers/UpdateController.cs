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

        public UpdateController(IPostService posts)
        {
            this.posts = posts;
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
        public async Task<IActionResult> UpdateAsync(PostViewModel post)
        {
            await this.posts.UpdatePost(post.Id,
                                        post.Title,
                                        post.Description,
                                        post.Price,
                                        post.FormUploadedImages);

            return RedirectToAction(nameof(DetailsController.Details), "Details", new { id = post.Id });
        }
    }
}
