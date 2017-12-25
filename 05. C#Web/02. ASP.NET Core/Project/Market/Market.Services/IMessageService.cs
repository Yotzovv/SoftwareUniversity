using Market.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IMessageService
    {
        Task<List<Message>> GetUserMessages(string username);

        Task<bool> SendMessage(string text, ApplicationUser sender, ApplicationUser reciever);
    }
}
