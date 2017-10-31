using JudgeApp.Data;
using JudgeApp.Data.Models;
using SimpleMvc.Framework.Controllers;
using System.Linq;

namespace JudgeApp.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.ViewModel["layoutAnnonymousDisplay"] = "flex";
            this.ViewModel["annonymousDisplay"] = "block";
            this.ViewModel["adminDisplay"] = "none";
            this.ViewModel["userDisplay"] = "none";
            this.ViewModel["layoutUserDisplay"] = "none";
            this.ViewModel["layoutAdminDisplay"] = "none";
            this.ViewModel["show-error"] = "none";
        }

        protected User Profile { get; set; }

        protected void ShowError(string error)
        {
            this.ViewModel["show-error"] = "flex";
            this.ViewModel["error"] = error;
        }

        protected override void InitializeController()
        {
            base.InitializeController();

            if (this.User.IsAuthenticated)
            {
                this.ViewModel["layoutAnnonymousDisplay"] = "none";
                this.ViewModel["annonymousDisplay"] = "none";
                this.ViewModel["layoutUserDisplay"] = "flex";
                this.ViewModel["userDisplay"] = "block";

                using (var db = new JudgeAppContext())
                {
                    this.Profile = db.Users
                                     .First(u => u.Email == this.User.Name);

                    if (this.IsAdmin)
                    {
                        this.ViewModel["layoutUserDisplay"] = "none";
                        this.ViewModel["userDisplay"] = "none";
                        this.ViewModel["adminDisplay"] = "block";
                        this.ViewModel["layoutAdminDisplay"] = "flex";
                    }
                }
            }
        }

        protected bool IsAdmin => this.User.IsAuthenticated && this.Profile.IsAdmin;
    }
}