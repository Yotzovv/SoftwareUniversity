using GameStore.App.Models.Users;
using GameStore.App.Services;
using GameStore.App.Services.Contracts;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Contracts;

namespace GameStore.App.Controllers
{
    public class UsersController : BaseController
    {
        private const string RegisterError = "<p>Check your form for errors.</p><p>Email must have at least one '@' and one '.' symbols.</p><p>Length must be at least 6 symbols and must contain at least 1 uppercase, lowercase and digit.</p><p>Conrim passsword must match the provided password.</p>";
        private const string EmailExestsError = "<p>Email is already taken.</p>";
        private const string LoginError = "<p>Invalid credentials.</p>";

        private IUserService users;

        public UsersController()
        {
            this.users = new UserService();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if(model.Password != model.ConfirmPassword
            || !this.IsValidModel(model))
            {
                this.ViewModel["show-error"] = "block";
                return View();
            }

            var result = this.users
                             .Create(
                                     model.Email,
                                     model.Password,
                                     model.Name);
            if(result)
            {
                this.SignIn(model.Email);
                return this.Redirect("/users/login");
            }
            else
            {
                this.ShowError(EmailExestsError);
                return View();
            }
        }

        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(!this.IsValidModel(model))
            {
                this.ShowError(RegisterError);
                return this.View();
            }
            
            if(this.users.UserExists(model.Email, model.Password))
            {
                this.SignIn(model.Email);
                return this.Redirect("/");
            }
            else
            {
                this.ShowError(LoginError);
                return this.View();
            }
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return Redirect("/");
        }
    }
}
