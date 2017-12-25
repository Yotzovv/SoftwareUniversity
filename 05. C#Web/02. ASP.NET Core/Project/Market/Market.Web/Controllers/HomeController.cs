using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Market.Web.Models;
using Market.Web.Models.HomeViewModels;
using Market.Services;

namespace Market.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService products;
        private readonly IUserService users;

        public HomeController(IPostService products, IUserService users)
        {
            this.products = products;
            this.users = users;
        }


        public async Task<IActionResult> Index()
            => View(new HomeIndexViewModel { Stocks = await this.products.GetAllPostsAsync() });

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> Search(HomeIndexViewModel model)
        {
            var viewModel = new SearchViewModel
            {
                SearchText = model.SearchText,
                Area = model.Area,
                Country = model.Country,
                Category = model.Category,
                MinPrice = model.MinPrice,
                MaxPrice = model.MaxPrice,
            };

            viewModel.Stocks = await this.products.SearchAsync(model.SearchText);
            viewModel.Users = await this.users.SearchAsync(model.SearchText);

            viewModel.Filter();

            return View(viewModel);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
