using LearningSystem.Services.Admin;
using LearningSystem.Web.Areas.Admin.Controllers;
using LearningSystem.Web.Areas.Admin.Models.Users;
using LearningSystem.Web.Infrastructure.Extensions;
using LerningSystem.Data.Models;
using LerningSystem.Web.Areas.Admin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LerningSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService users;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> usersManager;

        public UsersController(IAdminUserService users, RoleManager<IdentityRole> roleManager,
                               UserManager<User> usersManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.usersManager = usersManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.users.AllAsync();
            var roles = await this.roleManager
                            .Roles
                            .Select(r => new SelectListItem
                            {
                                Text = r.Name,
                                Value = r.Name
                            })
                            .ToListAsync();


            return View(new AdminUserListingsViewModel
            {
                Users = users,
                Roles = roles
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.usersManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            if(!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid Identity Details.");
            }

            if(!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            await this.usersManager.AddToRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} successfully added to the {model.Role} role");

            return RedirectToAction(nameof(Index));
        }
    }
}
