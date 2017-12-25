using AutoMapper;
using Market.Common.Mapping;
using Market.Data.Models;
using Market.Data.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Market.Services.Model
{
    public class ProductListingServiceModel : IMapFrom<Post>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public List<Image> Images { get; set; }

        public double Price { get; set; }

        public string Area { get; set; }

        public string Country { get; set; }

        public Categories Category { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Post, ProductListingServiceModel>()
                  .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                  .ForMember(dest => dest.Title, src => src.MapFrom(x => x.Title))
                  .ForMember(dest => dest.Description, src => src.MapFrom(x => x.Description))
                  .ForMember(dest => dest.Images, src => src.MapFrom(x => x.Images))
                  .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Price));

        }
    }
}
