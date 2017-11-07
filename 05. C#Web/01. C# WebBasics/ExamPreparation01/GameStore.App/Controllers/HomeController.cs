using SimpleMvc.Framework.Contracts;

namespace GameStore.App.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index() => View();
    }
}
