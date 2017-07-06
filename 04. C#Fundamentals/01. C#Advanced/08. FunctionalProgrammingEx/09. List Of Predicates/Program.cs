using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();

            Func<int, bool> isDivided = n => dividers.All(d => n % d == 0);

            for (int i = 1; i <= range; i++)
            {
                if (isDivided(i)) Console.Write(i + " ");
            }
        }
    }
}
