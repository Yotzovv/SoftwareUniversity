using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Market.Data;
using Market.Data.Models;
using Market.Services.Model;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext db;

        public OrderService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<OrderServiceModel>> GetUserOrders(string userName)
            => await this.db
                         .Orders
                         .Where(x => x.Sender.UserName == userName || x.Recipient.UserName == userName)
                         .ProjectTo<OrderServiceModel>()
                         .ToListAsync();

        public async Task WillSend(int orderId)
        {
            var order = await this.db
                                  .Orders
                                  .FirstAsync(x => x.ProductId == orderId);

            order.IsApproved = true;

            await this.db.SaveChangesAsync();
        }

        public async Task CancelSending(int orderId)
        {
            var order = await this.db
                                 .Orders
                                 .FirstAsync(x => x.ProductId == orderId);

            order.IsApproved = false;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteOrder(int orderId, string recipientId)
        {
            var order = await this.db.Orders.FirstAsync(x => x.ProductId == orderId && x.RecipientId == recipientId);

            this.db.Orders.Remove(order);

            await this.db.SaveChangesAsync();
        }

        public async Task OrderProduct(int productId, ApplicationUser recipient, ApplicationUser sender)
        {
            await this.db.AddAsync(new Order
            {
                ProductId = productId,
                Product = await this.db.Posts.FindAsync(productId),
                Sender = sender,
                SenderId = sender.Id,
                Recipient = recipient,
                RecipientId = recipient.Id,
                RecipientDeliveryOfficeAddress = recipient.DeliveryOfficeAddress,
                OrderedDate = DateTime.UtcNow,
                IsApproved = false,
            });

            await this.db.SaveChangesAsync();
        }
    }
}
