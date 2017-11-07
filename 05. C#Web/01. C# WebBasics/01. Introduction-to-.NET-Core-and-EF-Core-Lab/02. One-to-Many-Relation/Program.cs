using System;

namespace _02._One_to_Many_Relation
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
