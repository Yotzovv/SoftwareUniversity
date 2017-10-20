using SimpleMvc.Framework.Interfaces;
using System.Text;

namespace SimpleMvc.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<h1>NotesApp</h1>");
            sb.AppendLine($"<a href=http://localhost:8000/users/all >All Users </a>"
                         +$"<a href=http://localhost:8000/users/register >Register</a>");

            return sb.ToString();
        }
    }
}
