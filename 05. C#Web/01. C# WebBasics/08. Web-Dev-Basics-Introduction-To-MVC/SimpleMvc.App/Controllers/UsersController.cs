using SimpleMvc.App.BindingModels;
using SimpleMvc.Data;
using SimpleMvc.Domain;
using SimpleMvc.Framework.ActionResults;
using SimpleMvc.Framework.Attributes;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using System.Collections.Generic;
using System.Linq;
using WebServer.Http.Response;

namespace SimpleMvc.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel loginUserBinding)
        {
            using (var context = new NotesDbContext())
            {
                var foundUser = context.Users.FirstOrDefault(u => u.Username == loginUserBinding.Username);

                if(foundUser == null)
                {
                    return RedirectToAction("/home/login");
                }

                context.SaveChanges();
                this.SignIn(foundUser.Username);
            }

            return RedirectToAction("/home/index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            if(!this.IsValidModel(model))
            {
                return View();
            }

            //TODO: Add User into the db
            var user = new Domain.User()
            {
                Username = model.Username,
                Password = model.Password,
                Notes = new List<Note>(),
            };

            using (var context = new NotesDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult All()
        {
            if(!this.User.IsAuthenticated)
            {
                return RedirectToAction("/users/login");
            }

            Dictionary<int, string> users = new Dictionary<int, string>();

            using (var context = new NotesDbContext())
            {
                users = context.Users.ToDictionary(u => u.Id, u => u.Username);
            }

            this.Model["users"] = users.Any()
                                  ? string.Join(string.Empty, users.Select(u =>
                                  $"<li><a href=\"/users/profile?id={u.Key}\">{u.Value}</a></li>"))
                                  : string.Empty;

            return View();
        }

        [HttpGet]
        public IViewable Profile(int id)
        {
            if(!this.User.IsAuthenticated)
            {
                return RedirectToAction("/users/login");
            }

            User user = new User();

            using (var context = new NotesDbContext())
            {
                user = context.Users.Find(id);
            }

            return View();
        }

        private IViewable RedirectToAction(string v)
        {
            return new RedirectResult(v);
        }

        [HttpPost]
        public IViewable Profile(AddNoteBindingModel model)
        {
            using (var context = new NotesDbContext())
            {
                var note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content,
                    Owner = context.Users.Find(model.UserId),
                };

                context.Notes.Add(note);
                context.Users.Find(model.UserId).Notes.Add(note);

                context.SaveChanges();
            };

            return Profile(model.UserId);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            this.SignOut();

            return RedirectToAction("/home/index");
        }

    }
}
