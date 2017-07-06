using _01.Define_a_Class_Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Opinion_Poll
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0], int.Parse(input[1]));

                people.Add(person);
            }

            people.Where(a => a.Age > 30)
                  .OrderBy(x => x.Name)
                  .ToList()
                  .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
