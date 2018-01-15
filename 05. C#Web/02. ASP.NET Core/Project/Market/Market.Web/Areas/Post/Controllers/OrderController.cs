using Market.Services;
using Market.Web.Areas.User.Controllers;
using Market.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Market.Web.WebConstants;

namespace Market.Web.Areas.Post.Controllers
{
    [Area(PostArea)]
    public class OrderController : Controller
    {
        private readonly IPostService products;
        private readonly IUserService users;
        private readonly IOrderService orders;

        public OrderController(IPostService products, IUserService users, IOrderService orders)
        {
            this.products = products;
            this.users = users;
            this.orders = orders;
        }
        
        [Route("Order")]
        public async Task<IActionResult> Order(int productId)
        {
            var recipient = this.users.GetUserByUserName(this.User.Identity.Name).Result;
            var sender = this.users.GetUserById(this.products.GetPostOwnerId(productId)).Result;

            await this.orders.OrderProduct(productId, recipient, sender);

            return RedirectToAction(nameof(HomeController.Index), "", new { string.Empty });
        }

        [Route("WillSend")]
        public async Task<IActionResult> WillSend(int orderId)
        {
            await this.orders.WillSend(orderId);
            
            return RedirectToAction(nameof(HomeController.Index), "", new { string.Empty });
        }

        [Route("CancelSending")]
        public async Task<IActionResult> CancelSending(int orderId)
        {
            await this.orders.CancelSending(orderId);

            return RedirectToAction(nameof(HomeController.Index), "", new { string.Empty });
        }

        [Route("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await this.orders.DeleteOrder(orderId, this.users.GetUserId(this.User.Identity.Name));

            return RedirectToAction(nameof(HomeController.Index), "", new { string.Empty });
        }
    }
}
