using Market.Data.Models;
using Market.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IOrderService
    {
        Task OrderProduct(int productId, ApplicationUser recipient, ApplicationUser sender);

        Task<IEnumerable<OrderServiceModel>> GetUserOrders(string userName);

        Task WillSend(int orderId);

        Task CancelSending(int orderId);

        Task DeleteOrder(int orderId, string recipientId);
    }
}
