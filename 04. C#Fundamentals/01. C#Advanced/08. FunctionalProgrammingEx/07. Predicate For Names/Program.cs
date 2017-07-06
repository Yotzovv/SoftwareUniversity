using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                                    .Split()
                                    .ToList();
            Func<List<string>, List<string>> filter = s => s.Where(x => x.Length <= n)
                                                    .ToList();

            filter(names).ForEach(name => Console.WriteLine(name));
        }
    }
}
