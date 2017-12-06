using BookShop.Common.Common.Mapping;
using BookShop.Data.Models;

namespace BookShop.Services.Models.Book
{
    public class BookListingServiceModel : IMapFrom<Data.Models.Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
