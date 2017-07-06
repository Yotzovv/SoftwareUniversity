using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sort_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            List<Student> names = new List<Student>();

            while ((input = Console.ReadLine().Split())[0] != "END")
            {
                names.Add(new Student(input[0], input[1]));
            }

            names.OrderBy(l => l.LastName)
                 .ThenByDescending(f => f.FirstName)
                 .ToList()
                 .ForEach(n => Console.WriteLine($"{n.FirstName} {n.LastName}"));
        }
    }

    class Student
    {
        public Student(string firstName, string lastname)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
