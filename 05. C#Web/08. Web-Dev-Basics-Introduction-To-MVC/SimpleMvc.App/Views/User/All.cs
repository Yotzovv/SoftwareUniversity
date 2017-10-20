using SimpleMvc.App.ViewModels;
using SimpleMvc.Framework.Interfaces.Generic;
using System.Text;

namespace SimpleMvc.App.Views.Users
{
    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine($@"<a href=http://localhost:8000/home/index> Home</a>");

            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");

            foreach (var username in Model.Usernames)
            {
                sb.AppendLine($"<li><a href=http://localhost:8000/users/profile?id={Model.GetUserID(username)}> {username}</a></li>");
            }

            sb.AppendLine("<ul>");

            return sb.ToString();
        }
    }
}
