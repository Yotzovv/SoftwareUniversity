namespace SimpleMvc.App.BindingModels
{
    public class LoginUserBindingModel
    {
        public LoginUserBindingModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; private set; }

        public string Password { get; private set; }
    }
}
