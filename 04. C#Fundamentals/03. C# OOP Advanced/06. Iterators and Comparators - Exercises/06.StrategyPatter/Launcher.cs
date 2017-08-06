using _06.StrategyPatter.Models;
using System;
using System.Collections.Generic;

namespace _06.StrategyPatter
{
    class Launcher
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedByName = new SortedSet<Person>(new NameComparer());
            SortedSet<Person> sortedByAge = new SortedSet<Person>(new AgeCompare());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                sortedByName.Add(person);
                sortedByAge.Add(person);
            }

            foreach (var person in sortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in sortedByAge)
            {
                Console.WriteLine(person);
            }

        }
    }
}
