using BookShop.Api.Infrastructure.Extensions;
using BookShop.Api.Infrastructure.Extensions.Filters;
using BookShop.Api.Model.Authors;
using BookShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static BookShop.Api.WebConstants;

namespace BookShop.Api.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService authors;

        protected AuthorsController(IAuthorService authors)
        {
            this.authors = authors;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> Get(int id)
            => this.OkOrNotFound(await this.authors.Details(id));

        [HttpGet(WithId + "/books")]
        public async Task<IActionResult> GetBooks(int id)
            => this.Ok(await this.authors.Books(id));

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody]AuthorRequestModel model)
            => Ok(await this.authors.Create(model.FirstName, model.LastName));
    }
}
