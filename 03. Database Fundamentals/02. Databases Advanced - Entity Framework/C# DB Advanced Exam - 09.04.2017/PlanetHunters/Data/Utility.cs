using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Utility
    {
        public static void InitializeDB()
        {
            var context = new SystemContext();
            context.Database.Initialize(true);
        }
    }
}
