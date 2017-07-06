using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            string firstName = input[0];
            string lastName = input[1];
            int age = int.Parse(input[2]);

            Person person = new Person(firstName, lastName, age);
            people.Add(person);
        }

        people.OrderBy(p => p.FirstName)
              .ThenBy(p => p.Age)
              .ToList()
              .ForEach(p => Console.WriteLine(p));
    }
}