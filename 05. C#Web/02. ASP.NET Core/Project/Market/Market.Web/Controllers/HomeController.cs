using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Market.Web.Models;
using Market.Web.Models.HomeViewModels;
using Market.Services;
using static Market.Web.WebConstants;
using PagedList;
using Market.Services.Model;

namespace Market.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService products;
        private readonly IUserService users;
        private readonly IUserActivityService userActivities;

        public HomeController(IPostService products, IUserService users, IUserActivityService userActivities)
        {
            this.products = products;
            this.users = users;
            this.userActivities = userActivities;
        }


        public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
           => View(new HomeIndexViewModel
           {
               Stocks = new PagedList<ProductListingServiceModel>(await this.products.GetAllPostsAsync(), page, pageSize)
           });

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

            viewModel.Stocks = new PagedList<ProductListingServiceModel>(await this.products.SearchAsync(model.SearchText), 1, 12);
            viewModel.Users = await this.users.SearchAsync(model.SearchText);

            viewModel.Filter();

            string searchTxt = string.IsNullOrWhiteSpace(model.SearchText) ? (model.Category == null ? "anything" : model.Category.ToString()) : model.SearchText;

            if (User.Identity.IsAuthenticated)
            {
                await this.userActivities.AddUserActivity(string.Format(SearchedFor, searchTxt), User.Identity.Name);
            }

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
