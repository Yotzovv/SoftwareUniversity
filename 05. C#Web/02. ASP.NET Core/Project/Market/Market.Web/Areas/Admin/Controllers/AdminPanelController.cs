using Market.Services;
using Market.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using static Market.Web.WebConstants;

namespace Market.Web.Areas.Admin.Controllers
{
    [Area(AdminArea)]
    public class AdminPanelController : Controller
    {
        private readonly IUserLoggsService userLogins;
        private readonly IUserActivityService userActivities;

        public AdminPanelController(IUserLoggsService userLogins, IUserActivityService userActivities)
        {
            this.userLogins = userLogins;
            this.userActivities = userActivities;
        }

        [Route("AdminPanel")]
        public IActionResult AdminPanel() => View(new AdminPanelModel
        {
            UserLogins = userLogins.GetUsersLoggs().Result,
            UsersActivities = userActivities.GetAllUsersActivity().Result
        });
    }
}
