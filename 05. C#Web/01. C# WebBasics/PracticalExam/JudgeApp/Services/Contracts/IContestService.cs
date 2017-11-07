using JudgeApp.Data.Models;
using JudgeApp.Models;

namespace JudgeApp.Services.Contracts
{
    public interface IContestService
    {
        void Create(ContestModel model, User creator);

        void Update(int id, ContestModel model, User currentUser);

        void Delete(int id, ContestModel model, User currentUser);
    }
}
