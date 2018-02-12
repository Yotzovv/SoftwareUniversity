using Market.Data.Models;
using Market.Data.Models.Enums;
using Market.Services.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Services
{
    public interface IPostService
    {
        Task AddPost(string title, string description, double price, Categories Category,IEnumerable<IFormFile> images, ApplicationUser user);

        Task DeletePost(int id);
        
        Task AddView(int productId);

        Task<IEnumerable<ProductListingServiceModel>> GetAllPostsAsync();

        Task<IEnumerable<ProductListingServiceModel>> GetAllUsersPostsAsync(string userId);

        int GetPostId(string title);

        Task<Post> GetPostById(int id);

        Task<Post> GetPostByTitle(string title);

        Task<IEnumerable<ProductListingServiceModel>> SearchAsync(string title);

        Task<List<Image>> GetAllPostImages(int postId);

        Task<List<Image>> GetAllPostImages(string postTitle);

        string GetPostOwnerId(int postId);

        string GetPostOwnerId(string postTitle);

        Task UpdatePost(int id, string title, string description, double price, IEnumerable<IFormFile> images);
    }
}
