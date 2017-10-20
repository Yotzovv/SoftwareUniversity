using SimpleMvc.Framework.Attributes;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;

namespace SimpleMvc.App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
