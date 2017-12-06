using BookShop.Common.Common.Mapping;
using BookShop.Data.Models;

namespace BookShop.Services.Models.Books
{
    public class BookDetailsServiceModel 
        : BookWithCategoriesServiceModel, IMapFrom<Book>, IHaveCustomMapping
    {
        public string Author { get; set; }
    }
}
