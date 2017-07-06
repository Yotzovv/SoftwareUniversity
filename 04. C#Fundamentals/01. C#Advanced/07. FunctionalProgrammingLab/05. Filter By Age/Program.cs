using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _05.Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> humans = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                                   .Split(new[] { ',', ' ' })
                                   .ToList();

                humans.Add(input[0], int.Parse(input[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredStudent(humans, tester, printer);
        }

        private static void PrintFilteredStudent(Dictionary<string, int> humans, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            var filteredHumans = humans.Where(x => tester(x.Value));

            foreach (var human in filteredHumans)
            {
                printer(human);
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch(format)
            {
                case "name" : return person => Console.WriteLine(person.Key);
                case "age" : return person => Console.WriteLine(person.Value);
                case "name age": return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            switch(condition)
            {
                case "younger" : return x => x < age;
                case "older": return x => x > age;
                default: return null;
            }
        }
    }
}
