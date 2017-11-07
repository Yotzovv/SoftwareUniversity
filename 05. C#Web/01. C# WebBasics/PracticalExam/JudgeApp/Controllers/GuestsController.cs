using JudgeApp.Data;
using JudgeApp.Models;
using JudgeApp.Services;
using JudgeApp.Services.Contracts;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Contracts;
using System.Linq;

namespace JudgeApp.Controllers
{
    public class GuestsController : BaseController
    {
        private const string RegisterError = "<p>Check your form for errors.</p><p>Email must have at least one '@' and one '.' symbols.</p><p>Length must be at least 6 symbols and must contain at least 1 uppercase, lowercase and digit.</p><p>Conrim passsword must match the provided password.</p>";
        private const string EmailExestsError = "<p>Email is already taken.</p>";
        private const string LoginError = "<p>Invalid credentials.</p>";

        private IUserService users;

        public GuestsController()
        {
            this.users = new UserService();
        }



        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword
            || !this.IsValidModel(model))
            {
                this.ViewModel["show-error"] = "block";
                this.ViewModel["message"] = RegisterError;
                return View();
            }

            if (users.UserExists(model.Email))
            {
                this.ViewModel["show-error"] = "block";
                this.ViewModel["message"] = EmailExestsError;
                return View();
            }

            if (this.users.Create(model.FullName, model.Email, model.Password))
            {
                this.SignIn(model.Email);
                return this.Redirect("/");
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
            if (!this.IsValidModel(model))
            {
                this.ShowError(LoginError);
                return this.View();
            }

            if (!this.users.UserExists(model.Email))
            {
                this.ViewModel["show-error"] = "block";
                this.ViewModel["message"] = LoginError;
                return View();
            }

            this.SignIn(model.Email);

            using (var db = new JudgeAppContext())
            {
                this.Profile = db.Users.First(u => u.Email == model.Email);
            }

            return this.Redirect("/");
        }
    }
}
