using _05.ComparingObjs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ComparingObjs
{
    class Launcher
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;

            while((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            if (n > people.Count-1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.Write($"{people.Count(p => p.CompareTo(people[n]) == 0)} ");
                Console.Write(people.Count(p => p.CompareTo(people[n]) != 0) + " ");
                Console.WriteLine(people.Count);
            }
        }
    }
}
