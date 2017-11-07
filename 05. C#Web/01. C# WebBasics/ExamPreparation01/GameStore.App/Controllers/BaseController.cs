using GameStore.App.Data;
using GameStore.App.Data.Models;
using SimpleMvc.Framework.Controllers;
using System.Linq;

namespace GameStore.App.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.ViewModel["annonymousDisplay"] = "flex";
            this.ViewModel["userDisplay"] = "none";
            this.ViewModel["adminDisplay"] = "none";
            this.ViewModel["show-error"] = "none";
        }

        protected User Profile { get; private set; }

        protected void ShowError(string error)
        {
            this.ViewModel["show-error"] = "block";
            this.ViewModel["error"] = error;
        }

        protected override void InitializeController()
        {
            base.InitializeController();

            if(this.User.IsAuthenticated)
            {
                this.ViewModel["annonymousDisplay"] = "none";
                this.ViewModel["userDisplay"] = "flex";

                using (var db = new GameStoreDbContext())
                {
                    this.Profile = db.Users
                                     .First(u => u.Email == this.User.Name);

                    if(this.IsAdmin)
                    {
                        this.ViewModel["userDisplay"] = "none";
                        this.ViewModel["adminDisplay"] = "flex";
                    }
                }
            }
        }

        protected bool IsAdmin => this.User.IsAuthenticated && this.Profile.IsAdmin;
    }
}
