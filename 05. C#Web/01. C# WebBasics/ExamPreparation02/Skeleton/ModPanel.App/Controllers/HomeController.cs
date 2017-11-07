using ModPanel.App.Data;
using ModPanel.App.Services;
using ModPanel.App.Services.Contracts;
using SimpleMvc.Framework.Contracts;
using System.Linq;

namespace ModPanel.App.Controllers
{
    public class HomeController : BaseController
    {
        public IPostService posts;

        public HomeController()
        {
            this.posts = new PostService();
        }

        public IActionResult Index()
        {
            var userEmails = new ModPanelContext().Users.Select(ie => new { ie.Id, ie.Email });
            
            var allposts = this.posts
                               .All()
                               .Select(p => $@"
                                        <div class=""card border-primary mb-3"">
                                            <div class=""card-body text-primary"">
                                                <h4 class=""card-title"">{p.Title}</h4>
                                                <p class=""card-text"">{p.Content}</p>
                                            </div>
                                            <div class=""card-footer bg-transparent text-right"">
                                                <span class=""text-muted"">Created on {p.CreatedOn.ToShortDateString()} by <em><strong>{userEmails.First(u => u.Id == p.UserId).Email}</strong></em>
                                                </span>
                                            </div>
                                        </div>")
                                .ToList();
            
            this.ViewModel["posts"] = string.Join(string.Empty, allposts);

            return this.View();
        }
    }
}
