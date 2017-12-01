using LearningSystem.Services.Implementation;
using LearningSystem.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningSystem.Services
{
    public interface IUserService
    {
        Task<UserProfileServiceModel> ProfileAsync(string username);

        Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText);

        Task<byte[]> GetPdfCertificate(int courseId, string studentId);
    }
}
