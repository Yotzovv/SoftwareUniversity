namespace JudgeApp.Services.Contracts
{
    public interface IUserService
    {
        bool Create(string fullName, string email, string password);

        bool UserExists(string email, string password);

        bool UserExists(string email);
    }
}
