using JudgeApp.Data;
using JudgeApp.Data.Models;
using JudgeApp.Models;
using JudgeApp.Services.Contracts;
using System.Linq;

namespace JudgeApp.Services
{
    public class ContestService : IContestService
    {
        public void Create(ContestModel model, User creator)
        {
            using (var db = new JudgeAppContext())
            {
                var contest = new Contest()
                {
                    Name = model.Name,
                    UserId = creator.Id,
                    IsActive = true,
                };

                db.Contests.Add(contest);
                db.SaveChanges();
            }
        }

        public void Update(int id, ContestModel model, User currentUser)
        {
            using (var db = new JudgeAppContext())
            {
                var contest = db.Contests.First(p => p.Id == id);

                if (!currentUser.IsAdmin && contest.UserId != currentUser.Id)
                {
                    return;
                }

                contest.Name = model.Name;

                db.SaveChanges();
            }
        }

        public void Delete(int id, ContestModel model, User currentUser)
        {
            using (var db = new JudgeAppContext())
            {
                var contest = db.Contests.First(p => p.Id == id);

                if (!currentUser.IsAdmin && contest.UserId != currentUser.Id)
                {
                    return;
                }

                contest.IsActive = false;
                db.SaveChanges();
            }
        }
    }
}
