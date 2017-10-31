using SimpleMvc.Framework.Contracts;

namespace JudgeApp.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                this.ViewModel["name"] = this.Profile.FullName;

                if (this.Profile.IsAdmin)
                {
                    this.ViewModel["adminDisplay"] = "block";
                }
                else
                {
                    this.ViewModel["userDisplay"] = "block";
                }
            }
            else
            {
                this.ViewModel["name"] = "Guest";
            }

            return this.View();
        }
    }
}
