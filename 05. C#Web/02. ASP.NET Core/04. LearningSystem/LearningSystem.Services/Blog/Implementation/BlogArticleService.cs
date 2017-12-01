using LerningSystem.Data;
using LerningSystem.Data.Models;
using System;
using System.Threading.Tasks;
using LearningSystem.Services.Blog.Models;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using static LearningSystem.Services.ServiceConstants;

namespace LearningSystem.Services.Blog.Implementation
{
    public class BlogArticleService : IBlogArticleService
    {
        private readonly LearningSystemDbContext db;

        public BlogArticleService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BlogArticleListingServiceModel>> AllAsync(int page = 1)
              => await this.db
                           .Articles
                           .OrderByDescending(a => a.PublishDate)
                           .Skip((page - 1) * BlogArticlesPageSize)
                           .Take(BlogArticlesPageSize)
                           .ProjectTo<BlogArticleListingServiceModel>()
                           .ToListAsync();

        public async Task<BlogArticleDetailsServiceModel> ById(int id)
            => await this.db
                         .Articles
                         .Where(a => a.Id == id)
                         .ProjectTo<BlogArticleDetailsServiceModel>()
                         .FirstOrDefaultAsync();

        public async Task CreateAsync(string title, string content, string authorId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId
            };

            this.db.Add(article);

            await this.db.SaveChangesAsync();
        }

        public Task<int> TotalAsync()
            => this.db.Articles.CountAsync();
    }
}
