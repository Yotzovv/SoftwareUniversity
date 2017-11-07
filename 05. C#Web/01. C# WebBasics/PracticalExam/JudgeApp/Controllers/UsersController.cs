using JudgeApp.Data;
using JudgeApp.Models;
using JudgeApp.Services;
using JudgeApp.Services.Contracts;
using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Contracts;
using System.Linq;

namespace JudgeApp.Controllers
{
    public class UsersController : BaseController
    {
        private const string PostError = "<p>Title must begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p>";

        private IContestService contests;

        public UsersController()
        {
            this.contests = new ContestService();
        }

        public IActionResult Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }

        public IActionResult Submissions()
        {
            var submissions = new JudgeAppContext().Contests
                                                   .Select(s =>
                                                    $@"<a href=""#"" class=""list-group-item"">{s.Name}</a>")
                                                    .ToList();

            this.ViewModel["contests"] = string.Join(string.Empty, contests);

            return this.View();
        }

        public IActionResult CreateContest() => this.View();

        [HttpPost]
        public IActionResult CreateContest(ContestModel model)
        {
            this.contests.Create(model, this.Profile);

            return this.Redirect("/users/contests");
        }

        public IActionResult Contests()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            var contests = new JudgeAppContext().Contests
                                                .Where(p => p.IsActive)
                                                .Select(p =>
                                                 $@"
                                                 <tr>
                                                     <th scope=""row"">{p.Name}</th>
                                                     <td>{p.Submissions.Count}</td>
                                                     <td><a type=""button"" method=""post"" class=""btn btn-warning"" href=""/users/edit?id={p.Id}"" role=""button"">
                                                 Edit</a>
                                                      <a type=""button"" method=""post"" class=""btn btn-danger"" href=""/users/delete?id={p.Id}"" role=""button"">
                                                 Delete</a></td>
                                                 </tr>")
                                                 .ToList();

            this.ViewModel["contests"] = string.Join(string.Empty, contests);

            return this.View();
        }

        public IActionResult Edit() => this.View();

        [HttpPost]
        public IActionResult Edit(int id, ContestModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            this.contests.Update(id, model, this.Profile);

            return this.Redirect("/users/contests");
        }


        public IActionResult Delete(int id)
        {
            using (var db = new JudgeAppContext())
            {
                var contest = db.Contests.First(c => c.Id == id);

                this.ViewModel["contestName"] = contest.Name;
                return this.View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id, ContestModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/");
            }

            this.contests.Delete(id, model, this.Profile);

            return this.Redirect("/users/contests");
        }

        public IActionResult Back() => this.Redirect("users/contests");
    }
}
