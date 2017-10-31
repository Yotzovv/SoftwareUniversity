using ModPanel.App.Enums;

namespace ModPanel.App.Services.Contracts
{
    public interface IUserService
    {
        bool Create(string email, string password, Positions position);

        bool UserExists(string email, string password);
    }
}
