using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Data;
using Market.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Services.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext db;

        public MessageService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Message>> GetUserMessages(string username)
        {
            var messages =  await this.db
                                      .Messages
                                      .Where(x => x.Reciever.UserName == username || x.Sender.UserName == username)
                                      .ToListAsync();

            foreach (var message in messages)
            {
                message.Reciever = await this.db.Users.FirstAsync(x => x.Id == message.RecieverId);
                message.Sender = await this.db.Users.FirstAsync(x => x.Id == message.SenderId);
            }

            return messages;
        }

        public async Task<bool> SendMessage(string text, ApplicationUser sender, ApplicationUser reciever)
        {
            var messasge = new Message
            {
                Text = text,
                RecieverId = sender.Id,
                Reciever = sender,
                SenderId = reciever.Id,
                Sender = reciever,
            };

            try
            {
                await this.db
                          .Messages
                          .AddAsync(messasge);

                await this.db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
