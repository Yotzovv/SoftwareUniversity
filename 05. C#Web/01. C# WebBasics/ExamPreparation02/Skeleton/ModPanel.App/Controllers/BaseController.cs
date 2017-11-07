using ModPanel.App.Data;
using ModPanel.App.Data.Models;
using ModPanel.App.Models;
using ModPanel.App.Services.Contracts;
using SimpleMvc.Framework.Controllers;
using System.Linq;

namespace ModPanel.App.Controllers
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

            if (this.User.IsAuthenticated)
            {
                this.ViewModel["annonymousDisplay"] = "none";
                this.ViewModel["userDisplay"] = "flex";

                using (var db = new ModPanelContext())
                {
                    this.Profile = db.Users
                                     .First(u => u.Email == this.User.Name);

                    if (this.IsAdmin)
                    {
                        this.ViewModel["userDisplay"] = "none";
                        this.ViewModel["adminDisplay"] = "flex";
                    }
                }
            }
        }

        protected bool IsAdmin => this.User.IsAuthenticated && this.Profile.IsAdmin;

        protected bool isApproved(string email)
        {
            using (var db = new ModPanelContext())
            {
                if(db.Users.First(e => e.Email == email).isApproved)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
