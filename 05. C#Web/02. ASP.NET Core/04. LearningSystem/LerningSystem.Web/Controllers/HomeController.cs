using LearningSystem.Services;
using LearningSystem.Web.Models.Home;
using LerningSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LerningSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService courses;
        private readonly IUserService users;

        public HomeController(ICourseService courses, IUserService users)
        {
            this.courses = courses;
            this.users = users;
        }

        public async Task<IActionResult> Index() 
            => View(new HomeIndexViewModel
            {
                Courses = await this.courses.ActiveAsync(),
            });

        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            var viewModel = new SearchViewModel
            {
                SearchText = model.SearchText
            };

            if(model.SearchInCourses)
            {
                viewModel.Courses = await this.courses.FindAsync(model.SearchText);
            }

            if(model.SearchInUsers)
            {
                viewModel.Users = await this.users.FindAsync(model.SearchText);
            }

            return View(viewModel);
        }
    }
}
