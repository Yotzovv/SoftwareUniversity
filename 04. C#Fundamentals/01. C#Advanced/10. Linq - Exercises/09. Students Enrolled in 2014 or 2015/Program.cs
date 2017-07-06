using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Students_Enrolled_in_2014_or_2015
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
                List<int> grades = input.Skip(1)
                                        .Take(input.Count() - 1)
                                        .Select(int.Parse)
                                        .ToList();


                names.Add(new Student(firstName, grades));
            }

            names.Where(s => s.FacultyNumber.EndsWith("14") || s.FacultyNumber.EndsWith("15"))
                 .ToList()
                 .ForEach(n => Console.WriteLine($"{string.Join(" ", n.Grades)}"));
        }
    }

    class Student
    {
        public Student(string firstName, List<int> grades)
        {
            this.FacultyNumber = firstName;
            this.Grades = grades;
        }
        public string FacultyNumber { get; set; }

        public List<int> Grades { get; set; }
    }
}
