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
            var input = Console.ReadLine().Split();

            string firstName = input[0];
            string lastName = input[1];
            int age = int.Parse(input[2]);
            double salary = double.Parse(input[3]);

            try
            {
                Person person = new Person(firstName, lastName, age, salary);
                people.Add(person);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        double bonus = double.Parse(Console.ReadLine());


        people.ForEach(p => p.IncreaseSalary(bonus));
        people.ForEach(p => Console.WriteLine(p));
    }
}
