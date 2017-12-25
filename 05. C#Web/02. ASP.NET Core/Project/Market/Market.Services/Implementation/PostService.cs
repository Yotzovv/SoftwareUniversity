using AutoMapper.QueryableExtensions;
using Market.Data;
using Market.Data.Models;
using Market.Data.Models.Enums;
using Market.Services.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Services.Implementation
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext db;

        public PostService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddPost(string title, string description, double price, Categories category, IEnumerable<IFormFile> images, ApplicationUser user)
        {
            var product = new Post()
            {
                Title = title,
                Description = description,
                Price = price,
                Owner = user,
                Category = category
            };

            if (images != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    foreach (var image in images)
                    {
                        await image.CopyToAsync(memoryStream);
                        product.Images
                               .Add(new Image
                               {
                                   ImageBytes = memoryStream.ToArray(),
                                   Product = product,
                                   ProductId = product.Id,
                                   IsProductProfilePicture = product.Images.Count == 0 ? true : false,
                               });
                    }
                }
            }

            this.db.Add(product);

            this.db.Add(new PostOwner
            {
                OwnerId = user.Id,
                PostId = product.Id
            });

            await this.db.SaveChangesAsync();
        }

        public async Task DeletePost(int id)
        {
            // var post = await this.db.Posts.FindAsync(id);
            //
            // if (post == null)
            // {
            //     return;
            // }
            //
            // post.IsActive = false;

            this.db.Posts.Remove(await this.db.Posts.FindAsync(id));
            await this.db.SaveChangesAsync();
        }

        public async Task UpdatePost(int id, string title, string description, double price, IEnumerable<IFormFile> images)
        {
            var post = await this.db.Posts.FirstAsync(x => x.Id == id);

            post.Title = title;
            post.Description = description;
            post.Price = price;

            if (images != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    foreach (var image in images)
                    {
                        await image.CopyToAsync(memoryStream);
                        post.Images
                               .Add(new Image
                               {
                                   ImageBytes = memoryStream.ToArray(),
                                   Product = post,
                                   ProductId = post.Id,
                                   IsProductProfilePicture = post.Images.Count == 0 ? true : false,
                               });
                    }
                }
            }

            await this.db.SaveChangesAsync();
        }
        
        public string GetPostOwnerId(int postId)
            => this.db
                   .PostOwner
                   .FirstAsync(p => p.PostId == postId)
                   .Result
                   .OwnerId;

        public async Task<List<Image>> GetAllPostImages(int productId)
            => await this.db
                         .Images
                         .Where(x => x.ProductId == productId)
                         .ToListAsync();

        public async Task<List<Image>> GetAllPostImages(string productTitle)
            => await this.db
                         .Images
                         .Where(x => x.Product.Title == productTitle)
                         .ToListAsync();

        public async Task<IEnumerable<ProductListingServiceModel>> GetAllPostsAsync()
            => await this.db
                         .Posts
                         .Where(p => p.IsActive)
                         .ProjectTo<ProductListingServiceModel>()
                         .ToListAsync();

        public async Task<IEnumerable<ProductListingServiceModel>> GetAllUsersPostsAsync(string username)
            => await this.db
                         .Posts
                         .Where(p => p.IsActive && p.Owner.UserName == username)
                         .ProjectTo<ProductListingServiceModel>()
                         .ToListAsync();

        public async Task<Post> GetPostById(int id)
            => await this.db.Posts.FindAsync(id);

        public int GetPostId(string title)
            => this.db
                   .Posts
                   .FirstAsync(x => x.Title == title)
                   .Id;

        public async Task<IEnumerable<ProductListingServiceModel>> SearchAsync(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                return await this.db
                                 .Posts
                                 .ProjectTo<ProductListingServiceModel>()
                                 .ToListAsync();
            }

            return await this.db
                             .Posts
                             .Where(p => p.Title.Contains(title))
                             .ProjectTo<ProductListingServiceModel>()
                             .ToListAsync();
        }

        public async Task<Post> GetPostByTitle(string title)
            => await this.db
                         .Posts
                         .FirstAsync(x => x.Title == title);

        public string GetPostOwnerId(string postTitle)
            => this.db
                   .Posts
                   .First(x => x.Title == postTitle)
                   .Owner
                   .Id;
    }
}
