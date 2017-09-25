using System;

namespace _03._Self_Referenced_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();
            context.Database.EnsureCreated();
        }
    }
}
