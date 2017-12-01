using LerningSystem.Common.Mapper;
using LerningSystem.Data.Models;

namespace LearningSystem.Services.Admin.Models
{
    public class AdminUserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set;}
    }
}
