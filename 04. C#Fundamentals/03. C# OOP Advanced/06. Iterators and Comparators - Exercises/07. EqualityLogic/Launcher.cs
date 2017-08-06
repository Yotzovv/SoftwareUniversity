using System;
using System.Collections.Generic;

namespace _07.EqualityLogic
{
    class Launcher
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sorted = new SortedSet<Person>();
            HashSet<Person> hash = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                sorted.Add(person);
                hash.Add(person);
            }

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hash.Count);
        }
    }
}
