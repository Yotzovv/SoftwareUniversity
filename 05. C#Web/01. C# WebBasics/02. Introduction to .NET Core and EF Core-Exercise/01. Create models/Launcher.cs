using Microsoft.EntityFrameworkCore;
using System;

namespace _01._Create_models
{
    class Launcher
    {
        static void Main(string[] args)
        {
            using (var context = new SystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                //context.Database.Migrate();
            }
        }
    }
}
