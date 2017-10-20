using SimpleMvc.App.BindingModels;
using SimpleMvc.App.ViewModels;
using SimpleMvc.Data;
using SimpleMvc.Domain;
using SimpleMvc.Framework.Attributes;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using SimpleMvc.Framework.Interfaces.Generic;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMvc.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
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
        public IActionResult<AllUsernamesViewModel> All()
        {
            List<string> usernames = new List<string>();

            using (var context = new NotesDbContext())
            {
                usernames = context.Users.Select(n => n.Username).ToList();
            }

            var viewModel = new AllUsernamesViewModel()
            {
                Usernames = usernames
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new NotesDbContext())
            {
                var user = context.Users.Find(id);

                var viewModel = new UserProfileViewModel()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = context.Notes
                                   .Where(nid => nid.Owner.Id == user.Id)
                                   .Select(n =>
                                       new NoteViewModel()
                                       {
                                           Title = n.Title,
                                           Content = n.Content
                                       })
                                       .ToList(),
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
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
    }
}
