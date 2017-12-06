using BookShop.Services.Models;
using BookShop.Services.Models.Authors;
using BookShop.Services.Models.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public interface IAuthorService
    {
        Task<AuthorDetailsServiceModel> Details(int id);

        Task<int> Create(string firstName, string lastName);

        Task<IEnumerable<BookWithCategoriesServiceModel>> Books(int authorId);

        Task<bool> Exists(int id);
    }
}
