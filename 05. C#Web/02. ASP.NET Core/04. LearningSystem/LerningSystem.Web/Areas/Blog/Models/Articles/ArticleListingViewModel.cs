using LearningSystem.Services;
using LearningSystem.Services.Blog.Models;
using System;
using System.Collections.Generic;

namespace LearningSystem.Web.Areas.Blog.Models.Articles
{
    public class ArticleListingViewModel
    {
        public IEnumerable<BlogArticleListingServiceModel> Articles { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int) Math.Ceiling((double)this.TotalArticles / ServiceConstants.BlogArticlesPageSize);

        public int PreviousPage => CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == TotalPages
             ? this.TotalPages
             : this.CurrentPage + 1;

        public int TotalArticles { get; set; }
    }
}
