using System;

namespace _04._Many_To_Many_Relation
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
