using Microsoft.EntityFrameworkCore;
using ModPanel.App.Data;
using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;

namespace ModPanel.App
{
    class Launcher
    {
        static Launcher()
        {
            using (var db = new ModPanelContext())
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
