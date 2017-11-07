using ModPanel.App.Data;
using ModPanel.App.Data.Models;
using ModPanel.App.Models;
using ModPanel.App.Services;
using ModPanel.App.Services.Contracts;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Contracts;
using System;
using System.Linq;

namespace ModPanel.App.Controllers
{
    public class UsersController : BaseController
    {
        private const string PostError = "<p>Title must begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p>";

        public IPostService posts;

        public UsersController()
        {
            posts = new PostService();
        }

        public IActionResult Users()
        {
            if(!this.User.IsAuthenticated || !this.Profile.IsAdmin)
            {
                return this.Redirect("/");
            }

            var users = new ModPanelContext().Users
                                             .Select(u => u.isApproved ?
                                             $@"
                                             <tr>
                                                 <th scope=""row"">{u.Id}</th>
                                                 <td>{u.Email}</td>
                                                 <td>{u.Position}</td>
                                                 <td>{u.Posts.Count}</td>
                                                 <td>{u.Logs.Count}</td>
                                             </tr>"
                                             :
                                             $@"
                                             <tr>
                                                 <th scope=""row"">{u.Id}</th>
                                                 <td>{u.Email}</td>
                                                 <td>{u.Position}</td>
                                                 <td>{u.Posts.Count}</td>
                                                 <td><a type=""button"" method=""post"" class=""btn btn-primary"" href=""/users/approve?id={u.Id}"" role=""button"">
                                                 Approve</a></td>
                                             </tr>")
                                           .ToList();

            this.ViewModel["users"] = string.Join(string.Empty, users);

            return this.View();
        }

        public IActionResult Approve(int id)
        {
            using (var db = new ModPanelContext())
            {
                db.Users.First(u => u.Id == id).isApproved = true;
                db.SaveChanges();
            }

            return this.Redirect("/users/users");
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(PostModel model)
        {
            this.posts.Update(model);

            return this.View();
        }


        public IActionResult Delete(int id)
        {
            if(!this.User.IsAuthenticated || !this.IsAdmin)
            {
                return this.Redirect("/");
            }

            using (var db = new ModPanelContext())
            {
                db.Posts.First(p => p.Id == id).IsActive = false;
                db.SaveChanges();
            }

            return this.Redirect("/users/posts");
        }

        public IActionResult Posts()
        {
            if (!this.User.IsAuthenticated || !this.IsAdmin)
            {
                return this.Redirect("/");
            }

            var allposts = new ModPanelContext().Posts
                                                .Where(p => p.IsActive)
                                                .Select(p =>
                                                 $@"
                                                 <tr>
                                                     <th scope=""row"">{p.Id}</th>
                                                     <td>{p.Title}</td>
                                                     <td><a type=""button"" method=""post"" class=""btn btn-warning"" href=""/users/edit?id={p.Id}"" role=""button"">
                                                 Edit</a>
                                                      <a type=""button"" method=""post"" class=""btn btn-danger"" href=""/users/delete?id={p.Id}"" role=""button"">
                                                 Delete</a></td>
                                                 </tr>")
                                                 .ToList();

            this.ViewModel["posts"] = string.Join(string.Empty, allposts);

            return this.View();
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return Redirect("/");
        }

        public IActionResult CreatePost()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult CreatePost(PostModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.ShowError(PostError);
                return this.View();
            }

            this.posts.Create(this.Profile.Id, model.Title, model.Content, this.Profile.Email, DateTime.UtcNow);

            return this.Redirect("/");
        }
    }
}
