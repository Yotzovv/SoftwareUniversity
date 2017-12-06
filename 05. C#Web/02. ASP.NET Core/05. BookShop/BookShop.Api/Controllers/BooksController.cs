using BookShop.Api.Infrastructure.Extensions;
using BookShop.Api.Infrastructure.Extensions.Filters;
using BookShop.Api.Model.Books;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using static BookShop.Api.WebConstants;

namespace BookShop.Api.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IBookService books;
        private readonly IAuthorService authors;

        public BooksController(IBookService books, IAuthorService authors)
        {
            this.books = books;
            this.authors = authors;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string search = "")
            => this.Ok(await this.books.All(search));

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.books.Details(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]CreateBookRequestModel model)
        {
            if(!await this.authors.Exists(model.AuthorId))
            {
                return BadRequest("Author does not exists.");
            }

            var id = await this.books.Create(model.Title,
                                             model.Description,
                                             model.Price,
                                             model.Copies,
                                             model.Edition,
                                             model.AgeRestriction,
                                             model.ReleaseDate,
                                             model.AuthorId,
                                             model.Categories);

            return Ok(id);
        }
    }
}
