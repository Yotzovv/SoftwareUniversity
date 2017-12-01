using LerningSystem.Common.Mapper;
using LerningSystem.Data.Models;
using System;
using AutoMapper;

namespace LearningSystem.Services.Blog.Models
{
    public class BlogArticleListingServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Article, BlogArticleListingServiceModel>()
                     .ForMember(a => a.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
