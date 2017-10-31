using JudgeApp.Data;
using Microsoft.EntityFrameworkCore;
using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;

namespace JudgeApp
{
    class Launcher
    {
        static Launcher()
        {
            using (var db = new JudgeAppContext())
            {
                db.Database.Migrate();
            }
        }

        static void Main(string[] args)
        {
            MvcEngine.Run(new WebServer.WebServer(1337, new ControllerRouter(), new ResourceRouter()));
        }
    }
}
