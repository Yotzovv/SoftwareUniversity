using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Filter_Students_by_Email_Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            List<Student> names = new List<Student>();

            while ((input = Console.ReadLine().Split())[0] != "END")
            {
                names.Add(new Student(input[0], input[1], input[2]));
            }
            
            names.Where(e => e.Email.EndsWith("gmail.com"))
                 .ToList()
                 .ForEach(n => Console.WriteLine($"{n.FirstName} {n.LastName}"));
        }
    }

    class Student
    {
        public Student(string firstName, string lastname, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
            this.Email = email;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}