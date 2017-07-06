using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Excellent_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            List<Student> names = new List<Student>();

            while ((input = Console.ReadLine().Split())[0] != "END")
            {
                string firstName = input[0];
                string lastName = input[1];
                List<int> grades = input.Skip(2)
                                        .Take(input.Count() - 2)
                                        .Select(int.Parse)
                                        .ToList();
                                        
                                            
                names.Add(new Student(firstName, lastName, grades));
            }

            names.Where(g => g.Grades.Contains(6))
                 .ToList()
                 .ForEach(n => Console.WriteLine($"{n.FirstName} {n.LastName}"));
        }
    }

    class Student
    {
        public Student(string firstName, string lastname, List<int> grades)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
            this.Grades = grades;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<int> Grades { get; set; }
    }
}
